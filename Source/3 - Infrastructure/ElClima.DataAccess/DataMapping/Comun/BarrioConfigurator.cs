using ElClima.Domain.Model.Models.Comun;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.DataAccess.DataMapping.Comun
{
    internal static class BarrioConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Barrio>(e =>
            {
                e.ToTable("Barrio", "Comun");

                e.Property<int>("id")
                    .IsRequired()
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                e.Property<string>("nombre")
                    .IsRequired()
                    .HasColumnType("varchar(30)");
            });
             
            modelBuilder.Entity<Barrio>()
                .Property<int>("departamentoId")
                .IsRequired(); 
            modelBuilder.Entity<Barrio>()
                .HasOne(u => u.departamento);
        }
    }
}
