using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCore.BulkExtensions
{
    public static class SqlQueryBuilder
    {
        public static string CreateTableCopy(string existingTableName, string newTableName, TableInfo tableInfo, bool isOutputTable = false)
        {
            var columnsNames = (isOutputTable
                ? tableInfo.OutputPropertyColumnNamesDict
                : tableInfo.PropertyColumnNamesDict).Values.ToList();

            var q = $"SELECT TOP 0 {GetCommaSeparatedColumns(columnsNames, "T")} " +
                    $"INTO {newTableName} FROM {existingTableName} AS T " +
                    $"LEFT JOIN {existingTableName} AS Source ON 1 = 0;"; // removes Identity constrain
            return q;
        }

        public static string SelectFromOutputTable(TableInfo tableInfo)
        {
            var columnsNames = tableInfo.OutputPropertyColumnNamesDict.Values.ToList();
            var timeStampColumnNull = tableInfo.TimeStampColumn != null ? $", {tableInfo.TimeStampColumn} = NULL" : "";
            return $"SELECT {GetCommaSeparatedColumns(columnsNames)}{timeStampColumnNull} FROM {tableInfo.FullTempOutputTableName}";
        }

        public static string DropTable(string tableName)
        {
            return $"IF OBJECT_ID('{tableName}', 'U') IS NOT NULL DROP TABLE {tableName}";
        }

        public static string SelectIsIdentity(string tableName, string idColumnName)
        {
            return $"SELECT columnproperty(object_id('{tableName}'),'{idColumnName}','IsIdentity');";
        }

        public static string MergeTable(TableInfo tableInfo, OperationType operationType)
        {
            var targetTable = tableInfo.FullTableName;
            var sourceTable = tableInfo.FullTempTableName;
            var primaryKeys = tableInfo.PrimaryKeys.Select(k => tableInfo.PropertyColumnNamesDict[k]).ToList();
            var columnsNames = tableInfo.PropertyColumnNamesDict.Values.ToList();
            var outputColumnsNames = tableInfo.OutputPropertyColumnNamesDict.Values.ToList();
            var nonIdentityColumnsNames = columnsNames.Where(a => !primaryKeys.Contains(a)).ToList();
            var insertColumnsNames = tableInfo.HasIdentity ? nonIdentityColumnsNames : columnsNames;

            if (tableInfo.BulkConfig.PreserveInsertOrder)
            {
                sourceTable =
                    $"(SELECT TOP {tableInfo.NumberOfEntities} * FROM {sourceTable} ORDER BY {GetCommaSeparatedColumns(primaryKeys)})";
            }

            var textWithHoldlock = tableInfo.BulkConfig.WithHoldlock ? " WITH (HOLDLOCK)" : "";

            var q = $"MERGE {targetTable}{textWithHoldlock} AS T " +
                    $"USING {sourceTable} AS S " +
                    $"ON {GetAndSeparatedColumns(primaryKeys, "T", "S", tableInfo.UpdateByPropertiesAreNullable)}";

            if (operationType == OperationType.Insert || operationType == OperationType.InsertOrUpdate)
            {
                q += $" WHEN NOT MATCHED THEN INSERT ({GetCommaSeparatedColumns(insertColumnsNames)})" +
                     $" VALUES ({GetCommaSeparatedColumns(insertColumnsNames, "S")})";
            }
            if (operationType == OperationType.Update || (operationType == OperationType.InsertOrUpdate && nonIdentityColumnsNames.Count > 0))
            {
                q += $" WHEN MATCHED THEN UPDATE SET {GetCommaSeparatedColumns(nonIdentityColumnsNames, "T", "S")}";
            }
            if (operationType == OperationType.Delete)
            {
                q += " WHEN MATCHED THEN DELETE";
            }

            if (tableInfo.BulkConfig.SetOutputIdentity)
            {
                q += $" OUTPUT {GetCommaSeparatedColumns(outputColumnsNames, "INSERTED")}" +
                     $" INTO {tableInfo.FullTempOutputTableName}";
            }

            return q + ";";
        }

        private static string GetCommaSeparatedColumns(List<string> columnsNames, string prefixTable = null, string equalsTable = null)
        {
            var commaSeparatedColumns = "";
            foreach (var columnName in columnsNames)
            {
                commaSeparatedColumns += prefixTable != null ? $"{prefixTable}.[{columnName}]" : $"[{columnName}]";
                commaSeparatedColumns += equalsTable != null ? $" = {equalsTable}.[{columnName}]" : "";
                commaSeparatedColumns += ", ";
            }
            commaSeparatedColumns = commaSeparatedColumns.Remove(commaSeparatedColumns.Length - 2, 2); // removes last excess comma and space: ", "
            return commaSeparatedColumns;
        }

        private static string GetAndSeparatedColumns(List<string> columnsNames, string prefixTable = null, string equalsTable = null, bool updateByPropertiesAreNullable = false)
        {
            var commaSeparatedColumns = GetCommaSeparatedColumns(columnsNames, prefixTable, equalsTable);

            if (updateByPropertiesAreNullable)
            {
                var columns = commaSeparatedColumns.Split(',');
                var commaSeparatedColumnsNullable = string.Empty;
                foreach (var column in columns)
                {
                    var columnTs = column.Split('=');
                    var columnT = columnTs[0].Trim();
                    var columnS = columnTs[1].Trim();
                    var columnNullable = $"({column.Trim()} OR ({columnT} IS NULL AND {columnS} IS NULL))";
                    commaSeparatedColumnsNullable += columnNullable + ", ";
                }
                commaSeparatedColumnsNullable = commaSeparatedColumnsNullable.Remove(commaSeparatedColumnsNullable.Length - 2, 2);
                commaSeparatedColumns = commaSeparatedColumnsNullable;
            }

            var andSeparatedColumns = commaSeparatedColumns.Replace(",", " AND");
            return andSeparatedColumns;
        }
    }
}
