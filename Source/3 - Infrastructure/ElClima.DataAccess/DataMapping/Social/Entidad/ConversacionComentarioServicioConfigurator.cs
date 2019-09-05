using Microsoft.EntityFrameworkCore;
using ElClima.Domain.Model.Models.Social.Entidades;
using System;

namespace ElClima.DataAccess.DataMapping.Social.Entidades
{
    internal static class ConversacionComentarioServicioConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<ConversacionComentarioServicio>(c =>
            {
                c.ToTable("ConversacionComentarioServicio", "Entidad");

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
             
            modelBuilder.Entity<ConversacionComentarioServicio>()
                .Property<int>("personaId")
                .IsRequired();
            modelBuilder.Entity<ConversacionComentarioServicio>()
                .HasOne(c => c.persona);

            modelBuilder.Entity<ConversacionComentarioServicio>()
               .Property<int>("comentarioServicioId")
               .IsRequired();
            modelBuilder.Entity<ConversacionComentarioServicio>()
                .HasOne(c => c.comentario);
        }
    }
}
