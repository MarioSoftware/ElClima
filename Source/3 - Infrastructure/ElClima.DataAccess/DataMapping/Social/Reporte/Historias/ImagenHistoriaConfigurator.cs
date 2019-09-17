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
                i.ToTable("ImagenHistoria", "Reporte.Historia"); 

                i.Property<int>("id")
                .IsRequired()
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd();

                i.Property<string>("descripcion")
                    .IsRequired()
                    .HasColumnType("varchar(200)"); 

                i.Property<DateTime>("fechaHoraSubida")
                   .IsRequired()
                  .HasColumnType("Date"); 

                i.Property<bool>("aportada")
                   .IsRequired();

                i.Property<string>("imagen")
                   .IsRequired()
                   .HasColumnType("varchar(max)");

            });
             
            modelBuilder.Entity<ImagenHistoria>()
                .Property<int>("historiaId")
                .IsRequired();
            modelBuilder.Entity<ImagenHistoria>()
                .HasOne(h => h.historia);
             
            modelBuilder.Entity<ImagenHistoria>()
                .Property<int>("personaId")
                .IsRequired();
            modelBuilder.Entity<ImagenHistoria>()
                .HasOne(h => h.persona);
        }
    }
}
