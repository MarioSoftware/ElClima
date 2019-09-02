using ElClima.Domain.Model.Models.Social.Reporte.Historia;
using Microsoft.EntityFrameworkCore;
using System;

namespace ElClima.DataAccess.DataMapping.Social.Reporte.Historias
{
    internal static class ComentarioImagenConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComentarioImagen>(c => {
                c.ToTable("ComentarioImagen", "Historia");

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

            // ForeingKey ComentarioImagen-Imagen
            modelBuilder.Entity<ComentarioImagen>()
                .Property<int>("imagenId")
                .IsRequired();
            modelBuilder.Entity<ComentarioImagen>()
                .HasOne(h => h.imagen);

            // ForeingKey ComentarioImagen-Persona
            modelBuilder.Entity<ComentarioImagen>()
                .Property<int>("personaId")
                .IsRequired();
            modelBuilder.Entity<ComentarioImagen>()
                .HasOne(h => h.persona);
             
        }
    }
}
