using ElClima.Domain.Model.Models.Social.Sujetos;
using Microsoft.EntityFrameworkCore;

namespace ElClima.DataAccess.DataMapping.Social.Sujetos
{
    internal static class RolPersonaConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RolPersona>(r =>
            {
                r.ToTable("RolPersona", "Personas");

                r.Property<int>("id")
                     .IsRequired() 
                     .UseSqlServerIdentityColumn()
                     .ValueGeneratedOnAdd(); 
            }); 

            modelBuilder.Entity<RolPersona>()
               .Property<int>("personaId")
               .IsRequired(); 

            modelBuilder.Entity<RolPersona>()
                .HasOne(u => u.persona);

            modelBuilder.Entity<RolPersona>()
               .Property<int>("rolId")
               .IsRequired();

            modelBuilder.Entity<RolPersona>()
          .HasOne(u => u.rol);
        }
    }
}
