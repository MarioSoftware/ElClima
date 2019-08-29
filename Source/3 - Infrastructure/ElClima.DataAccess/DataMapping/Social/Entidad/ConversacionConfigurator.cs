using Microsoft.EntityFrameworkCore;
using ElClima.Domain.Model.Models.Social.Entidades;
using System;

namespace ElClima.DataAccess.DataMapping.Social.Entidades
{
    internal static class ConversacionConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<Conversacion>(c =>
            {
                c.ToTable("Conversacion", "Entidades");

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
            // ForeingKey Conversacion-Comentario
            modelBuilder.Entity<Conversacion>()
                .Property<int>("ComentarioId");
            modelBuilder.Entity<Conversacion>()
                .HasOne(c => c.comentario);

            // ForeingKey Conversacion-Persona
            modelBuilder.Entity<Conversacion>()
                .Property<int>("PersonaId");
            modelBuilder.Entity<Conversacion>()
                .HasOne(c => c.persona); 

        }
    }
}
