using ElClima.Domain.Model.Models.Social.Sujetos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.DataAccess.DataMapping.Social.Sujetos
{
    internal static class PersonaConfigurator
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>(p =>
            {
                p.ToTable("Persona", "Sujeto");

               p.Property<int>("id")
                .IsRequired()
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd();

                p.Property<string>("apellido")
                           .IsRequired()
                           .HasColumnType("varchar(60)");

                p.Property<string>("nombre")
                           .IsRequired()
                           .HasColumnType("varchar(60)");
                 
                p.Property<DateTime>("fechaNacimiento")
                       .IsRequired()
                       .HasColumnType("Date");                 

                p.Property<string>("dni")
                          .IsRequired()
                          .HasColumnType("varchar(15)");
            });

            modelBuilder.Entity<Persona>()
                .Property<int>("ubicacionId")
                .IsRequired();
            modelBuilder.Entity<Persona>()
                        .HasOne(c => c.ubicacion);

            modelBuilder.Entity<Persona>()
               .Property<int>("sexoId")
               .IsRequired();
            modelBuilder.Entity<Persona>()
                        .HasOne(c => c.sexo); 

            modelBuilder.Entity<Persona>()
              .HasIndex(c => c.dni)
              .IsUnique();

        }
    }
}
