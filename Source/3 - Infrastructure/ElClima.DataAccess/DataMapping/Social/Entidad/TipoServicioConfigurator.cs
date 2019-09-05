using Microsoft.EntityFrameworkCore;
using ElClima.Domain.Model.Models.Social.Entidades;
using System;

namespace ElClima.DataAccess.DataMapping.Social.Entidades
{
    internal static class TipoServicioConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TipoServicio>(c =>
            {
                c.ToTable("TipoServicio", "Entidad");

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
