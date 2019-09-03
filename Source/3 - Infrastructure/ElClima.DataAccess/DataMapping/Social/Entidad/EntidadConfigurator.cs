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
            modelBuilder.Entity<Entidad>(e =>
            {
                e.ToTable("Entidad", "Entidad");

                e.Property<int>("id")
                .IsRequired()
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd();

                e.Property<string>("nombre")
                   .IsRequired()
                   .HasColumnType("varchar(70)");

                e.Property<string>("descripcion")
                   .IsRequired()
                   .HasColumnType("varchar(200)");

                e.Property<string>("observacion")
                   .IsRequired()
                   .HasColumnType("varchar(2000)");

                e.Property<DateTime>("fechaHoraCreacion")
                   .IsRequired()
                   .HasColumnType("Date");
            });

             
            modelBuilder.Entity<Entidad>()
                       .Property<int>("tipoEntidadId")
                       .IsRequired();
            modelBuilder.Entity<Entidad>()
                .HasOne(o => o.tipoEntidad);
             
            modelBuilder.Entity<Entidad>()
                       .Property<int>("responsableId");
            modelBuilder.Entity<Entidad>()
                .HasOne(o => o.responsable);
             
            modelBuilder.Entity<Entidad>()
                       .Property<int>("creadorId")
                       .IsRequired();
            modelBuilder.Entity<Entidad>()
                .HasOne(o => o.creador);
             
            modelBuilder.Entity<Entidad>()
                       .Property<int>("ubicacionId")
                       .IsRequired();
            modelBuilder.Entity<Entidad>()
                .HasOne(o => o.ubicacion);

        }
    }
}
