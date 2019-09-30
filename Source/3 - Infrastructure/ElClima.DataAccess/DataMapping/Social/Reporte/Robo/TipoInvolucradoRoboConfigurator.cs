﻿using Microsoft.EntityFrameworkCore;
using ElClima.Domain.Model.Models.Social.Reporte.Robo;

namespace ElClima.DataAccess.DataMapping.Social.Reporte.Robo
{
    internal static class TipoInvolucradoRoboConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TipoInvolucradoRobo>(c =>
            {
                c.ToTable("TipoInvolucradoRobo", "Reporte.Robo");

                c.Property<int>("id")
                    .IsRequired() 
                    .ValueGeneratedNever();

                c.Property<string>("detalle")
                    .IsRequired()
                    .HasColumnType("varchar(30)");
            }
             );
        }
    }
}
