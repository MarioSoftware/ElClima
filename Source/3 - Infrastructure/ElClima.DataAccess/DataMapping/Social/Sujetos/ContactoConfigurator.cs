using ElClima.Domain.Model.Models.Social.Sujetos;
using Microsoft.EntityFrameworkCore;

namespace ElClima.DataAccess.DataMapping.Social.Sujetos
{
    internal static class ContactoConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contacto>(r =>
            {
                r.ToTable("Contacto", "Sujeto");

                r.Property<int>("id")
                .IsRequired()
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd();

                r.Property<string>("contacto")
                .IsRequired()
                .HasColumnType("Varchar(30)"); 
            });

            modelBuilder.Entity<Contacto>()
            .Property<int>("contactoTipoId")
            .IsRequired();
            modelBuilder.Entity<Contacto>()
                        .HasOne(c => c.contactoTipo);


            modelBuilder.Entity<Contacto>()
            .Property<int>("personaId")
            .IsRequired();
            modelBuilder.Entity<Contacto>()
                        .HasOne(c => c.persona);
        }
    }
}
