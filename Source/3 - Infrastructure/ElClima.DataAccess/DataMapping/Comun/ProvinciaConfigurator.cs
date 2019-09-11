using ElClima.Domain.Model.Models.Comun;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.DataAccess.DataMapping.Comun
{
    internal static class ProvinciaConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Provincia>(p =>
            {
                p.ToTable("Provincia", "Comun");

                p.Property<int>("id")
                    .IsRequired()
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                p.Property<string>("nombre")
                    .IsRequired()
                    .HasColumnType("varchar(30)");
            });  
        }
    }
}
