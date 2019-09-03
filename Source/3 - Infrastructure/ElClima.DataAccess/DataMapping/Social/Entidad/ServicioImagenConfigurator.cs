using Microsoft.EntityFrameworkCore;
using ElClima.Domain.Model.Models.Social.Entidades;
using System;

namespace ElClima.DataAccess.DataMapping.Social.Entidades
{
    internal static class ServicioImagenConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<ServicioImagen>(s =>
            {
                s.ToTable("ServicioImagen", "Entidad");

                s.Property<int>("id")
                .IsRequired()
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd();

                s.Property<string>("descripcion") 
                   .HasColumnType("varchar(80)");

                s.Property<DateTime>("fechaHoraSubida")
                   .IsRequired()
                   .HasColumnType("Date");

                s.Property<string>("imagen")
                   .IsRequired()
                  .HasColumnType("varchar(max)");
            });
             
            modelBuilder.Entity<ServicioImagen>()
                .Property<int>("servicioId")
                .IsRequired();
            modelBuilder.Entity<ServicioImagen>()
                .HasOne(c => c.servicio);

          

        }
    }
}
