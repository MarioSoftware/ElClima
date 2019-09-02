using ElClima.Domain.Model.Models.Social.Reporte.Historia;
using Microsoft.EntityFrameworkCore;
using System;

namespace ElClima.DataAccess.DataMapping.Social.Reporte.Historias
{
    internal static class HistoriaConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Historia>(h => {
                h.ToTable("Historia", "Historias");

                h.Property<string>("descripcion")
                    .IsRequired()
                    .HasColumnType("varchar(300)"); 

                h.Property<DateTime>("fechHoraCreada")
                   .IsRequired()
                   .HasColumnType("Date");

            });

            // ForeingKey Historia-Ubicacion
            modelBuilder.Entity<Historia>()
                .Property<int>("ubicacionId");
            modelBuilder.Entity<Historia>()
                .HasOne(h => h.ubicacion);

            // ForeingKey Historia-Persona
            modelBuilder.Entity<Historia>()
                .Property<int>("personaId");
            modelBuilder.Entity<Historia>()
                .HasOne(h => h.persona);

       
        }
    }
}
