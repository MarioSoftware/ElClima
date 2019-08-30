using ElClima.Domain.Model.Models.Social.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.DataAccess.DataMapping.Social.Entidades
{
    internal static class EntidadConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entidad>(c =>
            {
                c.ToTable("Entidad", "Entidades");

                c.Property<int>("id")
                .IsRequired()
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd();

                c.Property<string>("descripcion")
                   .IsRequired()
                   .HasColumnType("varchar(70)");

                c.Property<DateTime>("fechaHoraCreacion")
                   .IsRequired()
                   .HasColumnType("Date");
            });


            // ForeingKey Entidad-TipoEntidad
            modelBuilder.Entity<Entidad>()
                       .Property<int>("tipoEntidadId")
                       .IsRequired();
            modelBuilder.Entity<Entidad>()
                .HasOne(o => o.tipoEntidad);

            // ForeingKey Entidad-Persona propietaria
            modelBuilder.Entity<Entidad>()
                       .Property<int>("propietarioId")
                       .IsRequired();
            modelBuilder.Entity<Entidad>()
                .HasOne(o => o.propietario);

            // ForeingKey Entidad-Persona creadora
            modelBuilder.Entity<Entidad>()
                       .Property<int>("creadorId")
                       .IsRequired();
            modelBuilder.Entity<Entidad>()
                .HasOne(o => o.creador);

            // ForeingKey Entidad-Ubicacion
            modelBuilder.Entity<Entidad>()
                       .Property<int>("ubicacionId")
                       .IsRequired();
            modelBuilder.Entity<Entidad>()
                .HasOne(o => o.ubicacion);

        }
    }
}
