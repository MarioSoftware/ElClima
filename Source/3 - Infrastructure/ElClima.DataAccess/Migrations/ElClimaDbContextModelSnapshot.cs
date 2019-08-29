﻿// <auto-generated />
using System;
using ElClima.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ElClima.DataAccess.Migrations
{
    [DbContext(typeof(ElClimaDbContext))]
    partial class ElClimaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ElClima.DataAccess.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ElClima.Domain.Model.Models.Social.Entidades.Comentario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PersonaId");

                    b.Property<int>("ServicioId");

                    b.Property<int>("TipoComentarioId");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("varchar(800)");

                    b.Property<DateTime>("fechaHoraCreacion")
                        .HasColumnType("Date");

                    b.HasKey("id");

                    b.HasIndex("PersonaId");

                    b.HasIndex("ServicioId");

                    b.HasIndex("TipoComentarioId");

                    b.ToTable("Comentario","Entidades");
                });

            modelBuilder.Entity("ElClima.Domain.Model.Models.Social.Entidades.Conversacion", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ComentarioId");

                    b.Property<int>("PersonaId");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("varchar(800)");

                    b.Property<DateTime>("fechaHoraCreacion")
                        .HasColumnType("Date");

                    b.HasKey("id");

                    b.HasIndex("ComentarioId");

                    b.HasIndex("PersonaId");

                    b.ToTable("Conversacion","Entidades");
                });

            modelBuilder.Entity("ElClima.Domain.Model.Models.Social.Entidades.Entidad", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TipoEntidadId");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("id");

                    b.HasIndex("TipoEntidadId");

                    b.ToTable("Entidad","Entidades");
                });

            modelBuilder.Entity("ElClima.Domain.Model.Models.Social.Entidades.Servicio", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EntidadId");

                    b.Property<int>("TipoServicioId");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.HasKey("id");

                    b.HasIndex("EntidadId");

                    b.HasIndex("TipoServicioId");

                    b.ToTable("Servicio","Entidades");
                });

            modelBuilder.Entity("ElClima.Domain.Model.Models.Social.Entidades.TipoComentario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("detalle");

                    b.HasKey("id");

                    b.ToTable("TipoComentario");
                });

            modelBuilder.Entity("ElClima.Domain.Model.Models.Social.Entidades.TipoEntidad", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("detalle");

                    b.HasKey("id");

                    b.ToTable("TipoEntidad");
                });

            modelBuilder.Entity("ElClima.Domain.Model.Models.Social.Entidades.TipoServicio", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("detalle");

                    b.HasKey("id");

                    b.ToTable("TipoServicio");
                });

            modelBuilder.Entity("ElClima.Domain.Model.Models.Social.Sujetos.Persona", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("apellido");

                    b.Property<string>("dni");

                    b.Property<DateTime>("fechaNacimiento");

                    b.Property<int>("idDireccionActual");

                    b.Property<int>("idDireccionNacimiento");

                    b.Property<string>("nombre");

                    b.HasKey("id");

                    b.ToTable("Persona");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ElClima.Domain.Model.Models.Social.Entidades.Comentario", b =>
                {
                    b.HasOne("ElClima.Domain.Model.Models.Social.Sujetos.Persona", "persona")
                        .WithMany()
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ElClima.Domain.Model.Models.Social.Entidades.Servicio", "servicio")
                        .WithMany()
                        .HasForeignKey("ServicioId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ElClima.Domain.Model.Models.Social.Entidades.TipoComentario", "tipoComentario")
                        .WithMany()
                        .HasForeignKey("TipoComentarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ElClima.Domain.Model.Models.Social.Entidades.Conversacion", b =>
                {
                    b.HasOne("ElClima.Domain.Model.Models.Social.Entidades.Comentario", "comentario")
                        .WithMany()
                        .HasForeignKey("ComentarioId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ElClima.Domain.Model.Models.Social.Sujetos.Persona", "persona")
                        .WithMany()
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ElClima.Domain.Model.Models.Social.Entidades.Entidad", b =>
                {
                    b.HasOne("ElClima.Domain.Model.Models.Social.Entidades.TipoEntidad", "tipoEntidad")
                        .WithMany()
                        .HasForeignKey("TipoEntidadId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ElClima.Domain.Model.Models.Social.Entidades.Servicio", b =>
                {
                    b.HasOne("ElClima.Domain.Model.Models.Social.Entidades.Entidad", "entidad")
                        .WithMany()
                        .HasForeignKey("EntidadId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ElClima.Domain.Model.Models.Social.Entidades.TipoServicio", "servicio")
                        .WithMany()
                        .HasForeignKey("TipoServicioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ElClima.DataAccess.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ElClima.DataAccess.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ElClima.DataAccess.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ElClima.DataAccess.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
