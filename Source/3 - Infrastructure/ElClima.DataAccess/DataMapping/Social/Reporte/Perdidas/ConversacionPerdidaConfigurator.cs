using ElClima.Domain.Model.Models.Social.Reporte.Perdida;
using Microsoft.EntityFrameworkCore;
using System; 

namespace ElClima.DataAccess.DataMapping.Social.Reporte.Perdidas
{
    internal static class ConversacionPerdidaConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conversacion>(c => {
                c.ToTable("Conversacion", "Reporte.Perdida");

                c.Property<int>("id")
                   .IsRequired()
                   .UseSqlServerIdentityColumn()
                   .ValueGeneratedOnAdd();

                c.Property<string>("descripcion")
                    .IsRequired()
                    .HasColumnType("varchar(300)"); 

                c.Property<DateTime>("fechaHoraCreacion")
                   .IsRequired()
                   .HasColumnType("Date");

            });
             
            modelBuilder.Entity<Conversacion>()
                .Property<int>("personaId")
                .IsRequired();
            modelBuilder.Entity<Conversacion>()
                .HasOne(h => h.persona);
             
            modelBuilder.Entity<Conversacion>()
                .Property<int>("comentarioId")
                .IsRequired();
            modelBuilder.Entity<Conversacion>()
                .HasOne(h => h.comentario);
             
        }
    }
}
