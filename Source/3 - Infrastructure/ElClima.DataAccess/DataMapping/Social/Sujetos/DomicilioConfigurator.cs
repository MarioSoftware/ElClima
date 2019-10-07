using ElClima.Domain.Model.Models.Social.Sujetos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.DataAccess.DataMapping.Social.Sujetos
{
    internal static class DomicilioConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domicilio>(d =>
            {
                d.ToTable("Domicilio", "Sujeto");

                d.Property<int>("id")
                 .IsRequired()
                 .UseSqlServerIdentityColumn()
                 .ValueGeneratedOnAdd();

                d.Property<string>("calle")
                           .IsRequired()
                           .HasColumnType("varchar(100)");

                d.Property<int>("numero")
                  .HasMaxLength(5);

                d.Property<string>("barrio")
                           .IsRequired()
                           .HasColumnType("varchar(85)");

                d.Property<int>("piso")
                  .HasMaxLength(3);

                d.Property<string>("departamento") 
                          .HasColumnType("varchar(8)"); 

                d.Property<DateTime>("fechaHoraCreacion")
                      .IsRequired()
                      .HasColumnType("Date");

                d.Property<DateTime>("fechaHoraUltimaActualizacion")
                      .IsRequired()
                      .HasColumnType("Date");
            });

            modelBuilder.Entity<Domicilio>()
                .Property<int>("personaId")
                .IsRequired();
            modelBuilder.Entity<Domicilio>()
                     .HasOne(c => c.persona);

            modelBuilder.Entity<Domicilio>()
              .Property<int>("ubicacionId")
              .IsRequired();
            modelBuilder.Entity<Domicilio>()
                    .HasOne(c => c.ubicacionActual);

            modelBuilder.Entity<Domicilio>()
            .Property<int>("localidadId")
            .IsRequired();
            modelBuilder.Entity<Domicilio>()
                    .HasOne(c => c.localidad);

            modelBuilder.Entity<Domicilio>()
            .Property<int>("provinciaId")
            .IsRequired();
            modelBuilder.Entity<Domicilio>()
                    .HasOne(c => c.provincia); 
        }
    }
}
