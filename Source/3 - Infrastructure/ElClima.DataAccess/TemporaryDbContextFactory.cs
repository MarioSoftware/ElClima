using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ElClima.DataAccess
{
    public class TemporaryDbContextFactory : IDesignTimeDbContextFactory<ElClimaDbContext>
    {
        public ElClimaDbContext CreateDbContext(string[] args)
        {
            //var connectionStringFile = Environment.GetEnvironmentVariable("SINIE_CONN_STRING_FILE");
            //if (string.IsNullOrWhiteSpace(connectionStringFile))
            //    connectionStringFile = "connectionstrings.json";
            //var connStringConfig = new ConfigurationBuilder()
            //    .AddJsonFile(connectionStringFile)
            //    .Build();

            var connectionString = "Data Source=HYAMPEDERNERANB\\SQLEXPRESS; Initial Catalog=OperationalData; Integrated Security=True; Application Name=Sinie;MultipleActiveResultSets=true;";
            //var connectionString = connStringConfig.GetConnectionString("DefaultConnection");

            var builder = new DbContextOptionsBuilder<ElClimaDbContext>();
            builder.UseSqlServer(
                connectionString, optionsBuilder => optionsBuilder
                     .MigrationsAssembly(typeof(ElClimaDbContext).GetTypeInfo().Assembly.GetName().Name)
                    );
            return new ElClimaDbContext(builder.Options);
        }
    }
}
