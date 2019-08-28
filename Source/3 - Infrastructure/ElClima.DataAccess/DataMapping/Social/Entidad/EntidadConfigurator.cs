using Microsoft.EntityFrameworkCore;

namespace ElClima.DataAccess.DataMapping.Social.Entidad
{
    internal static class EntidadConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            //Entity Table
            modelBuilder.Entity<ElClima.Domain.Model.Models.Social.Entidades.Entidad>(e =>
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
            modelBuilder.Entity<ElClima.Domain.Model.Models.Social.Entidades.Entidad>()
                .Property<int>("TipoEntidadId");
            modelBuilder.Entity<ElClima.Domain.Model.Models.Social.Entidades.Entidad>()
                .HasOne(c => c.tipoEntidad);
        }
    }
}
