using ElClima.Domain.Model.Models.Social.Reporte.Perdida;
using Microsoft.EntityFrameworkCore;
using System;

namespace ElClima.DataAccess.DataMapping.Social.Reporte.Perdidas
{
    internal static class ImagenPerdidaConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImagenPerdida>(i =>
            {
                i.ToTable("ImagenPerdida", "Reporte.Perdida"); 

                i.Property<int>("id")
                .IsRequired()
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd();

                i.Property<string>("descripcion")
                    .IsRequired()
                    .HasColumnType("varchar(200)"); 

                i.Property<DateTime>("fechaHoraSubida")
                   .IsRequired()
                  .HasColumnType("Date");  

                i.Property<string>("imagen")
                   .IsRequired()
                   .HasColumnType("varchar(max)");

            });
             
            modelBuilder.Entity<ImagenPerdida>()
                .Property<int>("perdidaId")
                .IsRequired();
            modelBuilder.Entity<ImagenPerdida>()
                .HasOne(h => h.perdida);
              
        }
    }
}
