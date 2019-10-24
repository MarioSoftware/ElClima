using ElClima.Domain.Model.Models.Social.Sujetos;
using Microsoft.EntityFrameworkCore;

namespace ElClima.DataAccess.DataMapping.Social.Sujetos
{
    internal static class OperacionRolConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OperacionRol>(r =>
            {
                r.ToTable("OperacionRol", "Personas");

                r.Property<int>("id")
                .IsRequired()
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd(); 
            });

            modelBuilder.Entity<OperacionRol>()
               .Property<int>("operacionId")
               .IsRequired();

            modelBuilder.Entity<OperacionRol>()
                .HasOne(u => u.operacion);

            modelBuilder.Entity<OperacionRol>()
             .Property<int>("rolId")
             .IsRequired();

            modelBuilder.Entity<OperacionRol>()
                .HasOne(u => u.rol);

            //Unique index
            modelBuilder.Entity<OperacionRol>()
                .HasIndex("operacionId", "rolId").IsUnique();
        }
    }
}
