using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObligatorioMVC.Migrations
{
    /// <inheritdoc />
    public partial class Obligatorio_mvc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disponibilidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disponibilidad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoMaquina",
                columns: table => new
                {
                    IdTipoMaquina = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTipoMaquina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMaquina", x => x.IdTipoMaquina);
                });

            migrationBuilder.CreateTable(
                name: "TipoRutina",
                columns: table => new
                {
                    IdTipoRutina = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTipoRutina = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoRutina", x => x.IdTipoRutina);
                });

            migrationBuilder.CreateTable(
                name: "TipoSocio",
                columns: table => new
                {
                    IdTipoSocio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTipoSocio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoSocio", x => x.IdTipoSocio);
                });

            migrationBuilder.CreateTable(
                name: "Ejercicio",
                columns: table => new
                {
                    IdEjercicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipoMaquina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ejercicio", x => x.IdEjercicio);
                    table.ForeignKey(
                        name: "FK_Ejercicio_TipoMaquina_IdTipoMaquina",
                        column: x => x.IdTipoMaquina,
                        principalTable: "TipoMaquina",
                        principalColumn: "IdTipoMaquina",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rutina",
                columns: table => new
                {
                    IdRutina = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Promedio = table.Column<double>(type: "float", nullable: true),
                    tipoRutina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rutina", x => x.IdRutina);
                    table.ForeignKey(
                        name: "FK_Rutina_TipoRutina_tipoRutina",
                        column: x => x.tipoRutina,
                        principalTable: "TipoRutina",
                        principalColumn: "IdTipoRutina",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rutinaEjercicios",
                columns: table => new
                {
                    IdRutina = table.Column<int>(type: "int", nullable: false),
                    IdEjercicio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rutinaEjercicios", x => new { x.IdRutina, x.IdEjercicio });
                    table.ForeignKey(
                        name: "FK_rutinaEjercicios_Ejercicio_IdEjercicio",
                        column: x => x.IdEjercicio,
                        principalTable: "Ejercicio",
                        principalColumn: "IdEjercicio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rutinaEjercicios_Rutina_IdRutina",
                        column: x => x.IdRutina,
                        principalTable: "Rutina",
                        principalColumn: "IdRutina",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locales",
                columns: table => new
                {
                    IdLocal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreLocal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonoLocal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdResponsableLocal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locales", x => x.IdLocal);
                });

            migrationBuilder.CreateTable(
                name: "Maquina",
                columns: table => new
                {
                    IdMaquina = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrecioCompra = table.Column<double>(type: "float", nullable: false),
                    IdDisponible = table.Column<int>(type: "int", nullable: false),
                    IdTipoMaquina = table.Column<int>(type: "int", nullable: true),
                    IdLocal = table.Column<int>(type: "int", nullable: true),
                    VidaUtil = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maquina", x => x.IdMaquina);
                    table.ForeignKey(
                        name: "FK_Maquina_Disponibilidad_IdDisponible",
                        column: x => x.IdDisponible,
                        principalTable: "Disponibilidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Maquina_Locales_IdLocal",
                        column: x => x.IdLocal,
                        principalTable: "Locales",
                        principalColumn: "IdLocal");
                    table.ForeignKey(
                        name: "FK_Maquina_TipoMaquina_IdTipoMaquina",
                        column: x => x.IdTipoMaquina,
                        principalTable: "TipoMaquina",
                        principalColumn: "IdTipoMaquina");
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonoUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    Sueldo = table.Column<double>(type: "float", nullable: true),
                    IdLocal = table.Column<int>(type: "int", nullable: true),
                    LocalesIdLocal = table.Column<int>(type: "int", nullable: true),
                    IdTipoSocio = table.Column<int>(type: "int", nullable: true),
                    tipoSocioIdTipoSocio = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_Locales_LocalesIdLocal",
                        column: x => x.LocalesIdLocal,
                        principalTable: "Locales",
                        principalColumn: "IdLocal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_TipoSocio_tipoSocioIdTipoSocio",
                        column: x => x.tipoSocioIdTipoSocio,
                        principalTable: "TipoSocio",
                        principalColumn: "IdTipoSocio");
                });

            migrationBuilder.CreateTable(
                name: "SocioRutina",
                columns: table => new
                {
                    idSocio = table.Column<int>(type: "int", nullable: false),
                    idRutina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocioRutina", x => new { x.idSocio, x.idRutina });
                    table.ForeignKey(
                        name: "FK_SocioRutina_Rutina_idRutina",
                        column: x => x.idRutina,
                        principalTable: "Rutina",
                        principalColumn: "IdRutina",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SocioRutina_Usuario_idSocio",
                        column: x => x.idSocio,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ejercicio_IdTipoMaquina",
                table: "Ejercicio",
                column: "IdTipoMaquina");

            migrationBuilder.CreateIndex(
                name: "IX_Locales_IdResponsableLocal",
                table: "Locales",
                column: "IdResponsableLocal",
                unique: true,
                filter: "[IdResponsableLocal] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Maquina_IdDisponible",
                table: "Maquina",
                column: "IdDisponible");

            migrationBuilder.CreateIndex(
                name: "IX_Maquina_IdLocal",
                table: "Maquina",
                column: "IdLocal");

            migrationBuilder.CreateIndex(
                name: "IX_Maquina_IdTipoMaquina",
                table: "Maquina",
                column: "IdTipoMaquina");

            migrationBuilder.CreateIndex(
                name: "IX_Rutina_tipoRutina",
                table: "Rutina",
                column: "tipoRutina");

            migrationBuilder.CreateIndex(
                name: "IX_rutinaEjercicios_IdEjercicio",
                table: "rutinaEjercicios",
                column: "IdEjercicio");

            migrationBuilder.CreateIndex(
                name: "IX_SocioRutina_idRutina",
                table: "SocioRutina",
                column: "idRutina");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_LocalesIdLocal",
                table: "Usuario",
                column: "LocalesIdLocal");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_tipoSocioIdTipoSocio",
                table: "Usuario",
                column: "tipoSocioIdTipoSocio");

            migrationBuilder.AddForeignKey(
                name: "FK_Locales_Usuario_IdResponsableLocal",
                table: "Locales",
                column: "IdResponsableLocal",
                principalTable: "Usuario",
                principalColumn: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locales_Usuario_IdResponsableLocal",
                table: "Locales");

            migrationBuilder.DropTable(
                name: "Maquina");

            migrationBuilder.DropTable(
                name: "rutinaEjercicios");

            migrationBuilder.DropTable(
                name: "SocioRutina");

            migrationBuilder.DropTable(
                name: "Disponibilidad");

            migrationBuilder.DropTable(
                name: "Ejercicio");

            migrationBuilder.DropTable(
                name: "Rutina");

            migrationBuilder.DropTable(
                name: "TipoMaquina");

            migrationBuilder.DropTable(
                name: "TipoRutina");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Locales");

            migrationBuilder.DropTable(
                name: "TipoSocio");
        }
    }
}
