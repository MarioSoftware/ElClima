using Microsoft.EntityFrameworkCore;
using ElClima.Domain.Model.Models.Social.Entidades;
using System;

namespace ElClima.DataAccess.DataMapping.Social.Entidades
{
    internal static class TipoEntidadConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TipoEntidad>(c =>
            {
                c.ToTable("TipoEntidad", "Entidad");

                c.Property<int>("id")
                    .IsRequired() 
                    .ValueGeneratedNever();

                c.Property<string>("detalle")
                    .IsRequired()
                    .HasColumnType("varchar(30)");
            }
             );
        }
    }
}
