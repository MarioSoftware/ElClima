using Microsoft.EntityFrameworkCore;
using ElClima.Domain.Model.Models.Social.Entidades;

namespace ElClima.DataAccess.DataMapping.Social.Entidades
{
    internal static class EntidadConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            //Entity Table
            modelBuilder.Entity<Entidad>(e =>
            {
                e.ToTable("Entidad", "Entidades");

                e.Property<int>("id")
                .IsRequired()
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd();

                e.Property<string>("descripcion")
                   .IsRequired()
                   .HasColumnType("varchar(50)");
            });
            // Creamos la ForeingKey Cliente-Calificacion
            modelBuilder.Entity<Entidad>()
                .Property<int>("TipoEntidadId");
            modelBuilder.Entity<Entidad>()
                .HasOne(c => c.tipoEntidad);
        }
    }
}
