using Microsoft.EntityFrameworkCore;
using ElClima.Domain.Model.Models.Social.Entidades;
using System;

namespace ElClima.DataAccess.DataMapping.Social.Entidades
{
    internal static class LineaProductoConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<Servicio>(l =>
            {
                l.ToTable("LineaProducto", "Entidad");

                l.Property<int>("id")
                .IsRequired()
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd();

                l.Property<string>("descripcion")
                   .IsRequired()
                   .HasColumnType("varchar(80)");

                l.Property<string>("observacion") 
                  .HasColumnType("varchar(400)"); 

                l.Property<DateTime>("fechaHoraCreacion")
                 .IsRequired()
                 .HasColumnType("Date"); 

                l.Property<DateTime>("fechaHoraUltimaActualizacion")
                 .IsRequired()
                 .HasColumnType("Date");
            });
             
            modelBuilder.Entity<LineaProducto>()
                .Property<int>("servicioId")
                .IsRequired();
            modelBuilder.Entity<LineaProducto>()
                .HasOne(c => c.servicio);
             
        }
    }
}
