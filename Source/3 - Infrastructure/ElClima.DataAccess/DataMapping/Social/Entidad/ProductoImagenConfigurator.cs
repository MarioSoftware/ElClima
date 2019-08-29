using Microsoft.EntityFrameworkCore;
using ElClima.Domain.Model.Models.Social.Entidades;
using System;

namespace ElClima.DataAccess.DataMapping.Social.Entidades
{
    internal static class ProductoImagenConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<ProductoImagen>(c =>
            {
                c.ToTable("ProductoImagen", "Entidades");

                c.Property<int>("id")
                .IsRequired()
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd();

                c.Property<string>("descripcion")
                   .IsRequired()
                   .HasColumnType("varchar(100)")
                   .IsRequired();

                c.Property<DateTime>("fechaHoraSubida")
                .IsRequired()
                .HasColumnType("Date");

            });

            // ForeingKey ProductoImagen-Producto
            modelBuilder.Entity<ProductoImagen>()
                .Property<int>("servicioId");
            modelBuilder.Entity<ProductoImagen>()
                .HasOne(c => c.producto);
             


        }
    }
}
