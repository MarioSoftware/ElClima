using ElClima.Domain.Model.Models.Social.Reporte.Perdida;
using Microsoft.EntityFrameworkCore;
using System; 

namespace ElClima.DataAccess.DataMapping.Social.Reporte.Perdidas
{
    internal static class ImagenComentarioPerdida
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComentarioImagen>(c => {
                c.ToTable("ImagenComentario", "Reporte.Perdida");

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
             
            modelBuilder.Entity<ComentarioImagen>()
                .Property<int>("comentarioId")
                .IsRequired();
            modelBuilder.Entity<ComentarioImagen>()
                .HasOne(h => h.comentario);              
             
        }
    }
}
