using ElClima.Domain.Model.Models.Social.Reporte.Perdida;
using Microsoft.EntityFrameworkCore;
using System; 

namespace ElClima.DataAccess.DataMapping.Social.Reporte.Perdidas
{
    internal static class UbicacionPerdidaConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UbicacionPerdida>(u => {
                u.ToTable("UbicacionPerdida", "Reporte.Perdida");

                u.Property<int>("id")
                   .IsRequired()
                   .UseSqlServerIdentityColumn()
                   .ValueGeneratedOnAdd();

                u.Property<string>("observacion")
                    .IsRequired()
                    .HasColumnType("varchar(500)"); 

                u.Property<DateTime>("fechaHoraCreacion")
                   .IsRequired()
                   .HasColumnType("Date");

                u.Property<string>("imagen")
                  .IsRequired()
                  .HasColumnType("varchar(max)");
            });
            modelBuilder.Entity<UbicacionPerdida>()
              .Property<int>("perdidaId")
              .IsRequired();
            modelBuilder.Entity<UbicacionPerdida>()
                .HasOne(h => h.perdida);

            modelBuilder.Entity<UbicacionPerdida>()
                .Property<int>("ubicacionPerdidaId")
                .IsRequired();
            modelBuilder.Entity<UbicacionPerdida>()
                .HasOne(h => h.ubicacionPerdida);              
             
        }
    }
}
