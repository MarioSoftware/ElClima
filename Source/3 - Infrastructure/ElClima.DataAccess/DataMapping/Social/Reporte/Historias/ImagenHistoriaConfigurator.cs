using ElClima.Domain.Model.Models.Social.Reporte.Historia;
using Microsoft.EntityFrameworkCore;
using System;

namespace ElClima.DataAccess.DataMapping.Social.Reporte.Historias
{
    internal static class ImagenHistoriaConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImagenHistoria>(i =>
            {
                i.ToTable("ImagenHistoria", "Historias");

                i.Property<string>("descripcion")
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                i.Property<string>("observacion")
                   .HasColumnType("varchar(200)");

                i.Property<DateTime>("fechaHoraSubida")
                   .IsRequired()
                  .HasColumnType("Date"); 

                i.Property<bool>("contribucionExterna")
                   .IsRequired();

                i.Property<string>("imagen")
                   .IsRequired()
                   .HasColumnType("varchar(max)");

            });

            // ForeingKey ImagenHistoria-Historia
            modelBuilder.Entity<ImagenHistoria>()
                .Property<int>("historiaId");
            modelBuilder.Entity<ImagenHistoria>()
                .HasOne(h => h.historia);

            // ForeingKey ImagenHistoria-Persona
            modelBuilder.Entity<ImagenHistoria>()
                .Property<int>("personaId");
            modelBuilder.Entity<ImagenHistoria>()
                .HasOne(h => h.persona);
        }
    }
}
