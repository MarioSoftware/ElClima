using Microsoft.EntityFrameworkCore;
using ElClima.Domain.Model.Models.Social.Entidades;
using System;

namespace ElClima.DataAccess.DataMapping.Social.Entidades
{
    internal static class TipoServicioConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<TipoServicio>(t =>
            {
                t.ToTable("TipoServicio", "Entidades.Enum");

                t.Property<int>("id")
                     .IsRequired() 
                     .ValueGeneratedNever();

                t.Property<string>("detalle")
                    .IsRequired()
                    .HasColumnType("varchar(40)");
            }); 
        }
    }
}
