using ElClima.Domain.Model.Models.Comun;
using Microsoft.EntityFrameworkCore;

namespace ElClima.DataAccess.DataMapping.Comun
{
    internal static class ContactoTipoConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactoTipo>(s =>
            {
                s.ToTable("ContactoTipo", "Comun");

                s.Property<int>("id")
                    .IsRequired() 
                    .ValueGeneratedNever();

                s.Property<string>("contacto")
                    .IsRequired()
                    .HasColumnType("varchar(20)");
            });  
        }
    }
}
