using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElClima.DataAccess.Migrations
{
    public partial class InitialMigrationAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Comun");

            migrationBuilder.EnsureSchema(
                name: "Entidad");

            migrationBuilder.EnsureSchema(
                name: "Reporte.Historia");

            migrationBuilder.EnsureSchema(
                name: "Reporte.Perdida");

            migrationBuilder.EnsureSchema(
                name: "Reporte.Robo");

            migrationBuilder.EnsureSchema(
                name: "Sujeto");

            migrationBuilder.EnsureSchema(
                name: "Personas");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    dni = table.Column<string>(nullable: true),
                    apellido = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ubicacion",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    longitud = table.Column<string>(nullable: true),
                    latitud = table.Column<string>(nullable: true),
                    direccion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ubicacion", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ContactoTipo",
                schema: "Comun",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    nombre = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactoTipo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Provincia",
                schema: "Comun",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincia", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Sexo",
                schema: "Comun",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    nombre = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TipoVehiculo",
                schema: "Comun",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    nombre = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoVehiculo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DiaSemana",
                schema: "Entidad",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    detalle = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaSemana", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TipoComentario",
                schema: "Entidad",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    detalle = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoComentario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TipoEntidad",
                schema: "Entidad",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    detalle = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEntidad", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TipoServicio",
                schema: "Entidad",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    detalle = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoServicio", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Operacion",
                schema: "Personas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    nombre = table.Column<string>(type: "Varchar(70)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operacion", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                schema: "Personas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    detalle = table.Column<string>(type: "Varchar(30)", nullable: false),
                    esSuperUsuario = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MedioAsaltante",
                schema: "Reporte.Robo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    detalle = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedioAsaltante", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ObjetoRobado",
                schema: "Reporte.Robo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    detalle = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjetoRobado", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TipoInvolucradoRobo",
                schema: "Reporte.Robo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    detalle = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoInvolucradoRobo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Localidad",
                schema: "Comun",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(70)", nullable: false),
                    provinciaId = table.Column<int>(nullable: false),
                    codigoPostal = table.Column<string>(type: "varchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidad", x => x.id);
                    table.ForeignKey(
                        name: "FK_Localidad_Provincia_provinciaId",
                        column: x => x.provinciaId,
                        principalSchema: "Comun",
                        principalTable: "Provincia",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                schema: "Sujeto",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    apellido = table.Column<string>(type: "varchar(60)", nullable: false),
                    nombre = table.Column<string>(type: "varchar(60)", nullable: false),
                    dni = table.Column<string>(type: "varchar(15)", nullable: false),
                    alias = table.Column<string>(type: "varchar(45)", nullable: false),
                    fechaNacimiento = table.Column<DateTime>(type: "Date", nullable: false),
                    ubicacionId = table.Column<int>(nullable: false),
                    sexoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.id);
                    table.ForeignKey(
                        name: "FK_Persona_Sexo_sexoId",
                        column: x => x.sexoId,
                        principalSchema: "Comun",
                        principalTable: "Sexo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persona_Ubicacion_ubicacionId",
                        column: x => x.ubicacionId,
                        principalTable: "Ubicacion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OperacionRol",
                schema: "Personas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    operacionId = table.Column<int>(nullable: false),
                    rolId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperacionRol", x => x.id);
                    table.ForeignKey(
                        name: "FK_OperacionRol_Operacion_operacionId",
                        column: x => x.operacionId,
                        principalSchema: "Personas",
                        principalTable: "Operacion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OperacionRol_Rol_rolId",
                        column: x => x.rolId,
                        principalSchema: "Personas",
                        principalTable: "Rol",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Entidad",
                schema: "Entidad",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    tipoEntidadId = table.Column<int>(nullable: false),
                    nombre = table.Column<string>(type: "varchar(70)", nullable: false),
                    fechaHoraCreacion = table.Column<DateTime>(type: "Date", nullable: false),
                    descripcion = table.Column<string>(type: "varchar(200)", nullable: false),
                    creadorId = table.Column<int>(nullable: false),
                    ubicacionId = table.Column<int>(nullable: false),
                    responsableId = table.Column<int>(nullable: false),
                    observacion = table.Column<string>(type: "varchar(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entidad", x => x.id);
                    table.ForeignKey(
                        name: "FK_Entidad_Persona_creadorId",
                        column: x => x.creadorId,
                        principalSchema: "Sujeto",
                        principalTable: "Persona",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entidad_Persona_responsableId",
                        column: x => x.responsableId,
                        principalSchema: "Sujeto",
                        principalTable: "Persona",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entidad_TipoEntidad_tipoEntidadId",
                        column: x => x.tipoEntidadId,
                        principalSchema: "Entidad",
                        principalTable: "TipoEntidad",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entidad_Ubicacion_ubicacionId",
                        column: x => x.ubicacionId,
                        principalTable: "Ubicacion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolPersona",
                schema: "Personas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    personaId = table.Column<int>(nullable: false),
                    rolId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolPersona", x => x.id);
                    table.ForeignKey(
                        name: "FK_RolPersona_Persona_personaId",
                        column: x => x.personaId,
                        principalSchema: "Sujeto",
                        principalTable: "Persona",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolPersona_Rol_rolId",
                        column: x => x.rolId,
                        principalSchema: "Personas",
                        principalTable: "Rol",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Historia",
                schema: "Reporte.Historia",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(type: "varchar(300)", nullable: false),
                    ubicacionId = table.Column<int>(nullable: false),
                    fechHoraCreada = table.Column<DateTime>(type: "Date", nullable: false),
                    personaId = table.Column<int>(nullable: false),
                    aportarImagen = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historia", x => x.id);
                    table.ForeignKey(
                        name: "FK_Historia_Persona_personaId",
                        column: x => x.personaId,
                        principalSchema: "Sujeto",
                        principalTable: "Persona",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Historia_Ubicacion_ubicacionId",
                        column: x => x.ubicacionId,
                        principalTable: "Ubicacion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Perdida",
                schema: "Reporte.Perdida",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(type: "varchar(100)", nullable: false),
                    informacionUtil = table.Column<string>(type: "varchar(400)", nullable: true),
                    fechaHoraPerdida = table.Column<DateTime>(type: "Date", nullable: false),
                    fechaHoraCreada = table.Column<DateTime>(type: "Date", nullable: false),
                    personaId = table.Column<int>(nullable: false),
                    encontrado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perdida", x => x.id);
                    table.ForeignKey(
                        name: "FK_Perdida_Persona_personaId",
                        column: x => x.personaId,
                        principalSchema: "Sujeto",
                        principalTable: "Persona",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contacto",
                schema: "Sujeto",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    contactoTipoId = table.Column<int>(nullable: false),
                    personaId = table.Column<int>(nullable: false),
                    contacto = table.Column<string>(type: "Varchar(70)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacto", x => x.id);
                    table.ForeignKey(
                        name: "FK_Contacto_ContactoTipo_contactoTipoId",
                        column: x => x.contactoTipoId,
                        principalSchema: "Comun",
                        principalTable: "ContactoTipo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contacto_Persona_personaId",
                        column: x => x.personaId,
                        principalSchema: "Sujeto",
                        principalTable: "Persona",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Domicilio",
                schema: "Sujeto",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    personaId = table.Column<int>(nullable: false),
                    calle = table.Column<string>(type: "varchar(100)", nullable: false),
                    numero = table.Column<int>(maxLength: 5, nullable: true),
                    piso = table.Column<int>(maxLength: 3, nullable: true),
                    departamento = table.Column<string>(type: "varchar(8)", nullable: true),
                    provinciaId = table.Column<int>(nullable: false),
                    localidadId = table.Column<int>(nullable: false),
                    barrio = table.Column<string>(type: "varchar(85)", nullable: false),
                    fechaHoraCreacion = table.Column<DateTime>(type: "Date", nullable: false),
                    fechaHoraUltimaActualizacion = table.Column<DateTime>(type: "Date", nullable: false),
                    ubicacionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domicilio", x => x.id);
                    table.ForeignKey(
                        name: "FK_Domicilio_Localidad_localidadId",
                        column: x => x.localidadId,
                        principalSchema: "Comun",
                        principalTable: "Localidad",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Domicilio_Persona_personaId",
                        column: x => x.personaId,
                        principalSchema: "Sujeto",
                        principalTable: "Persona",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Domicilio_Provincia_provinciaId",
                        column: x => x.provinciaId,
                        principalSchema: "Comun",
                        principalTable: "Provincia",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Domicilio_Ubicacion_ubicacionId",
                        column: x => x.ubicacionId,
                        principalTable: "Ubicacion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DiaHorarioDisponible",
                schema: "Entidad",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    diaId = table.Column<int>(nullable: false),
                    entidadId = table.Column<int>(nullable: false),
                    horaDesde = table.Column<string>(type: "varchar(10)", nullable: false),
                    horaHasta = table.Column<string>(type: "varchar(10)", nullable: false),
                    horaDesdeSegundoTurno = table.Column<string>(type: "varchar(10)", nullable: true),
                    horaHastaSegundoTurno = table.Column<string>(type: "varchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaHorarioDisponible", x => x.id);
                    table.ForeignKey(
                        name: "FK_DiaHorarioDisponible_DiaSemana_diaId",
                        column: x => x.diaId,
                        principalSchema: "Entidad",
                        principalTable: "DiaSemana",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiaHorarioDisponible_Entidad_entidadId",
                        column: x => x.entidadId,
                        principalSchema: "Entidad",
                        principalTable: "Entidad",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LineaProducto",
                schema: "Entidad",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    entidadId = table.Column<int>(nullable: false),
                    tipoServicioId = table.Column<int>(nullable: false),
                    descripcion = table.Column<string>(type: "varchar(80)", nullable: false),
                    observacion = table.Column<string>(type: "varchar(400)", nullable: true),
                    foto = table.Column<string>(type: "varchar(max)", nullable: true),
                    fechaHoraCreacion = table.Column<DateTime>(type: "Date", nullable: false),
                    fechaHoraUltimaActualizacion = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineaProducto", x => x.id);
                    table.ForeignKey(
                        name: "FK_LineaProducto_Entidad_entidadId",
                        column: x => x.entidadId,
                        principalSchema: "Entidad",
                        principalTable: "Entidad",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LineaProducto_TipoServicio_tipoServicioId",
                        column: x => x.tipoServicioId,
                        principalSchema: "Entidad",
                        principalTable: "TipoServicio",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                schema: "Reporte.Historia",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    historiaId = table.Column<int>(nullable: false),
                    descripcion = table.Column<string>(type: "varchar(300)", nullable: false),
                    fechaHoraCreado = table.Column<DateTime>(type: "Date", nullable: false),
                    personaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.id);
                    table.ForeignKey(
                        name: "FK_Comentario_Historia_historiaId",
                        column: x => x.historiaId,
                        principalSchema: "Reporte.Historia",
                        principalTable: "Historia",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comentario_Persona_personaId",
                        column: x => x.personaId,
                        principalSchema: "Sujeto",
                        principalTable: "Persona",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImagenHistoria",
                schema: "Reporte.Historia",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(type: "varchar(200)", nullable: false),
                    historiaId = table.Column<int>(nullable: false),
                    fechaHoraSubida = table.Column<DateTime>(type: "Date", nullable: false),
                    personaId = table.Column<int>(nullable: false),
                    aportada = table.Column<bool>(nullable: false),
                    imagen = table.Column<string>(type: "varchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagenHistoria", x => x.id);
                    table.ForeignKey(
                        name: "FK_ImagenHistoria_Historia_historiaId",
                        column: x => x.historiaId,
                        principalSchema: "Reporte.Historia",
                        principalTable: "Historia",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImagenHistoria_Persona_personaId",
                        column: x => x.personaId,
                        principalSchema: "Sujeto",
                        principalTable: "Persona",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                schema: "Reporte.Perdida",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    perdidaId = table.Column<int>(nullable: false),
                    personaId = table.Column<int>(nullable: false),
                    comentario = table.Column<string>(type: "varchar(300)", nullable: false),
                    ubicacionId = table.Column<int>(nullable: false),
                    fechaHoraCreacion = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.id);
                    table.ForeignKey(
                        name: "FK_Comentario_Perdida_perdidaId",
                        column: x => x.perdidaId,
                        principalSchema: "Reporte.Perdida",
                        principalTable: "Perdida",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comentario_Persona_personaId",
                        column: x => x.personaId,
                        principalSchema: "Sujeto",
                        principalTable: "Persona",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comentario_Ubicacion_ubicacionId",
                        column: x => x.ubicacionId,
                        principalTable: "Ubicacion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImagenPerdida",
                schema: "Reporte.Perdida",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(type: "varchar(200)", nullable: false),
                    perdidaId = table.Column<int>(nullable: false),
                    fechaHoraSubida = table.Column<DateTime>(type: "Date", nullable: false),
                    imagen = table.Column<string>(type: "varchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagenPerdida", x => x.id);
                    table.ForeignKey(
                        name: "FK_ImagenPerdida_Perdida_perdidaId",
                        column: x => x.perdidaId,
                        principalSchema: "Reporte.Perdida",
                        principalTable: "Perdida",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UbicacionPerdida",
                schema: "Reporte.Perdida",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    perdidaId = table.Column<int>(nullable: false),
                    observacion = table.Column<string>(type: "varchar(500)", nullable: false),
                    imagen = table.Column<string>(type: "varchar(max)", nullable: false),
                    fechaHoraCreacion = table.Column<DateTime>(type: "Date", nullable: false),
                    ubicacionPerdidaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UbicacionPerdida", x => x.id);
                    table.ForeignKey(
                        name: "FK_UbicacionPerdida_Perdida_perdidaId",
                        column: x => x.perdidaId,
                        principalSchema: "Reporte.Perdida",
                        principalTable: "Perdida",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UbicacionPerdida_Ubicacion_ubicacionPerdidaId",
                        column: x => x.ubicacionPerdidaId,
                        principalTable: "Ubicacion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LineaProducto",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    servicioId = table.Column<int>(nullable: false),
                    descripcion = table.Column<string>(nullable: true),
                    fechaHoraCreacion = table.Column<DateTime>(nullable: false),
                    observacion = table.Column<string>(nullable: true),
                    fechaHoraUltimaActualizacion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineaProducto", x => x.id);
                    table.ForeignKey(
                        name: "FK_LineaProducto_LineaProducto_servicioId",
                        column: x => x.servicioId,
                        principalSchema: "Entidad",
                        principalTable: "LineaProducto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComentarioServicio",
                schema: "Entidad",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    servicioId = table.Column<int>(nullable: false),
                    personaId = table.Column<int>(nullable: false),
                    tipoComentarioId = table.Column<int>(nullable: false),
                    fechaHoraCreacion = table.Column<DateTime>(type: "Date", nullable: false),
                    descripcion = table.Column<string>(type: "varchar(200)", nullable: false),
                    imagen1 = table.Column<string>(type: "varchar(max)", nullable: true),
                    imagen2 = table.Column<string>(type: "varchar(max)", nullable: true),
                    imagen3 = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComentarioServicio", x => x.id);
                    table.ForeignKey(
                        name: "FK_ComentarioServicio_Persona_personaId",
                        column: x => x.personaId,
                        principalSchema: "Sujeto",
                        principalTable: "Persona",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComentarioServicio_LineaProducto_servicioId",
                        column: x => x.servicioId,
                        principalSchema: "Entidad",
                        principalTable: "LineaProducto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComentarioServicio_TipoComentario_tipoComentarioId",
                        column: x => x.tipoComentarioId,
                        principalSchema: "Entidad",
                        principalTable: "TipoComentario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServicioImagen",
                schema: "Entidad",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    servicioId = table.Column<int>(nullable: false),
                    descripcion = table.Column<string>(type: "varchar(80)", nullable: true),
                    fechaHoraSubida = table.Column<DateTime>(type: "Date", nullable: false),
                    imagen = table.Column<string>(type: "varchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicioImagen", x => x.id);
                    table.ForeignKey(
                        name: "FK_ServicioImagen_LineaProducto_servicioId",
                        column: x => x.servicioId,
                        principalSchema: "Entidad",
                        principalTable: "LineaProducto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Conversacion",
                schema: "Reporte.Historia",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    comentarioId = table.Column<int>(nullable: false),
                    descripcion = table.Column<string>(type: "varchar(300)", nullable: false),
                    fechaHoraCreado = table.Column<DateTime>(type: "Date", nullable: false),
                    personaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversacion", x => x.id);
                    table.ForeignKey(
                        name: "FK_Conversacion_Comentario_comentarioId",
                        column: x => x.comentarioId,
                        principalSchema: "Reporte.Historia",
                        principalTable: "Comentario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Conversacion_Persona_personaId",
                        column: x => x.personaId,
                        principalSchema: "Sujeto",
                        principalTable: "Persona",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComentarioImagen",
                schema: "Reporte.Historia",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    imagenId = table.Column<int>(nullable: false),
                    descripcion = table.Column<string>(type: "varchar(300)", nullable: false),
                    fechaHoraCreada = table.Column<DateTime>(nullable: false),
                    personaId = table.Column<int>(nullable: false),
                    fechaHoraCreado = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComentarioImagen", x => x.id);
                    table.ForeignKey(
                        name: "FK_ComentarioImagen_ImagenHistoria_imagenId",
                        column: x => x.imagenId,
                        principalSchema: "Reporte.Historia",
                        principalTable: "ImagenHistoria",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComentarioImagen_Persona_personaId",
                        column: x => x.personaId,
                        principalSchema: "Sujeto",
                        principalTable: "Persona",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Conversacion",
                schema: "Reporte.Perdida",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    comentarioId = table.Column<int>(nullable: false),
                    descripcion = table.Column<string>(type: "varchar(300)", nullable: false),
                    personaId = table.Column<int>(nullable: false),
                    fechaHoraCreacion = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversacion", x => x.id);
                    table.ForeignKey(
                        name: "FK_Conversacion_Comentario_comentarioId",
                        column: x => x.comentarioId,
                        principalSchema: "Reporte.Perdida",
                        principalTable: "Comentario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Conversacion_Persona_personaId",
                        column: x => x.personaId,
                        principalSchema: "Sujeto",
                        principalTable: "Persona",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImagenComentario",
                schema: "Reporte.Perdida",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    comentarioId = table.Column<int>(nullable: false),
                    fechaHoraSubida = table.Column<DateTime>(type: "Date", nullable: false),
                    descripcion = table.Column<string>(type: "varchar(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagenComentario", x => x.id);
                    table.ForeignKey(
                        name: "FK_ImagenComentario_Comentario_comentarioId",
                        column: x => x.comentarioId,
                        principalSchema: "Reporte.Perdida",
                        principalTable: "Comentario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                schema: "Entidad",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    lineaProductoId = table.Column<int>(nullable: false),
                    descripcion = table.Column<string>(type: "varchar(80)", nullable: false),
                    fechaHoraCrecion = table.Column<DateTime>(type: "Date", nullable: false),
                    precio = table.Column<decimal>(type: "money", nullable: false),
                    disponible = table.Column<bool>(nullable: false),
                    fechaHoraUltimaActualizacion = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.id);
                    table.ForeignKey(
                        name: "FK_Producto_LineaProducto_lineaProductoId",
                        column: x => x.lineaProductoId,
                        principalTable: "LineaProducto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConversacionComentarioServicio",
                schema: "Entidad",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    comentarioServicioId = table.Column<int>(nullable: false),
                    personaId = table.Column<int>(nullable: false),
                    fechaHoraCreacion = table.Column<DateTime>(type: "Date", nullable: false),
                    descripcion = table.Column<string>(type: "varchar(200)", nullable: false),
                    imagen1 = table.Column<string>(type: "varchar(max)", nullable: true),
                    imagen2 = table.Column<string>(type: "varchar(max)", nullable: true),
                    imagen3 = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversacionComentarioServicio", x => x.id);
                    table.ForeignKey(
                        name: "FK_ConversacionComentarioServicio_ComentarioServicio_comentarioServicioId",
                        column: x => x.comentarioServicioId,
                        principalSchema: "Entidad",
                        principalTable: "ComentarioServicio",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConversacionComentarioServicio_Persona_personaId",
                        column: x => x.personaId,
                        principalSchema: "Sujeto",
                        principalTable: "Persona",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImagenConversacion",
                schema: "Reporte.Perdida",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    conversacionId = table.Column<int>(nullable: false),
                    fechaHoraSubida = table.Column<DateTime>(type: "Date", nullable: false),
                    descripcion = table.Column<string>(type: "varchar(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagenConversacion", x => x.id);
                    table.ForeignKey(
                        name: "FK_ImagenConversacion_Conversacion_conversacionId",
                        column: x => x.conversacionId,
                        principalSchema: "Reporte.Perdida",
                        principalTable: "Conversacion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComentarioProducto",
                schema: "Entidad",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    productoId = table.Column<int>(nullable: false),
                    personaId = table.Column<int>(nullable: false),
                    tipoComentarioId = table.Column<int>(nullable: false),
                    fechaHoraCreacion = table.Column<DateTime>(type: "Date", nullable: false),
                    descripcion = table.Column<string>(type: "varchar(200)", nullable: false),
                    imagen1 = table.Column<string>(type: "varchar(max)", nullable: true),
                    imagen2 = table.Column<string>(type: "varchar(max)", nullable: true),
                    imagen3 = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComentarioProducto", x => x.id);
                    table.ForeignKey(
                        name: "FK_ComentarioProducto_Persona_personaId",
                        column: x => x.personaId,
                        principalSchema: "Sujeto",
                        principalTable: "Persona",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComentarioProducto_Producto_productoId",
                        column: x => x.productoId,
                        principalSchema: "Entidad",
                        principalTable: "Producto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComentarioProducto_TipoComentario_tipoComentarioId",
                        column: x => x.tipoComentarioId,
                        principalSchema: "Entidad",
                        principalTable: "TipoComentario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductoImagen",
                schema: "Entidad",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    productoId = table.Column<int>(nullable: false),
                    descripcion = table.Column<string>(type: "varchar(80)", nullable: true),
                    fechaHoraSubida = table.Column<DateTime>(type: "Date", nullable: false),
                    imagen = table.Column<string>(type: "varchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoImagen", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProductoImagen_Producto_productoId",
                        column: x => x.productoId,
                        principalSchema: "Entidad",
                        principalTable: "Producto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConversacionComentarioProducto",
                schema: "Entidad",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    comentarioProductoId = table.Column<int>(nullable: false),
                    personaId = table.Column<int>(nullable: false),
                    fechaHoraCreacion = table.Column<DateTime>(type: "Date", nullable: false),
                    descripcion = table.Column<string>(type: "varchar(200)", nullable: false),
                    imagen1 = table.Column<string>(type: "varchar(max)", nullable: true),
                    imagen2 = table.Column<string>(type: "varchar(max)", nullable: true),
                    imagen3 = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversacionComentarioProducto", x => x.id);
                    table.ForeignKey(
                        name: "FK_ConversacionComentarioProducto_ComentarioProducto_comentarioProductoId",
                        column: x => x.comentarioProductoId,
                        principalSchema: "Entidad",
                        principalTable: "ComentarioProducto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConversacionComentarioProducto_Persona_personaId",
                        column: x => x.personaId,
                        principalSchema: "Sujeto",
                        principalTable: "Persona",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LineaProducto_servicioId",
                table: "LineaProducto",
                column: "servicioId");

            migrationBuilder.CreateIndex(
                name: "IX_Localidad_provinciaId",
                schema: "Comun",
                table: "Localidad",
                column: "provinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioProducto_personaId",
                schema: "Entidad",
                table: "ComentarioProducto",
                column: "personaId");

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioProducto_productoId",
                schema: "Entidad",
                table: "ComentarioProducto",
                column: "productoId");

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioProducto_tipoComentarioId",
                schema: "Entidad",
                table: "ComentarioProducto",
                column: "tipoComentarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioServicio_personaId",
                schema: "Entidad",
                table: "ComentarioServicio",
                column: "personaId");

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioServicio_servicioId",
                schema: "Entidad",
                table: "ComentarioServicio",
                column: "servicioId");

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioServicio_tipoComentarioId",
                schema: "Entidad",
                table: "ComentarioServicio",
                column: "tipoComentarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ConversacionComentarioProducto_comentarioProductoId",
                schema: "Entidad",
                table: "ConversacionComentarioProducto",
                column: "comentarioProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConversacionComentarioProducto_personaId",
                schema: "Entidad",
                table: "ConversacionComentarioProducto",
                column: "personaId");

            migrationBuilder.CreateIndex(
                name: "IX_ConversacionComentarioServicio_comentarioServicioId",
                schema: "Entidad",
                table: "ConversacionComentarioServicio",
                column: "comentarioServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_ConversacionComentarioServicio_personaId",
                schema: "Entidad",
                table: "ConversacionComentarioServicio",
                column: "personaId");

            migrationBuilder.CreateIndex(
                name: "IX_DiaHorarioDisponible_diaId",
                schema: "Entidad",
                table: "DiaHorarioDisponible",
                column: "diaId");

            migrationBuilder.CreateIndex(
                name: "IX_DiaHorarioDisponible_entidadId",
                schema: "Entidad",
                table: "DiaHorarioDisponible",
                column: "entidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Entidad_creadorId",
                schema: "Entidad",
                table: "Entidad",
                column: "creadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Entidad_responsableId",
                schema: "Entidad",
                table: "Entidad",
                column: "responsableId");

            migrationBuilder.CreateIndex(
                name: "IX_Entidad_tipoEntidadId",
                schema: "Entidad",
                table: "Entidad",
                column: "tipoEntidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Entidad_ubicacionId",
                schema: "Entidad",
                table: "Entidad",
                column: "ubicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_LineaProducto_entidadId",
                schema: "Entidad",
                table: "LineaProducto",
                column: "entidadId");

            migrationBuilder.CreateIndex(
                name: "IX_LineaProducto_tipoServicioId",
                schema: "Entidad",
                table: "LineaProducto",
                column: "tipoServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_lineaProductoId",
                schema: "Entidad",
                table: "Producto",
                column: "lineaProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoImagen_productoId",
                schema: "Entidad",
                table: "ProductoImagen",
                column: "productoId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicioImagen_servicioId",
                schema: "Entidad",
                table: "ServicioImagen",
                column: "servicioId");

            migrationBuilder.CreateIndex(
                name: "IX_OperacionRol_rolId",
                schema: "Personas",
                table: "OperacionRol",
                column: "rolId");

            migrationBuilder.CreateIndex(
                name: "IX_OperacionRol_operacionId_rolId",
                schema: "Personas",
                table: "OperacionRol",
                columns: new[] { "operacionId", "rolId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolPersona_personaId",
                schema: "Personas",
                table: "RolPersona",
                column: "personaId");

            migrationBuilder.CreateIndex(
                name: "IX_RolPersona_rolId",
                schema: "Personas",
                table: "RolPersona",
                column: "rolId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_historiaId",
                schema: "Reporte.Historia",
                table: "Comentario",
                column: "historiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_personaId",
                schema: "Reporte.Historia",
                table: "Comentario",
                column: "personaId");

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioImagen_imagenId",
                schema: "Reporte.Historia",
                table: "ComentarioImagen",
                column: "imagenId");

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioImagen_personaId",
                schema: "Reporte.Historia",
                table: "ComentarioImagen",
                column: "personaId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversacion_comentarioId",
                schema: "Reporte.Historia",
                table: "Conversacion",
                column: "comentarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversacion_personaId",
                schema: "Reporte.Historia",
                table: "Conversacion",
                column: "personaId");

            migrationBuilder.CreateIndex(
                name: "IX_Historia_personaId",
                schema: "Reporte.Historia",
                table: "Historia",
                column: "personaId");

            migrationBuilder.CreateIndex(
                name: "IX_Historia_ubicacionId",
                schema: "Reporte.Historia",
                table: "Historia",
                column: "ubicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagenHistoria_historiaId",
                schema: "Reporte.Historia",
                table: "ImagenHistoria",
                column: "historiaId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagenHistoria_personaId",
                schema: "Reporte.Historia",
                table: "ImagenHistoria",
                column: "personaId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_perdidaId",
                schema: "Reporte.Perdida",
                table: "Comentario",
                column: "perdidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_personaId",
                schema: "Reporte.Perdida",
                table: "Comentario",
                column: "personaId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_ubicacionId",
                schema: "Reporte.Perdida",
                table: "Comentario",
                column: "ubicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversacion_comentarioId",
                schema: "Reporte.Perdida",
                table: "Conversacion",
                column: "comentarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversacion_personaId",
                schema: "Reporte.Perdida",
                table: "Conversacion",
                column: "personaId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagenComentario_comentarioId",
                schema: "Reporte.Perdida",
                table: "ImagenComentario",
                column: "comentarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagenConversacion_conversacionId",
                schema: "Reporte.Perdida",
                table: "ImagenConversacion",
                column: "conversacionId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagenPerdida_perdidaId",
                schema: "Reporte.Perdida",
                table: "ImagenPerdida",
                column: "perdidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Perdida_personaId",
                schema: "Reporte.Perdida",
                table: "Perdida",
                column: "personaId");

            migrationBuilder.CreateIndex(
                name: "IX_UbicacionPerdida_perdidaId",
                schema: "Reporte.Perdida",
                table: "UbicacionPerdida",
                column: "perdidaId");

            migrationBuilder.CreateIndex(
                name: "IX_UbicacionPerdida_ubicacionPerdidaId",
                schema: "Reporte.Perdida",
                table: "UbicacionPerdida",
                column: "ubicacionPerdidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacto_contactoTipoId",
                schema: "Sujeto",
                table: "Contacto",
                column: "contactoTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacto_personaId",
                schema: "Sujeto",
                table: "Contacto",
                column: "personaId");

            migrationBuilder.CreateIndex(
                name: "IX_Domicilio_localidadId",
                schema: "Sujeto",
                table: "Domicilio",
                column: "localidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Domicilio_personaId",
                schema: "Sujeto",
                table: "Domicilio",
                column: "personaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Domicilio_provinciaId",
                schema: "Sujeto",
                table: "Domicilio",
                column: "provinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Domicilio_ubicacionId",
                schema: "Sujeto",
                table: "Domicilio",
                column: "ubicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_dni",
                schema: "Sujeto",
                table: "Persona",
                column: "dni",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persona_sexoId",
                schema: "Sujeto",
                table: "Persona",
                column: "sexoId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_ubicacionId",
                schema: "Sujeto",
                table: "Persona",
                column: "ubicacionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "TipoVehiculo",
                schema: "Comun");

            migrationBuilder.DropTable(
                name: "ConversacionComentarioProducto",
                schema: "Entidad");

            migrationBuilder.DropTable(
                name: "ConversacionComentarioServicio",
                schema: "Entidad");

            migrationBuilder.DropTable(
                name: "DiaHorarioDisponible",
                schema: "Entidad");

            migrationBuilder.DropTable(
                name: "ProductoImagen",
                schema: "Entidad");

            migrationBuilder.DropTable(
                name: "ServicioImagen",
                schema: "Entidad");

            migrationBuilder.DropTable(
                name: "OperacionRol",
                schema: "Personas");

            migrationBuilder.DropTable(
                name: "RolPersona",
                schema: "Personas");

            migrationBuilder.DropTable(
                name: "ComentarioImagen",
                schema: "Reporte.Historia");

            migrationBuilder.DropTable(
                name: "Conversacion",
                schema: "Reporte.Historia");

            migrationBuilder.DropTable(
                name: "ImagenComentario",
                schema: "Reporte.Perdida");

            migrationBuilder.DropTable(
                name: "ImagenConversacion",
                schema: "Reporte.Perdida");

            migrationBuilder.DropTable(
                name: "ImagenPerdida",
                schema: "Reporte.Perdida");

            migrationBuilder.DropTable(
                name: "UbicacionPerdida",
                schema: "Reporte.Perdida");

            migrationBuilder.DropTable(
                name: "MedioAsaltante",
                schema: "Reporte.Robo");

            migrationBuilder.DropTable(
                name: "ObjetoRobado",
                schema: "Reporte.Robo");

            migrationBuilder.DropTable(
                name: "TipoInvolucradoRobo",
                schema: "Reporte.Robo");

            migrationBuilder.DropTable(
                name: "Contacto",
                schema: "Sujeto");

            migrationBuilder.DropTable(
                name: "Domicilio",
                schema: "Sujeto");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ComentarioProducto",
                schema: "Entidad");

            migrationBuilder.DropTable(
                name: "ComentarioServicio",
                schema: "Entidad");

            migrationBuilder.DropTable(
                name: "DiaSemana",
                schema: "Entidad");

            migrationBuilder.DropTable(
                name: "Operacion",
                schema: "Personas");

            migrationBuilder.DropTable(
                name: "Rol",
                schema: "Personas");

            migrationBuilder.DropTable(
                name: "ImagenHistoria",
                schema: "Reporte.Historia");

            migrationBuilder.DropTable(
                name: "Comentario",
                schema: "Reporte.Historia");

            migrationBuilder.DropTable(
                name: "Conversacion",
                schema: "Reporte.Perdida");

            migrationBuilder.DropTable(
                name: "ContactoTipo",
                schema: "Comun");

            migrationBuilder.DropTable(
                name: "Localidad",
                schema: "Comun");

            migrationBuilder.DropTable(
                name: "Producto",
                schema: "Entidad");

            migrationBuilder.DropTable(
                name: "TipoComentario",
                schema: "Entidad");

            migrationBuilder.DropTable(
                name: "Historia",
                schema: "Reporte.Historia");

            migrationBuilder.DropTable(
                name: "Comentario",
                schema: "Reporte.Perdida");

            migrationBuilder.DropTable(
                name: "Provincia",
                schema: "Comun");

            migrationBuilder.DropTable(
                name: "LineaProducto");

            migrationBuilder.DropTable(
                name: "Perdida",
                schema: "Reporte.Perdida");

            migrationBuilder.DropTable(
                name: "LineaProducto",
                schema: "Entidad");

            migrationBuilder.DropTable(
                name: "Entidad",
                schema: "Entidad");

            migrationBuilder.DropTable(
                name: "TipoServicio",
                schema: "Entidad");

            migrationBuilder.DropTable(
                name: "Persona",
                schema: "Sujeto");

            migrationBuilder.DropTable(
                name: "TipoEntidad",
                schema: "Entidad");

            migrationBuilder.DropTable(
                name: "Sexo",
                schema: "Comun");

            migrationBuilder.DropTable(
                name: "Ubicacion");
        }
    }
}
