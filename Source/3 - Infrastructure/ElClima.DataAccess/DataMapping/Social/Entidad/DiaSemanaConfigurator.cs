using Microsoft.EntityFrameworkCore;
using ElClima.Domain.Model.Models.Social.Entidades;
using System;

namespace ElClima.DataAccess.DataMapping.Social.Entidades
{
    internal static class DiaSemanaConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiaSemana>(d =>
            {
                d.ToTable("DiaSemana", "Entidad");

                d.Property<int>("id")
                    .IsRequired() 
                    .ValueGeneratedNever();

                d.Property<string>("detalle")
                    .IsRequired()
                    .HasColumnType("varchar(30)");
            }
         );
        }
    }
}
