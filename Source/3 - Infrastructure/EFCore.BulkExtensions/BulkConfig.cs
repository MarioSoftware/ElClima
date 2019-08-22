using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EFCore.BulkExtensions
{
    public class BulkConfig
    {
        public bool PreserveInsertOrder { get; set; }

        public bool SetOutputIdentity { get; set; }

        public int BatchSize { get; set; }

        public int? NotifyAfter { get; set; }

        public int? BulkCopyTimeout { get; set; }

        public bool EnableStreaming { get; set; }

        public bool UseTempDb { get; set; }

        public bool WithHoldlock { get; set; }

        public List<string> PropertiesToInclude { get; set; }

        public List<string> PropertiesToExclude { get; set; }

        public List<string> UpdateByProperties { get; set; }

        public SqlBulkCopyOptions SqlBulkCopyOptions { get; set; }
    }
}
