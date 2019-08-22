using FastMember;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.BulkExtensions
{
    public class TableInfo
    {
        public string Schema { get; set; }
        public string SchemaFormated => Schema != null ? $"[{Schema}]." : "";
        public string TableName { get; set; }
        public string FullTableName => $"{SchemaFormated}[{TableName}]";
        public List<string> PrimaryKeys { get; set; }
        public bool HasSinglePrimaryKey { get; set; }
        public bool UpdateByPropertiesAreNullable { get; set; }

        protected string TempDbPrefix => BulkConfig.UseTempDb ? "#" : "";
        public string TempTableSufix { get; set; }
        public string TempTableName => $"{TableName}{TempTableSufix}";
        public string FullTempTableName => $"{SchemaFormated}[{TempDbPrefix}{TempTableName}]";
        public string FullTempOutputTableName => $"{SchemaFormated}[{TempDbPrefix}{TempTableName}Output]";

        public bool InsertToTempTable { get; set; }
        public bool HasIdentity { get; set; }
        public bool HasOwnedTypes { get; set; }
        public int NumberOfEntities { get; set; }

        public BulkConfig BulkConfig { get; set; }
        public List<IProperty> ShadowProperties { get; set; } = new List<IProperty>();
        public Dictionary<string, ValueConverter> ConvertibleProperties { get; set; } = new Dictionary<string, ValueConverter>();
        public string TimeStampColumn { get; set; }

        public Dictionary<string, string> OutputPropertyColumnNamesDict { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> PropertyColumnNamesDict { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, Type> NavigationPropertyDict { get; set; } = new Dictionary<string, Type>();

        public static TableInfo CreateInstance<T>(DbContext context, IList<T> entities, OperationType operationType, BulkConfig bulkConfig)
        {
            var tableInfo = new TableInfo
            {
                NumberOfEntities = entities.Count,
                BulkConfig = bulkConfig ?? new BulkConfig()
            };

            var isExplicitTransaction = context.Database.GetDbConnection().State == ConnectionState.Open;
            if (tableInfo.BulkConfig.UseTempDb == true && !isExplicitTransaction && operationType != OperationType.Insert)
            {
                tableInfo.BulkConfig.UseTempDb = false;
                // If BulkOps is not in explicit transaction then tempdb[#] can only be used with Insert, other Operations done with customTemp table.
                // Otherwise throws exception: 'Cannot access destination table' (gets Droped too early because transaction ends before operation is finished)
            }

            var isDeleteOperation = operationType == OperationType.Delete;
            tableInfo.LoadData<T>(context, isDeleteOperation);
            return tableInfo;
        }

        private void LoadData<T>(DbContext context, bool loadOnlyPkColumn)
        {
            var entityType = context.Model.FindEntityType(typeof(T));
            if (entityType == null)
                throw new InvalidOperationException("DbContext does not contain EntitySet for Type: " + typeof(T).Name);

            var relationalData = entityType.Relational();
            Schema = relationalData.Schema ?? "dbo";
            TableName = relationalData.TableName;
            TempTableSufix = "Temp" + Guid.NewGuid().ToString().Substring(0, 8); // 8 chars of Guid as tableNameSufix to avoid same name collision with other tables

            var areSpecifiedUpdateByProperties = BulkConfig.UpdateByProperties?.Count() > 0;
            PrimaryKeys = areSpecifiedUpdateByProperties ? BulkConfig.UpdateByProperties : entityType.FindPrimaryKey().Properties.Select(a => a.Name).ToList();
            HasSinglePrimaryKey = PrimaryKeys.Count == 1;

            var allProperties = entityType.GetProperties().AsEnumerable().ToList();

            var allNavigationProperties = entityType.GetNavigations().Where(a => a.GetTargetType().IsOwned()).ToList();
            HasOwnedTypes = allNavigationProperties.Any();

            if (HasOwnedTypes)
            {
                foreach (var navigationProperty in allNavigationProperties)
                {
                    var t = navigationProperty.PropertyInfo.PropertyType;
                    var entityType2 = context.Model.FindEntityType(t);
                    if (entityType2 == null)
                        throw new InvalidOperationException("DbContext does not contain EntitySet for Type: " + typeof(T).Name);

                    var newProperties = entityType2.GetProperties().
                        Where(p => !p.IsShadowProperty).AsEnumerable().ToList();

                    allProperties.AddRange(newProperties);
                }
            }

            // timestamp datatype can only be set by database, that's property having [Timestamp] Attribute but keep if one with [ConcurrencyCheck]
            var timeStampProperties = allProperties.Where(a =>
                a.IsConcurrencyToken && a.ValueGenerated == ValueGenerated.OnAddOrUpdate &&
                a.BeforeSaveBehavior == PropertySaveBehavior.Ignore);

            TimeStampColumn = timeStampProperties.FirstOrDefault()?.Relational().ColumnName; // expected to be only One
            var properties = allProperties.Except(timeStampProperties);

            //OutputPropertyColumnNamesDict = properties.ToDictionary(a => a.Name, b => b.Relational().ColumnName);
            OutputPropertyColumnNamesDict.Clear();
            foreach (var property in properties)
            {
                OutputPropertyColumnNamesDict.Add(property.DeclaringEntityType + property.Name, property.Relational().ColumnName);
            }


            properties = properties.Where(a => a.Relational().ComputedColumnSql == null);

            var areSpecifiedPropertiesToInclude = BulkConfig.PropertiesToInclude?.Count() > 0;
            var areSpecifiedPropertiesToExclude = BulkConfig.PropertiesToExclude?.Count() > 0;

            if (areSpecifiedPropertiesToInclude)
            {
                if (areSpecifiedUpdateByProperties) // Adds UpdateByProperties to PropertyToInclude if they are not already explicitly listed
                {
                    foreach (var updateByProperty in BulkConfig.UpdateByProperties)
                    {
                        if (!BulkConfig.PropertiesToInclude.Contains(updateByProperty))
                        {
                            BulkConfig.PropertiesToInclude.Add(updateByProperty);
                        }
                    }
                }
                else // Adds PrimaryKeys to PropertyToInclude if they are not already explicitly listed
                {
                    foreach (var primaryKey in PrimaryKeys)
                    {
                        if (!BulkConfig.PropertiesToInclude.Contains(primaryKey))
                        {
                            BulkConfig.PropertiesToInclude.Add(primaryKey);
                        }
                    }
                }
            }

            UpdateByPropertiesAreNullable = properties.Any(a => PrimaryKeys.Contains(a.Name) && a.IsNullable);

            if (areSpecifiedPropertiesToInclude || areSpecifiedPropertiesToExclude)
            {
                if (areSpecifiedPropertiesToInclude && areSpecifiedPropertiesToExclude)
                    throw new InvalidOperationException("Only one group of properties, either PropertiesToInclude or PropertiesToExclude can be specifed, specifying both not allowed.");
                if (areSpecifiedPropertiesToInclude)
                    properties = properties.Where(a => BulkConfig.PropertiesToInclude.Contains(a.Name));
                if (areSpecifiedPropertiesToExclude)
                    properties = properties.Where(a => !BulkConfig.PropertiesToExclude.Contains(a.Name));
            }

            if (loadOnlyPkColumn)
            {
                PropertyColumnNamesDict = properties.Where(a => PrimaryKeys.Contains(a.Name)).ToDictionary(
                    a => a.Name,
                    b => b.Relational().ColumnName);

                NavigationPropertyDict.Clear();
                foreach (var item in properties.Where(a => PrimaryKeys.Contains(a.Name)))
                {
                    var fk = item.GetContainingForeignKeys().ToList();
                    if (fk.Count() != 0)
                    {
                        NavigationPropertyDict.Add(item.Name, fk[0].PrincipalEntityType.ClrType);
                    }
                }

            }
            else
            {
                PropertyColumnNamesDict = properties.ToDictionary(
                    a => a.Name, b => b.Relational().ColumnName);

                NavigationPropertyDict.Clear();
                foreach (var item in properties)
                {
                    var fk = item.GetContainingForeignKeys().ToList();
                    if (fk.Count() != 0)
                    {
                        NavigationPropertyDict.Add(item.Name, fk[0].PrincipalEntityType.ClrType);
                    }
                }

                //ShadowProperties = properties.Where(p => p.IsShadowProperty).Select(p => p.Relational()).ToList();
                ShadowProperties = properties.Where(p => p.IsShadowProperty).ToList();
                foreach (var property in properties.Where(p => p.GetValueConverter() != null))
                {
                    ConvertibleProperties.Add(property.Relational().ColumnName, property.GetValueConverter());
                }
            }
        }

        public void CheckHasIdentity(DbContext context)
        {
            var hasIdentity = 0;
            if (HasSinglePrimaryKey)
            {
                var sqlConnection = context.Database.GetDbConnection();
                var currentTransaction = context.Database.CurrentTransaction;
                try
                {
                    if (currentTransaction == null)
                    {
                        if (sqlConnection.State != ConnectionState.Open)
                            sqlConnection.Open();
                    }
                    using (var command = sqlConnection.CreateCommand())
                    {
                        if (currentTransaction != null)
                        {
                            command.Transaction = currentTransaction.GetDbTransaction();
                        }

                        command.CommandText = SqlQueryBuilder.SelectIsIdentity(FullTableName, PropertyColumnNamesDict[PrimaryKeys[0]]);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    hasIdentity = reader[0] == DBNull.Value ? 0 : (int)reader[0];
                                }
                            }
                        }
                    }
                }
                finally
                {
                    if (currentTransaction == null)
                        sqlConnection.Close();
                }
            }
            HasIdentity = hasIdentity == 1;
        }

        public async Task CheckHasIdentityAsync(DbContext context)
        {
            var hasIdentity = 0;
            if (HasSinglePrimaryKey)
            {
                var sqlConnection = context.Database.GetDbConnection();
                var currentTransaction = context.Database.CurrentTransaction;
                try
                {
                    if (currentTransaction == null)
                    {
                        if (sqlConnection.State != ConnectionState.Open)
                            await sqlConnection.OpenAsync().ConfigureAwait(false);
                    }
                    using (var command = sqlConnection.CreateCommand())
                    {
                        if (currentTransaction != null)
                            command.Transaction = currentTransaction.GetDbTransaction();
                        command.CommandText = SqlQueryBuilder.SelectIsIdentity(FullTableName, PropertyColumnNamesDict[PrimaryKeys[0]]);
                        using (var reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                        {
                            if (reader.HasRows)
                            {
                                while (await reader.ReadAsync().ConfigureAwait(false))
                                {
                                    hasIdentity = (int)reader[0];
                                }
                            }
                        }
                    }
                }
                finally
                {
                    if (currentTransaction == null)
                    {
                        sqlConnection.Close();
                    }
                }
            }
            HasIdentity = hasIdentity == 1;
        }

        public void SetSqlBulkCopyConfig<T>(SqlBulkCopy sqlBulkCopy, IList<T> entities, bool setColumnMapping, Action<decimal> progress)
        {
            sqlBulkCopy.DestinationTableName = this.InsertToTempTable ? this.FullTempTableName : this.FullTableName;
            sqlBulkCopy.BatchSize = BulkConfig.BatchSize;
            sqlBulkCopy.NotifyAfter = BulkConfig.NotifyAfter ?? BulkConfig.BatchSize;
            sqlBulkCopy.SqlRowsCopied += (sender, e) => {
                progress?.Invoke((decimal)(e.RowsCopied * 10000 / entities.Count) / 10000); // round to 4 decimal places
            };
            sqlBulkCopy.BulkCopyTimeout = BulkConfig.BulkCopyTimeout ?? sqlBulkCopy.BulkCopyTimeout;
            sqlBulkCopy.EnableStreaming = BulkConfig.EnableStreaming;

            if (setColumnMapping)
            {
                foreach (var element in this.PropertyColumnNamesDict)
                {
                    sqlBulkCopy.ColumnMappings.Add(element.Key, element.Value);
                }
            }
        }

        public void UpdateOutputIdentity<T>(DbContext context, IList<T> entities) where T : class
        {
            if (this.HasSinglePrimaryKey)
            {
                var entitiesWithOutputIdentity = QueryOutputTable<T>(context).ToList();
                UpdateEntitiesIdentity(entities, entitiesWithOutputIdentity);
            }
        }

        public async Task UpdateOutputIdentityAsync<T>(DbContext context, IList<T> entities) where T : class
        {
            if (this.HasSinglePrimaryKey)
            {
                var entitiesWithOutputIdentity = await QueryOutputTable<T>(context).ToListAsync().ConfigureAwait(false);
                UpdateEntitiesIdentity(entities, entitiesWithOutputIdentity);
            }
        }

        private IQueryable<T> QueryOutputTable<T>(DbContext context) where T : class
        {
            string q = SqlQueryBuilder.SelectFromOutputTable(this);
            var query = context.Set<T>().FromSql(q);

            var queryOrdered = OrderBy(query, this.PrimaryKeys[0]);
            // ALTERNATIVELY OrderBy with DynamicLinq ('using System.Linq.Dynamic.Core;' NuGet required) that eliminates need for custom OrderBy<T> method with Expression.
            //var queryOrdered = query.OrderBy(this.PrimaryKeys[0]);

            return queryOrdered;
        }

        private void UpdateEntitiesIdentity<T>(IList<T> entities, IList<T> entitiesWithOutputIdentity)
        {
            if (this.BulkConfig.PreserveInsertOrder) // Updates PK in entityList
            {
                var accessor = TypeAccessor.Create(typeof(T));
                for (int i = 0; i < this.NumberOfEntities; i++)
                    accessor[entities[i], this.PrimaryKeys[0]] = accessor[entitiesWithOutputIdentity[i], this.PrimaryKeys[0]];
            }
            else // Clears entityList and then refills it with loaded entites from Db
            {
                entities.Clear();
                ((List<T>)entities).AddRange(entitiesWithOutputIdentity);
            }
        }

        private static IQueryable<T> OrderBy<T>(IQueryable<T> source, string ordering)
        {
            var entityType = typeof(T);
            var property = entityType.GetProperty(ordering);
            var parameter = Expression.Parameter(entityType);
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);
            var resultExp = Expression.Call(typeof(Queryable), "OrderBy", new Type[] { entityType, property.PropertyType }, source.Expression, Expression.Quote(orderByExp));
            var orderedQuery = source.Provider.CreateQuery<T>(resultExp);
            return orderedQuery;
        }
    }
}
