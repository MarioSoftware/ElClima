using Microsoft.EntityFrameworkCore;
using ElClima.Domain.Model.Models.Social.Entidades;
using System;

namespace ElClima.DataAccess.DataMapping.Social.Entidades
{
    internal static class TipoComentarioConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<TipoComentario>(t =>
            {
                t.ToTable("TipoComentario", "Entidades.Enum");

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
