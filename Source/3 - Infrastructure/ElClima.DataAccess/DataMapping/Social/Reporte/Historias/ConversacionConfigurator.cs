using ElClima.Domain.Model.Models.Social.Reporte.Historia;
using Microsoft.EntityFrameworkCore;
using System; 

namespace ElClima.DataAccess.DataMapping.Social.Reporte.Historias
{
    internal static class ConversacionConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conversacion>(c => {
                c.ToTable("Conversacion", "Reporte.Historia");

                c.Property<int>("id")
                   .IsRequired()
                   .UseSqlServerIdentityColumn()
                   .ValueGeneratedOnAdd();

                c.Property<string>("descripcion")
                    .IsRequired()
                    .HasColumnType("varchar(300)"); 

                c.Property<DateTime>("fechaHoraCreado")
                   .IsRequired()
                   .HasColumnType("Date");

            });
             
            modelBuilder.Entity<Conversacion>()
                .Property<int>("comentarioId")
                .IsRequired();
            modelBuilder.Entity<Conversacion>()
                .HasOne(h => h.comentario);
             
            modelBuilder.Entity<Conversacion>()
                .Property<int>("personaId")
                .IsRequired();
            modelBuilder.Entity<Conversacion>()
                .HasOne(h => h.persona);
             
        }
    }
}
