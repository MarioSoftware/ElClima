using ElClima.Domain.Model.Models.Social.Reporte.Historia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.DataAccess.DataMapping.Social.Reporte.Historias
{
    internal static class TipoHistoriaConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoHistoria>(t =>
            {
                t.ToTable("TipoHistoria", "Historias.Enum");

                t.Property<int>("id")
                     .IsRequired()
                     .ValueGeneratedNever();

                t.Property<string>("detalle")
                    .IsRequired()
                    .HasColumnType("varchar(40)");
            });
        }
    }
}
