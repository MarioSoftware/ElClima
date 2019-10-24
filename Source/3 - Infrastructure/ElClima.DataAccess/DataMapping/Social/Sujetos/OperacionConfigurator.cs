using ElClima.Domain.Model.Models.Social.Sujetos;
using Microsoft.EntityFrameworkCore;

namespace ElClima.DataAccess.DataMapping.Social.Sujetos
{
    internal static class OperacionConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Operacion>(r =>
            {
                r.ToTable("Operacion", "Personas");

                r.Property<int>("id")
                .IsRequired()
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd();

                r.Property<string>("nombre")
                .IsRequired()
                .HasColumnType("Varchar(70)");
 
            });
        }
    }
}
