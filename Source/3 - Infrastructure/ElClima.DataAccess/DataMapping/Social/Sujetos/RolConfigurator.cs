using ElClima.Domain.Model.Models.Social.Sujetos;
using Microsoft.EntityFrameworkCore;

namespace ElClima.DataAccess.DataMapping.Social.Sujetos
{
    internal static class RolConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rol>(r =>
            {
                r.ToTable("Rol", "Personas");

                r.Property<int>("id")
                .IsRequired()
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd();

                r.Property<string>("detalle")
                .IsRequired()
                .HasColumnType("Varchar(30)");

                r.Property<bool>("esSuperUsuario")
                    .IsRequired(); 
            });
        }
    }
}
