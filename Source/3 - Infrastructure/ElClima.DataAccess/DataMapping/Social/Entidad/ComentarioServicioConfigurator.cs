using ElClima.Domain.Model.Models.Social.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.DataAccess.DataMapping.Social.Entidades
{
    internal static class ComentarioServicioConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComentarioServicio>(c =>
            {
                c.ToTable("ComentarioServicio", "Entidad");

                c.Property<int>("id")
                .IsRequired()
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd();

                c.Property<string>("descripcion")
                   .IsRequired()
                   .HasColumnType("varchar(200)");
                
                c.Property<DateTime>("fechaHoraCreacion")
                   .IsRequired()
                   .HasColumnType("Date");

                c.Property<string>("imagen1") 
                  .HasColumnType("varchar(max)");

                c.Property<string>("imagen2") 
                 .HasColumnType("varchar(max)");

                c.Property<string>("imagen3") 
                 .HasColumnType("varchar(max)");
            });

             
            modelBuilder.Entity<ComentarioServicio>()
                       .Property<int>("servicioId")
                       .IsRequired();
            modelBuilder.Entity<ComentarioServicio>()
                .HasOne(o => o.servicio);
             
            modelBuilder.Entity<ComentarioServicio>()
                       .Property<int>("personaId")
                       .IsRequired();
            modelBuilder.Entity<ComentarioServicio>()
                .HasOne(o => o.persona);
             
            modelBuilder.Entity<ComentarioServicio>()
                       .Property<int>("tipoComentarioId")
                       .IsRequired();
            modelBuilder.Entity<ComentarioServicio>()
                .HasOne(o => o.tipoComentario); 

        }
    }
}
