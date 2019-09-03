using Microsoft.EntityFrameworkCore;
using ElClima.Domain.Model.Models.Social.Entidades;
using System;

namespace ElClima.DataAccess.DataMapping.Social.Entidades
{
    internal static class ProductoImagenConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<ProductoImagen>(p =>
            {
                p.ToTable("ProductoImagen", "Entidad");

                p.Property<int>("id")
                .IsRequired()
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd();

                p.Property<string>("descripcion") 
                   .HasColumnType("varchar(80)");

                p.Property<DateTime>("fechaHoraSubida")
                   .IsRequired()
                   .HasColumnType("Date");

                p.Property<string>("imagen")
                   .IsRequired()
                  .HasColumnType("varchar(max)");
            });
             
            modelBuilder.Entity<ProductoImagen>()
                .Property<int>("productoId")
                .IsRequired();
            modelBuilder.Entity<ProductoImagen>()
                .HasOne(c => c.producto);

        }
    }
}
