using Microsoft.EntityFrameworkCore;
using ElClima.Domain.Model.Models.Social.Entidades;
using System;

namespace ElClima.DataAccess.DataMapping.Social.Entidades
{
    internal static class ServicioConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<Servicio>(s =>
            {
                s.ToTable("Servicio", "Entidad");

                s.Property<int>("id")
                .IsRequired()
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd();

                s.Property<string>("descripcion")
                   .IsRequired()
                   .HasColumnType("varchar(80)");

                s.Property<string>("observacion") 
                  .HasColumnType("varchar(400)");

                s.Property<string>("foto")
                  .HasColumnType("varchar(max)");
            });
             
            modelBuilder.Entity<Servicio>()
                .Property<int>("entidadId")
                .IsRequired();
            modelBuilder.Entity<Servicio>()
                .HasOne(c => c.entidad);

         
            modelBuilder.Entity<Servicio>()
                .Property<int>("tipoServicioId")
            .IsRequired();
            modelBuilder.Entity<Servicio>()
                .HasOne(c => c.tipoServicio); 

        }
    }
}
