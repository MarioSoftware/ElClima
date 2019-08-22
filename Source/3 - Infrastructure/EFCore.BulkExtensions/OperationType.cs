using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.BulkExtensions
{
    public enum OperationType
    {
        Insert,
        InsertOrUpdate,
        Update,
        Delete,
    }

    internal static class SqlBulkOperation
    {
        public static void Insert<T>(DbContext context, IList<T> entities, TableInfo tableInfo, Action<decimal> progress)
        {
            var sqlConnection = OpenAndGetSqlConnection(context);
            var transaction = context.Database.CurrentTransaction;
            try
            {
                using (var sqlBulkCopy =
                    GetSqlBulkCopy(sqlConnection, transaction, tableInfo.BulkConfig.SqlBulkCopyOptions))
                {
                    //var setColumnMapping = !tableInfo.HasOwnedTypes;

                    var setColumnMapping = true;

                    tableInfo.SetSqlBulkCopyConfig(sqlBulkCopy, entities, setColumnMapping, progress);

                    if (!tableInfo.HasOwnedTypes)
                    {
                        using (var reader = ObjectReaderEx.Create(entities, tableInfo.ShadowProperties,
                            tableInfo.ConvertibleProperties, context, tableInfo.PropertyColumnNamesDict.Keys.ToArray()))
                        {
                            sqlBulkCopy.WriteToServer(reader);
                        }
                    }
                    else // With OwnedTypes DataTable is used since library FastMember can not (https://github.com/mgravell/fast-member/issues/21)
                    {
                        var dataTable = GetDataTable<T>(context, tableInfo, entities);
                        sqlBulkCopy.WriteToServer(dataTable);
                    }

                }
            }
            catch (Exception)
            {
                transaction?.Rollback();

                throw;
            }
            finally
            {
                if (transaction == null)
                {
                    sqlConnection.Close();
                }
            }
        }

        public static async Task InsertAsync<T>(DbContext context, IList<T> entities, TableInfo tableInfo, Action<decimal> progress)
        {
            var sqlConnection = await OpenAndGetSqlConnectionAsync(context);
            var transaction = context.Database.CurrentTransaction;
            try
            {
                using (var sqlBulkCopy = GetSqlBulkCopy(sqlConnection, transaction, tableInfo.BulkConfig.SqlBulkCopyOptions))
                {
                    var setColumnMapping = !tableInfo.HasOwnedTypes;
                    tableInfo.SetSqlBulkCopyConfig(sqlBulkCopy, entities, setColumnMapping, progress);
                    if (!tableInfo.HasOwnedTypes)
                    {
                        using (var reader = ObjectReaderEx.Create(entities, tableInfo.ShadowProperties, tableInfo.ConvertibleProperties, context, tableInfo.PropertyColumnNamesDict.Keys.ToArray()))
                        {
                            await sqlBulkCopy.WriteToServerAsync(reader).ConfigureAwait(false);
                        }
                    }
                    else
                    {
                        var dataTable = GetDataTable<T>(context, tableInfo, entities);
                        await sqlBulkCopy.WriteToServerAsync(dataTable);
                    }
                }
            }
            finally
            {
                if (transaction == null)
                {
                    sqlConnection.Close();
                }
            }
        }

        public static void Merge<T>(DbContext context, IList<T> entities, TableInfo tableInfo, OperationType operationType, Action<decimal> progress) where T : class
        {
            tableInfo.InsertToTempTable = true;
            if (tableInfo.BulkConfig.UpdateByProperties == null || !tableInfo.BulkConfig.UpdateByProperties.Any())
                tableInfo.CheckHasIdentity(context);

            context.Database.ExecuteSqlCommand(SqlQueryBuilder.CreateTableCopy(tableInfo.FullTableName, tableInfo.FullTempTableName, tableInfo));
            if (tableInfo.BulkConfig.SetOutputIdentity)
            {
                context.Database.ExecuteSqlCommand(SqlQueryBuilder.CreateTableCopy(tableInfo.FullTableName, tableInfo.FullTempOutputTableName, tableInfo, true));
            }
            try
            {
                Insert(context, entities, tableInfo, progress);
                context.Database.ExecuteSqlCommand(SqlQueryBuilder.MergeTable(tableInfo, operationType));

                if (tableInfo.BulkConfig.SetOutputIdentity && tableInfo.HasSinglePrimaryKey)
                {
                    try
                    {
                        tableInfo.UpdateOutputIdentity(context, entities);
                    }
                    finally
                    {
                        if (!tableInfo.BulkConfig.UseTempDb)
                            context.Database.ExecuteSqlCommand(SqlQueryBuilder.DropTable(tableInfo.FullTempOutputTableName));
                    }
                }
            }
            finally
            {
                if (!tableInfo.BulkConfig.UseTempDb)
                    context.Database.ExecuteSqlCommand(SqlQueryBuilder.DropTable(tableInfo.FullTempTableName));
            }
        }

        public static async Task MergeAsync<T>(DbContext context, IList<T> entities, TableInfo tableInfo, OperationType operationType, Action<decimal> progress) where T : class
        {
            tableInfo.InsertToTempTable = true;
            await tableInfo.CheckHasIdentityAsync(context).ConfigureAwait(false);

            await context.Database.ExecuteSqlCommandAsync(SqlQueryBuilder.CreateTableCopy(tableInfo.FullTableName, tableInfo.FullTempTableName, tableInfo)).ConfigureAwait(false);
            if (tableInfo.BulkConfig.SetOutputIdentity && tableInfo.HasIdentity)
            {
                await context.Database.ExecuteSqlCommandAsync(SqlQueryBuilder.CreateTableCopy(tableInfo.FullTableName, tableInfo.FullTempOutputTableName, tableInfo, true)).ConfigureAwait(false);
            }
            try
            {
                await InsertAsync(context, entities, tableInfo, progress).ConfigureAwait(false);
                await context.Database.ExecuteSqlCommandAsync(SqlQueryBuilder.MergeTable(tableInfo, operationType)).ConfigureAwait(false);

                if (tableInfo.BulkConfig.SetOutputIdentity && tableInfo.HasIdentity)
                {
                    try
                    {
                        await tableInfo.UpdateOutputIdentityAsync(context, entities).ConfigureAwait(false);
                    }
                    finally
                    {
                        await context.Database.ExecuteSqlCommandAsync(SqlQueryBuilder.DropTable(tableInfo.FullTempOutputTableName)).ConfigureAwait(false);
                    }
                }
            }
            finally
            {
                await context.Database.ExecuteSqlCommandAsync(SqlQueryBuilder.DropTable(tableInfo.FullTempTableName)).ConfigureAwait(false);
            }
        }


        private static DataTable GetDataTable<T>(DbContext context, TableInfo tableInfo, IList<T> entities)
        {
            var dataTable = new DataTable();
            var columnsDict = new Dictionary<string, object>();

            var type = typeof(T);
            var entityType = context.Model.FindEntityType(type);
            var entityPropertiesDict = entityType.GetProperties().ToDictionary(a => a.Name, a => a);
            var entityNavigationOwnedDict = entityType.GetNavigations().Where(a => a.GetTargetType().IsOwned()).ToDictionary(a => a.Name, a => a);
            var entityNavigationDict = entityType.GetNavigations().Where(a => a.GetTargetType().IsOwned() == false)
                .ToDictionary(a => a.Name, a => a);
            var properties2 = type.GetProperties().Where(a => !a.GetGetMethod().IsVirtual);

            var properties = new List<PropertyInfo>();
            var processed = new List<string>();

            // Se crean las columnas

            foreach (var prop in tableInfo.PropertyColumnNamesDict)
            {
                foreach (var propInfo in properties2)
                {

                    // Propiedades de la clase
                    if (prop.Key == propInfo.Name)
                    {
                        var propertyType = Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType;
                        dataTable.Columns.Add(prop.Key, propertyType);
                        properties.Add(propInfo);
                        break;
                    }

                    // Propiedades de Owned types
                    var found = false;
                    if (entityNavigationOwnedDict.ContainsKey(propInfo.PropertyType.Name))
                    {
                        var ownedProperties = propInfo.PropertyType.GetProperties();
                        foreach (var ownedProperty in ownedProperties)
                        {
                            if (prop.Key == ownedProperty.Name)
                            {
                                var propertyType = Nullable.GetUnderlyingType(ownedProperty.PropertyType) ??
                                                   ownedProperty.PropertyType;
                                dataTable.Columns.Add(propInfo.Name + "_" + ownedProperty.Name, propertyType);
                                properties.Add(ownedProperty);
                                found = true;
                                break;
                            }
                        }
                    }
                    if (found)
                        break;

                    // Propiedades de navegacion (shadow)
                    if (!processed.Contains(propInfo.Name))
                    {
                        processed.Add(propInfo.Name);

                        if (entityNavigationDict.ContainsKey(propInfo.Name))
                        {
                            var p2 = entityNavigationDict[propInfo.Name];
                            var navigationProperties = propInfo.PropertyType.GetProperties();

                            foreach (var navProp in navigationProperties)
                            {
                                if (propInfo.Name == p2.PropertyInfo.Name)
                                {
                                    var propertyType = Nullable.GetUnderlyingType(navProp.PropertyType) ??
                                                       navProp.PropertyType;

                                    var fk = p2.ForeignKey;

                                    dataTable.Columns.Add(fk.Properties[0].Name, propertyType);
                                    properties.Add(navProp);
                                    found = true;
                                    break;
                                }
                            }
                        }
                    }

                    if (found)
                        break;
                }
            }


            // Se cargan los datos

            var otherTypes = new Dictionary<Type, PropertyInfo[]>();

            foreach (var entity in entities)
            {
                for (var i = 0; i < properties.Count; i++)
                {

                    var property = properties[i];
                    var column = dataTable.Columns[0];

                    // Buscamos si es un campo de la clase original
                    if (entity.GetType() == property.ReflectedType)
                    {

                        var value = property.GetValue(entity, null);
                        if (entityPropertiesDict.ContainsKey(property.Name))
                        {
                            columnsDict[property.Name] = value;
                        }
                    }
                    else
                    {

                        var found = false;

                        // Buscamos si es un OwnedType
                        foreach (var navigationOwned in entityNavigationOwnedDict)
                        {
                            if (navigationOwned.Key == property.ReflectedType.Name)
                            {
                                if (!otherTypes.ContainsKey(property.ReflectedType))
                                {
                                    otherTypes.Add(property.ReflectedType, property.ReflectedType.GetProperties());
                                }

                                foreach (var ownedProperty in otherTypes[property.ReflectedType])
                                {
                                    if (ownedProperty.Name == property.Name)
                                    {
                                        var value = navigationOwned.Value.PropertyInfo.GetValue(entity);
                                        var value2 = property.GetValue(value);
                                        columnsDict[navigationOwned.Value.PropertyInfo.Name + "_" + property.Name] = value2;
                                        found = true;
                                        break;
                                    }
                                }
                            }
                        }

                        if (!found)
                        {


                            // Buscamos si es otro navigation property
                            foreach (var navigation in entityNavigationDict)
                            {
                                var fk = navigation.Value.ForeignKey;

                                if (fk.Properties[0].Name == column.ColumnName)
                                {
                                    if (!otherTypes.ContainsKey(property.ReflectedType))
                                        otherTypes.Add(property.ReflectedType, property.ReflectedType.GetProperties());

                                    foreach (var ownedProperty in otherTypes[property.ReflectedType])
                                    {
                                        if (ownedProperty.Name == property.Name)
                                        {
                                            var value = navigation.Value.PropertyInfo.GetValue(entity);
                                            object value2 = null;
                                            if (value != null)
                                            {
                                                value2 = property.GetValue(value);
                                            }

                                            columnsDict[column.ColumnName] = value2;
                                        }
                                    }
                                }
                            }
                        }

                    }
                }

                var record = columnsDict.Values.ToArray();
                dataTable.Rows.Add(record);
            }
            return dataTable;
        }

        private static SqlConnection OpenAndGetSqlConnection(DbContext context)
        {
            var connectionState = context.Database.GetDbConnection().State;
            if (connectionState != ConnectionState.Open)
            {
                context.Database.GetDbConnection().Open();
            }
            return context.Database.GetDbConnection() as SqlConnection;
        }

        private static async Task<SqlConnection> OpenAndGetSqlConnectionAsync(DbContext context)
        {
            if (context.Database.GetDbConnection().State != ConnectionState.Open)
            {
                await context.Database.GetDbConnection().OpenAsync().ConfigureAwait(false);
            }
            return context.Database.GetDbConnection() as SqlConnection;
        }

        private static SqlBulkCopy GetSqlBulkCopy(SqlConnection sqlConnection, IDbContextTransaction transaction, SqlBulkCopyOptions sqlBulkCopyOptions = SqlBulkCopyOptions.Default)
        {
            if (transaction == null)
            {
                return new SqlBulkCopy(sqlConnection, sqlBulkCopyOptions, null);
            }
            else
            {
                var sqlTransaction = (SqlTransaction)transaction.GetDbTransaction();
                return new SqlBulkCopy(sqlConnection, sqlBulkCopyOptions, sqlTransaction);
            }
        }
    }
}
