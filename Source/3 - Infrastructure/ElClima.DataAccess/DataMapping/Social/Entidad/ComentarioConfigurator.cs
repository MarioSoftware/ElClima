using Microsoft.EntityFrameworkCore;
using ElClima.Domain.Model.Models.Social.Entidades;
using System;

namespace ElClima.DataAccess.DataMapping.Social.Entidades
{
    internal static class ComentarioConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<Comentario>(c =>
            {
                c.ToTable("Comentario", "Entidades");

                c.Property<int>("id")
                .IsRequired()
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd();

                c.Property<string>("descripcion")
                   .IsRequired()
                   .HasColumnType("varchar(800)");

                c.Property<DateTime>("fechaHoraCreacion")
                   .IsRequired()
                   .HasColumnType("Date");
            });
            // ForeingKey Comentario-Servicio
            modelBuilder.Entity<Comentario>()
                .Property<int>("ServicioId");
            modelBuilder.Entity<Comentario>()
                .HasOne(c => c.servicio);

            // ForeingKey Comentario-TipoComentario
            modelBuilder.Entity<Comentario>()
                .Property<int>("TipoComentarioId");
            modelBuilder.Entity<Comentario>()
                .HasOne(c => c.tipoComentario);

                  // ForeingKey Comentario-Persona
            modelBuilder.Entity<Comentario>()
                .Property<int>("PersonaId");
            modelBuilder.Entity<Comentario>()
                .HasOne(c => c.persona);

        }
    }
}
