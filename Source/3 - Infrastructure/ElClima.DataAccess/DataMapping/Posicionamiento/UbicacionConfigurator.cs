using ElClima.Domain.Model.Models.Posicionamiento;
using Microsoft.EntityFrameworkCore;

namespace ElClima.DataAccess.DataMapping.Posicionamiento
{
    internal static class UbicacionConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ubicacion>(s =>
            {
                s.ToTable("Ubicacion", "Posicionamiento");

                s.Property<int>("id")
                    .IsRequired() 
                    .ValueGeneratedOnAdd();

                s.Property<string>("direccion")
                    .IsRequired()
                    .HasColumnType("varchar(150)");


                s.Property<string>("latitud")
                    .IsRequired()
                    .HasColumnType("varchar(30)");


                s.Property<string>("longitud")
                    .IsRequired()
                    .HasColumnType("varchar(30)");
            });  
        }
    }
}
