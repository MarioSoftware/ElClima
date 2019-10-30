using ElClima.Domain.Model.Models.Comun;
using Microsoft.EntityFrameworkCore;

namespace ElClima.DataAccess.DataMapping.Comun
{
    internal static class LocalidadConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Localidad>(l =>
            {
                l.ToTable("Localidad", "Comun");

                l.Property<int>("id")
                    .IsRequired()
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                l.Property<string>("nombre")
                    .IsRequired()
                    .HasColumnType("varchar(70)");

                l.Property<string>("codigoPostal")
                   .HasColumnType("varchar(10)");
            });
             
            modelBuilder.Entity<Localidad>()
                .Property<int>("provinciaId")
                .IsRequired(); 
            modelBuilder.Entity<Localidad>()
                .HasOne(u => u.provincia);
        }
    }
}
