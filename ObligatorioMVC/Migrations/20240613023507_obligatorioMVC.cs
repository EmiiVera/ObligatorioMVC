using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObligatorioMVC.Migrations
{
    /// <inheritdoc />
    public partial class obligatorioMVC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoMaquina",
                columns: table => new
                {
                    idTipoMaquina = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreTipoMaquina = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMaquina", x => x.idTipoMaquina);
                });

            migrationBuilder.CreateTable(
                name: "TipoRutina",
                columns: table => new
                {
                    IdTipoRutina = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    IdTipoMaquina = table.Column<int>(type: "int", nullable: false),
                    tipoMaquinaidTipoMaquina = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ejercicio", x => x.IdEjercicio);
                    table.ForeignKey(
                        name: "FK_Ejercicio_TipoMaquina_tipoMaquinaidTipoMaquina",
                        column: x => x.tipoMaquinaidTipoMaquina,
                        principalTable: "TipoMaquina",
                        principalColumn: "idTipoMaquina");
                });

            migrationBuilder.CreateTable(
                name: "Rutina",
                columns: table => new
                {
                    IdRutina = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Promedio = table.Column<double>(type: "float", nullable: true),
                    TipoRutinaIdTipoRutina = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rutina", x => x.IdRutina);
                    table.ForeignKey(
                        name: "FK_Rutina_TipoRutina_TipoRutinaIdTipoRutina",
                        column: x => x.TipoRutinaIdTipoRutina,
                        principalTable: "TipoRutina",
                        principalColumn: "IdTipoRutina");
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
                name: "Local",
                columns: table => new
                {
                    IdLocal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreLocal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonoLocal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idResponsableLocal = table.Column<int>(type: "int", nullable: false),
                    ResponsableLocalIdUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Local", x => x.IdLocal);
                });

            migrationBuilder.CreateTable(
                name: "Maquina",
                columns: table => new
                {
                    IdMaquina = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLocal = table.Column<int>(type: "int", nullable: false),
                    IdTipoMaquina = table.Column<int>(type: "int", nullable: false),
                    FechaCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrecioCompra = table.Column<double>(type: "float", nullable: false),
                    Disponibilidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoMaquinaidTipoMaquina = table.Column<int>(type: "int", nullable: true),
                    VidaUtil = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocalIdLocal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maquina", x => x.IdMaquina);
                    table.ForeignKey(
                        name: "FK_Maquina_Local_LocalIdLocal",
                        column: x => x.LocalIdLocal,
                        principalTable: "Local",
                        principalColumn: "IdLocal");
                    table.ForeignKey(
                        name: "FK_Maquina_TipoMaquina_TipoMaquinaidTipoMaquina",
                        column: x => x.TipoMaquinaidTipoMaquina,
                        principalTable: "TipoMaquina",
                        principalColumn: "idTipoMaquina");
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
                    IdLocal = table.Column<int>(type: "int", nullable: true),
                    tipoSocioIdTipoSocio = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_Local_IdLocal",
                        column: x => x.IdLocal,
                        principalTable: "Local",
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
                name: "IX_Ejercicio_tipoMaquinaidTipoMaquina",
                table: "Ejercicio",
                column: "tipoMaquinaidTipoMaquina");

            migrationBuilder.CreateIndex(
                name: "IX_Local_ResponsableLocalIdUsuario",
                table: "Local",
                column: "ResponsableLocalIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Maquina_LocalIdLocal",
                table: "Maquina",
                column: "LocalIdLocal");

            migrationBuilder.CreateIndex(
                name: "IX_Maquina_TipoMaquinaidTipoMaquina",
                table: "Maquina",
                column: "TipoMaquinaidTipoMaquina");

            migrationBuilder.CreateIndex(
                name: "IX_Rutina_TipoRutinaIdTipoRutina",
                table: "Rutina",
                column: "TipoRutinaIdTipoRutina");

            migrationBuilder.CreateIndex(
                name: "IX_rutinaEjercicios_IdEjercicio",
                table: "rutinaEjercicios",
                column: "IdEjercicio");

            migrationBuilder.CreateIndex(
                name: "IX_SocioRutina_idRutina",
                table: "SocioRutina",
                column: "idRutina");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdLocal",
                table: "Usuario",
                column: "IdLocal");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_tipoSocioIdTipoSocio",
                table: "Usuario",
                column: "tipoSocioIdTipoSocio");

            migrationBuilder.AddForeignKey(
                name: "FK_Local_Usuario_ResponsableLocalIdUsuario",
                table: "Local",
                column: "ResponsableLocalIdUsuario",
                principalTable: "Usuario",
                principalColumn: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Local_Usuario_ResponsableLocalIdUsuario",
                table: "Local");

            migrationBuilder.DropTable(
                name: "Maquina");

            migrationBuilder.DropTable(
                name: "rutinaEjercicios");

            migrationBuilder.DropTable(
                name: "SocioRutina");

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
                name: "Local");

            migrationBuilder.DropTable(
                name: "TipoSocio");
        }
    }
}
