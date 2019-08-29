using Microsoft.EntityFrameworkCore;
using ElClima.Domain.Model.Models.Social.Entidades;
using System;

namespace ElClima.DataAccess.DataMapping.Social.Entidades
{
    internal static class ProductoConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<Producto>(c =>
            {
                c.ToTable("Producto", "Entidades");

                c.Property<int>("id")
                .IsRequired()
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd();

                c.Property<string>("descripcion")
                   .IsRequired()
                   .HasColumnType("varchar(100)")
                   .IsRequired();

                c.Property<decimal>("precio")
                    .HasColumnType("money")
                    .IsRequired();

                c.Property<bool>("disponible")
                   .IsRequired();
            });

            // ForeingKey Producto-Servicio
            modelBuilder.Entity<Producto>()
                .Property<int>("servicioId");
            modelBuilder.Entity<Producto>()
                .HasOne(c => c.servicio);
             


        }
    }
}
