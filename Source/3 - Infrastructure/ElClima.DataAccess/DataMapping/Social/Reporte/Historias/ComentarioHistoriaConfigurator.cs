using ElClima.Domain.Model.Models.Social.Reporte.Historia;
using Microsoft.EntityFrameworkCore;
using System;

namespace ElClima.DataAccess.DataMapping.Social.Reporte.Historias
{
    internal static class ComentarioHistoriaConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comentario>(h => {
                h.ToTable("Comentario", "Historias");

                h.Property<string>("descripcion")
                    .IsRequired()
                    .HasColumnType("varchar(300)"); 

                h.Property<DateTime>("fechaHoraCreado")
                   .IsRequired()
                   .HasColumnType("Date");

            });

            // ForeingKey Comentario-Historia
            modelBuilder.Entity<Comentario>()
                .Property<int>("historiaId");
            modelBuilder.Entity<Comentario>()
                .HasOne(h => h.historia);

            // ForeingKey Comentario-Persona
            modelBuilder.Entity<Comentario>()
                .Property<int>("personaId");
            modelBuilder.Entity<Comentario>()
                .HasOne(h => h.persona);
             
        }
    }
}
