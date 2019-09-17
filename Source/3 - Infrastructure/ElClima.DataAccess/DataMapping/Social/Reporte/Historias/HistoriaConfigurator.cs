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
                h.ToTable("Historia", "Reporte.Historia");

                h.Property<int>("id")
                    .IsRequired() 
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                h.Property<string>("descripcion")
                    .IsRequired()
                    .HasColumnType("varchar(300)"); 

                h.Property<DateTime>("fechHoraCreada")
                   .IsRequired()
                   .HasColumnType("Date"); 

                h.Property<bool>("aportarImagen")
                   .IsRequired();

            });
             
            modelBuilder.Entity<Historia>()
                .Property<int>("ubicacionId")
                .IsRequired();
            modelBuilder.Entity<Historia>()
                .HasOne(h => h.ubicacion);
             
            modelBuilder.Entity<Historia>()
                .Property<int>("personaId")
                .IsRequired();
            modelBuilder.Entity<Historia>()
                .HasOne(h => h.persona);

       
        }
    }
}
