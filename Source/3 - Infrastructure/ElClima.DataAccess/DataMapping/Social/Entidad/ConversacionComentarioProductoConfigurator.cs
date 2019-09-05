using Microsoft.EntityFrameworkCore;
using ElClima.Domain.Model.Models.Social.Entidades;
using System;

namespace ElClima.DataAccess.DataMapping.Social.Entidades
{
    internal static class ConversacionComentarioProductoConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<ConversacionComentarioProducto>(c =>
            {
                c.ToTable("ConversacionComentarioProducto", "Entidad");

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
             
            modelBuilder.Entity<ConversacionComentarioProducto>()
                .Property<int>("personaId")
                .IsRequired();
            modelBuilder.Entity<ConversacionComentarioProducto>()
                .HasOne(c => c.persona);

            modelBuilder.Entity<ConversacionComentarioProducto>()
               .Property<int>("comentarioProductoId")
               .IsRequired();
            modelBuilder.Entity<ConversacionComentarioProducto>()
                .HasOne(c => c.comentario);
        }
    }
}
