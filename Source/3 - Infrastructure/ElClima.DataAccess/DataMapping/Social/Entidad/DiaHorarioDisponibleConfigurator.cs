using Microsoft.EntityFrameworkCore;
using ElClima.Domain.Model.Models.Social.Entidades;
using System;

namespace ElClima.DataAccess.DataMapping.Social.Entidades
{
    internal static class DiaHorarioDisponibleConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<DiaHorarioDisponible>(d =>
            {
                d.ToTable("DiaHorarioDisponible", "Entidad");

                d.Property<int>("id")
                .IsRequired()
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd();

                d.Property<string>("horaDesde")
                   .IsRequired()
                   .HasColumnType("varchar(10)");

                d.Property<string>("horaHasta")
                 .IsRequired()
                 .HasColumnType("varchar(10)");

                d.Property<string>("horaDesdeSegundoTurno") 
                 .HasColumnType("varchar(10)");

                d.Property<string>("horaHastaSegundoTurno") 
                 .HasColumnType("varchar(10)");
            });
             
            modelBuilder.Entity<DiaHorarioDisponible>()
                .Property<int>("entidadId")
                .IsRequired();
            modelBuilder.Entity<DiaHorarioDisponible>()
                .HasOne(c => c.entidad);

         
            modelBuilder.Entity<DiaHorarioDisponible>()
                .Property<int>("diaId")
            .IsRequired();
            modelBuilder.Entity<DiaHorarioDisponible>()
                .HasOne(c => c.dia); 

        }
    }
}
