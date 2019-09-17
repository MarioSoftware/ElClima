using ElClima.Domain.Model.Models.Social.Reporte.Historia;
using ElClima.Domain.Model.Models.Social.Reporte.Perdida;
using Microsoft.EntityFrameworkCore;
using System;

namespace ElClima.DataAccess.DataMapping.Social.Reporte.Historias
{
    internal static class PerdidaConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Perdida>(p => {
                p.ToTable("Perdida", "Reporte.Perdida");

                p.Property<int>("id")
                    .IsRequired() 
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                p.Property<string>("descripcion")
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                p.Property<string>("informacionUtil") 
                    .HasColumnType("varchar(400)");

                p.Property<DateTime>("fechaHoraPerdida")
                   .IsRequired()
                   .HasColumnType("Date");

                p.Property<DateTime>("fechaHoraCreada")
                  .IsRequired()
                  .HasColumnType("Date");

                p.Property<bool>("encontrado")
                   .IsRequired();

            });
             
            modelBuilder.Entity<Perdida>()
                .Property<int>("personaId")
                .IsRequired();
            modelBuilder.Entity<Perdida>()
                .HasOne(h => h.persona);  
       
        }
    }
}
