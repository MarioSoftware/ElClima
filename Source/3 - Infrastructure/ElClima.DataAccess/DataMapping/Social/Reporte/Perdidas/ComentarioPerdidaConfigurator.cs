using ElClima.Domain.Model.Models.Social.Reporte.Perdida;
using Microsoft.EntityFrameworkCore;
using System;

namespace ElClima.DataAccess.DataMapping.Social.Reporte.Perdidas
{
    internal static class ComentarioPerdidaConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comentario>(c => {
                c.ToTable("Comentario", "Reporte.Perdida");

                c.Property<int>("id")
                   .IsRequired()
                   .UseSqlServerIdentityColumn()
                   .ValueGeneratedOnAdd();

                c.Property<string>("comentario")
                    .IsRequired()
                    .HasColumnType("varchar(300)"); 

                c.Property<DateTime>("fechaHoraCreacion")
                   .IsRequired()
                   .HasColumnType("Date");

            });
             
            modelBuilder.Entity<Comentario>()
                .Property<int>("perdidaId")
            .IsRequired();
            modelBuilder.Entity<Comentario>()
                .HasOne(h => h.perdida);
             
            modelBuilder.Entity<Comentario>()
                .Property<int>("personaId")
            .IsRequired();
            modelBuilder.Entity<Comentario>()
                .HasOne(h => h.persona);

            modelBuilder.Entity<Comentario>()
              .Property<int>("ubicacionId");
            modelBuilder.Entity<Comentario>()
                .HasOne(h => h.ubicacion);
        }
    }
}
