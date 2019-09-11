using ElClima.Domain.Model.Models.Comun;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.DataAccess.DataMapping.Comun
{
    internal static class DepartamentoConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departamento>(e =>
            {
                e.ToTable("Departamento", "Comun");

                e.Property<int>("id")
                    .IsRequired()
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                e.Property<string>("nombre")
                    .IsRequired()
                    .HasColumnType("varchar(30)");
            });
             
            modelBuilder.Entity<Departamento>()
                .Property<int>("provinciaId")
                .IsRequired(); 
            modelBuilder.Entity<Departamento>()
                .HasOne(u => u.provincia);
        }
    }
}
