using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElClima.DataAccess.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Entidades");

            migrationBuilder.EnsureSchema(
                name: "Entidades.Enum");

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
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    apellido = table.Column<string>(nullable: true),
                    nombre = table.Column<string>(nullable: true),
                    dni = table.Column<string>(nullable: true),
                    fechaNacimiento = table.Column<DateTime>(nullable: false),
                    idDireccionNacimiento = table.Column<int>(nullable: false),
                    idDireccionActual = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.id);
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
                name: "TipoComentario",
                schema: "Entidades.Enum",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    detalle = table.Column<string>(type: "varchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoComentario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TipoEntidad",
                schema: "Entidades.Enum",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    detalle = table.Column<string>(type: "varchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEntidad", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TipoServicio",
                schema: "Entidades.Enum",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    detalle = table.Column<string>(type: "varchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoServicio", x => x.id);
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
                name: "Entidad",
                schema: "Entidades",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    tipoEntidadId = table.Column<int>(nullable: false),
                    descripcion = table.Column<string>(type: "varchar(70)", nullable: false),
                    fechaHoraCreacion = table.Column<DateTime>(type: "Date", nullable: false),
                    propietarioId = table.Column<int>(nullable: false),
                    creadorId = table.Column<int>(nullable: false),
                    ubicacionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entidad", x => x.id);
                    table.ForeignKey(
                        name: "FK_Entidad_Persona_creadorId",
                        column: x => x.creadorId,
                        principalTable: "Persona",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entidad_Persona_propietarioId",
                        column: x => x.propietarioId,
                        principalTable: "Persona",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entidad_TipoEntidad_tipoEntidadId",
                        column: x => x.tipoEntidadId,
                        principalSchema: "Entidades.Enum",
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
                name: "Servicio",
                schema: "Entidades",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    entidadId = table.Column<int>(nullable: false),
                    tipoServicioId = table.Column<int>(nullable: false),
                    descripcion = table.Column<string>(type: "varchar(80)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicio", x => x.id);
                    table.ForeignKey(
                        name: "FK_Servicio_Entidad_entidadId",
                        column: x => x.entidadId,
                        principalSchema: "Entidades",
                        principalTable: "Entidad",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Servicio_TipoServicio_tipoServicioId",
                        column: x => x.tipoServicioId,
                        principalSchema: "Entidades.Enum",
                        principalTable: "TipoServicio",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                schema: "Entidades",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    servicioId = table.Column<int>(nullable: false),
                    personaId = table.Column<int>(nullable: false),
                    tipoComentarioId = table.Column<int>(nullable: false),
                    fechaHoraCreacion = table.Column<DateTime>(type: "Date", nullable: false),
                    descripcion = table.Column<string>(type: "varchar(800)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.id);
                    table.ForeignKey(
                        name: "FK_Comentario_Persona_personaId",
                        column: x => x.personaId,
                        principalTable: "Persona",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comentario_Servicio_servicioId",
                        column: x => x.servicioId,
                        principalSchema: "Entidades",
                        principalTable: "Servicio",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comentario_TipoComentario_tipoComentarioId",
                        column: x => x.tipoComentarioId,
                        principalSchema: "Entidades.Enum",
                        principalTable: "TipoComentario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                schema: "Entidades",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    servicioId = table.Column<int>(nullable: false),
                    descripcion = table.Column<string>(type: "varchar(100)", nullable: false),
                    precio = table.Column<decimal>(type: "money", nullable: false),
                    disponible = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.id);
                    table.ForeignKey(
                        name: "FK_Producto_Servicio_servicioId",
                        column: x => x.servicioId,
                        principalSchema: "Entidades",
                        principalTable: "Servicio",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Conversacion",
                schema: "Entidades",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    comentarioId = table.Column<int>(nullable: false),
                    personaId = table.Column<int>(nullable: false),
                    fechaHoraCreacion = table.Column<DateTime>(type: "Date", nullable: false),
                    descripcion = table.Column<string>(type: "varchar(800)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversacion", x => x.id);
                    table.ForeignKey(
                        name: "FK_Conversacion_Comentario_comentarioId",
                        column: x => x.comentarioId,
                        principalSchema: "Entidades",
                        principalTable: "Comentario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Conversacion_Persona_personaId",
                        column: x => x.personaId,
                        principalTable: "Persona",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductoImagen",
                schema: "Entidades",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    productoid = table.Column<int>(nullable: true),
                    descripcion = table.Column<string>(type: "varchar(100)", nullable: false),
                    fechaHoraSubida = table.Column<DateTime>(type: "Date", nullable: false),
                    servicioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoImagen", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProductoImagen_Producto_productoid",
                        column: x => x.productoid,
                        principalSchema: "Entidades",
                        principalTable: "Producto",
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
                name: "IX_Comentario_personaId",
                schema: "Entidades",
                table: "Comentario",
                column: "personaId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_servicioId",
                schema: "Entidades",
                table: "Comentario",
                column: "servicioId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_tipoComentarioId",
                schema: "Entidades",
                table: "Comentario",
                column: "tipoComentarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversacion_comentarioId",
                schema: "Entidades",
                table: "Conversacion",
                column: "comentarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversacion_personaId",
                schema: "Entidades",
                table: "Conversacion",
                column: "personaId");

            migrationBuilder.CreateIndex(
                name: "IX_Entidad_creadorId",
                schema: "Entidades",
                table: "Entidad",
                column: "creadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Entidad_propietarioId",
                schema: "Entidades",
                table: "Entidad",
                column: "propietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Entidad_tipoEntidadId",
                schema: "Entidades",
                table: "Entidad",
                column: "tipoEntidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Entidad_ubicacionId",
                schema: "Entidades",
                table: "Entidad",
                column: "ubicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_servicioId",
                schema: "Entidades",
                table: "Producto",
                column: "servicioId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoImagen_productoid",
                schema: "Entidades",
                table: "ProductoImagen",
                column: "productoid");

            migrationBuilder.CreateIndex(
                name: "IX_Servicio_entidadId",
                schema: "Entidades",
                table: "Servicio",
                column: "entidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicio_tipoServicioId",
                schema: "Entidades",
                table: "Servicio",
                column: "tipoServicioId");
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
                name: "Conversacion",
                schema: "Entidades");

            migrationBuilder.DropTable(
                name: "ProductoImagen",
                schema: "Entidades");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Comentario",
                schema: "Entidades");

            migrationBuilder.DropTable(
                name: "Producto",
                schema: "Entidades");

            migrationBuilder.DropTable(
                name: "TipoComentario",
                schema: "Entidades.Enum");

            migrationBuilder.DropTable(
                name: "Servicio",
                schema: "Entidades");

            migrationBuilder.DropTable(
                name: "Entidad",
                schema: "Entidades");

            migrationBuilder.DropTable(
                name: "TipoServicio",
                schema: "Entidades.Enum");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "TipoEntidad",
                schema: "Entidades.Enum");

            migrationBuilder.DropTable(
                name: "Ubicacion");
        }
    }
}
