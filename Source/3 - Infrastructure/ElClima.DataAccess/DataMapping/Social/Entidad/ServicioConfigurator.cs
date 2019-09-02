using Microsoft.EntityFrameworkCore;
using ElClima.Domain.Model.Models.Social.Entidades;
using System;

namespace ElClima.DataAccess.DataMapping.Social.Entidades
{
    internal static class ServicioConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<Servicio>(c =>
            {
                c.ToTable("Servicio", "Entidad");

                c.Property<int>("id")
                .IsRequired()
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd();

                c.Property<string>("descripcion")
                   .IsRequired()
                   .HasColumnType("varchar(80)"); 
            });

            // ForeingKey Servicio-Entidad
            modelBuilder.Entity<Servicio>()
                .Property<int>("entidadId")
                .IsRequired();
            modelBuilder.Entity<Servicio>()
                .HasOne(c => c.entidad);

            // ForeingKey Servicio-TipoServicio
            modelBuilder.Entity<Servicio>()
                .Property<int>("tipoServicioId")
            .IsRequired();
            modelBuilder.Entity<Servicio>()
                .HasOne(c => c.servicio);


        }
    }
}
