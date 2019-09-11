using ElClima.Domain.Model.Models.Comun;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.DataAccess.DataMapping.Comun
{
    internal static class SexoConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sexo>(s =>
            {
                s.ToTable("Sexo", "Comun");

                s.Property<int>("id")
                    .IsRequired() 
                    .ValueGeneratedNever();

                s.Property<string>("nombre")
                    .IsRequired()
                    .HasColumnType("varchar(30)");
            });  
        }
    }
}
