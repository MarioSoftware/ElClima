using ElClima.Domain.Model.Models.Social.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.DataAccess.DataMapping.Social.Entidades
{
    internal static class ComentarioProductoConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComentarioProducto>(c =>
            {
                c.ToTable("ComentarioProducto", "Entidad");

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

             
            modelBuilder.Entity<ComentarioProducto>()
                       .Property<int>("productoId")
                       .IsRequired();
            modelBuilder.Entity<ComentarioProducto>()
                .HasOne(o => o.producto);
             
            modelBuilder.Entity<ComentarioProducto>()
                       .Property<int>("personaId")
                       .IsRequired();
            modelBuilder.Entity<ComentarioProducto>()
                .HasOne(o => o.persona);
             
            modelBuilder.Entity<ComentarioProducto>()
                       .Property<int>("tipoComentarioId")
                       .IsRequired();
            modelBuilder.Entity<ComentarioProducto>()
                .HasOne(o => o.tipoComentario); 

        }
    }
}
