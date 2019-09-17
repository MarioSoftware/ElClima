using ElClima.Domain.Model.Models.Social.Reporte.Perdida;
using Microsoft.EntityFrameworkCore;
using System; 

namespace ElClima.DataAccess.DataMapping.Social.Reporte.Perdidas
{
    internal static class ImagenConversacionConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConversacionImagen>(c => {
                c.ToTable("ImagenConversacion", "Reporte.Perdida");

                c.Property<int>("id")
                   .IsRequired()
                   .UseSqlServerIdentityColumn()
                   .ValueGeneratedOnAdd();

                c.Property<string>("descripcion")
                    .IsRequired()
                    .HasColumnType("varchar(300)"); 

                c.Property<DateTime>("fechaHoraSubida")
                   .IsRequired()
                   .HasColumnType("Date");

            });
             
            modelBuilder.Entity<ConversacionImagen>()
                .Property<int>("conversacionId")
                .IsRequired();
            modelBuilder.Entity<ConversacionImagen>()
                .HasOne(h => h.conversacion);              
             
        }
    }
}
