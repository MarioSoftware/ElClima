﻿using ElClima.Domain.Model.Models.Social.Reporte.Historia;
using Microsoft.EntityFrameworkCore;
using System;

namespace ElClima.DataAccess.DataMapping.Social.Reporte.Historias
{
    internal static class ComentarioHistoriaConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comentario>(c => {
                c.ToTable("Comentario", "Historia");

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

            // ForeingKey Comentario-Historia
            modelBuilder.Entity<Comentario>()
                .Property<int>("historiaId")
            .IsRequired();
            modelBuilder.Entity<Comentario>()
                .HasOne(h => h.historia);

            // ForeingKey Comentario-Persona
            modelBuilder.Entity<Comentario>()
                .Property<int>("personaId")
            .IsRequired();
            modelBuilder.Entity<Comentario>()
                .HasOne(h => h.persona);
             
        }
    }
}
