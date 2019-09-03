using Microsoft.EntityFrameworkCore;
using ElClima.Domain.Model.Models.Social.Entidades;
using System;

namespace ElClima.DataAccess.DataMapping.Social.Entidades
{
    internal static class ProductoConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<Producto>(p =>
            {
                p.ToTable("Producto", "Entidad");

                p.Property<int>("id")
                .IsRequired()
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd();

                p.Property<string>("descripcion")
                   .IsRequired()
                   .HasColumnType("varchar(80)"); 

                p.Property<DateTime>("fechaHoraCrecion")
               .IsRequired()
               .HasColumnType("Date");

                p.Property<DateTime>("fechaHoraUltimaActualizacion")
               .IsRequired()
               .HasColumnType("Date");

                p.Property<decimal>("precio")
                    .HasColumnType("money");

                p.Property<bool>("disponible")
                  .IsRequired();

            });
             
            modelBuilder.Entity<Producto>()
                .Property<int>("lineaProductoId")
                .IsRequired();
            modelBuilder.Entity<Producto>()
                .HasOne(c => c.lineaProducto); 
        }
    }
}
