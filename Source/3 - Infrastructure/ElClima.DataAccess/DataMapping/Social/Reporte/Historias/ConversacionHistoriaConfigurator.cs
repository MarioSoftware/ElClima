using ElClima.Domain.Model.Models.Social.Reporte.Historia;
using Microsoft.EntityFrameworkCore;
using System; 

namespace ElClima.DataAccess.DataMapping.Social.Reporte.Historias
{
    internal static class ConversacionHistoriaConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conversacion>(h => {
                h.ToTable("Conversacion", "Historias");

                h.Property<string>("descripcion")
                    .IsRequired()
                    .HasColumnType("varchar(300)"); 

                h.Property<DateTime>("fechaHoraCreado")
                   .IsRequired()
                   .HasColumnType("Date");

            });

            // ForeingKey Conversacion-Comentario
            modelBuilder.Entity<Conversacion>()
                .Property<int>("comentarioId");
            modelBuilder.Entity<Conversacion>()
                .HasOne(h => h.comentario);

            // ForeingKey Conversacion-Persona
            modelBuilder.Entity<Conversacion>()
                .Property<int>("personaId");
            modelBuilder.Entity<Conversacion>()
                .HasOne(h => h.persona);
             
        }
    }
}
