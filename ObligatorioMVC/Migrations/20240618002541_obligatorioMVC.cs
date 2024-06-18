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
                    IdMaquina = table.Column<int>(type: "int", nullable: false)
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
                    FechaCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrecioCompra = table.Column<double>(type: "float", nullable: false),
                    Disponibilidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdLocal = table.Column<int>(type: "int", nullable: false),
                    IdTipoMaquina = table.Column<int>(type: "int", nullable: false),
                    VidaUtil = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maquina", x => x.IdMaquina);
                    table.ForeignKey(
                        name: "FK_Maquina_Local_IdLocal",
                        column: x => x.IdLocal,
                        principalTable: "Local",
                        principalColumn: "IdLocal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Maquina_TipoMaquina_IdTipoMaquina",
                        column: x => x.IdTipoMaquina,
                        principalTable: "TipoMaquina",
                        principalColumn: "idTipoMaquina",
                        onDelete: ReferentialAction.Cascade);
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
                    localIdLocal = table.Column<int>(type: "int", nullable: true),
                    TipoSocio = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_Local_localIdLocal",
                        column: x => x.localIdLocal,
                        principalTable: "Local",
                        principalColumn: "IdLocal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_TipoSocio_TipoSocio",
                        column: x => x.TipoSocio,
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
                name: "IX_Local_idResponsableLocal",
                table: "Local",
                column: "idResponsableLocal");

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
                name: "IX_Usuario_localIdLocal",
                table: "Usuario",
                column: "localIdLocal");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_TipoSocio",
                table: "Usuario",
                column: "TipoSocio");

            migrationBuilder.AddForeignKey(
                name: "FK_Local_Usuario_idResponsableLocal",
                table: "Local",
                column: "idResponsableLocal",
                principalTable: "Usuario",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Local_Usuario_idResponsableLocal",
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
