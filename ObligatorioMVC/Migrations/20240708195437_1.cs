using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ObligatorioMVC.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Responsables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sueldo = table.Column<double>(type: "float", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoMaquinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMaquinas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoRutinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoRutinas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoSocios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoSocios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreLocal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonoLocal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdResponsableLocal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locales_Responsables_IdResponsableLocal",
                        column: x => x.IdResponsableLocal,
                        principalTable: "Responsables",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ejercicios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTipoMaquina = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ejercicios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ejercicios_TipoMaquinas_IdTipoMaquina",
                        column: x => x.IdTipoMaquina,
                        principalTable: "TipoMaquinas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rutinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionRutina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTipoRutina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rutinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rutinas_TipoRutinas_IdTipoRutina",
                        column: x => x.IdTipoRutina,
                        principalTable: "TipoRutinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Maquinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrecioCompra = table.Column<double>(type: "float", nullable: false),
                    Disponibilidad = table.Column<bool>(type: "bit", nullable: false),
                    IdTipoMaquina = table.Column<int>(type: "int", nullable: true),
                    IdLocal = table.Column<int>(type: "int", nullable: false),
                    VidaUtil = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maquinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maquinas_Locales_IdLocal",
                        column: x => x.IdLocal,
                        principalTable: "Locales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Maquinas_TipoMaquinas_IdTipoMaquina",
                        column: x => x.IdTipoMaquina,
                        principalTable: "TipoMaquinas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Socios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLocal = table.Column<int>(type: "int", nullable: false),
                    IdTipoSocio = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Socios_Locales_IdLocal",
                        column: x => x.IdLocal,
                        principalTable: "Locales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Socios_TipoSocios_IdTipoSocio",
                        column: x => x.IdTipoSocio,
                        principalTable: "TipoSocios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RutinaEjercicios",
                columns: table => new
                {
                    IdRutina = table.Column<int>(type: "int", nullable: false),
                    IdEjercicio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RutinaEjercicios", x => new { x.IdRutina, x.IdEjercicio });
                    table.ForeignKey(
                        name: "FK_RutinaEjercicios_Ejercicios_IdEjercicio",
                        column: x => x.IdEjercicio,
                        principalTable: "Ejercicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RutinaEjercicios_Rutinas_IdRutina",
                        column: x => x.IdRutina,
                        principalTable: "Rutinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocioRutinas",
                columns: table => new
                {
                    IdSocio = table.Column<int>(type: "int", nullable: false),
                    IdRutina = table.Column<int>(type: "int", nullable: false),
                    Calificacion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocioRutinas", x => new { x.IdSocio, x.IdRutina });
                    table.ForeignKey(
                        name: "FK_SocioRutinas_Rutinas_IdRutina",
                        column: x => x.IdRutina,
                        principalTable: "Rutinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SocioRutinas_Socios_IdSocio",
                        column: x => x.IdSocio,
                        principalTable: "Socios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TipoMaquinas",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { 1, "Para realizar el ejercicio no se necesita una maquina en especifico", "Ninguna" },
                    { 2, "Permite caminar o correr en un lugar", "Caminadora" },
                    { 3, "Permite movilidad sin tener que salir al exterior.", "Bicicleta Estática" },
                    { 4, "Simula el movimiento de caminar, correr o subir escaleras.", "Elíptica" },
                    { 5, "Entrenamiento de fuerza que se enfoca específicamente en los cuádriceps, los glúteos y los isquiotibiales.", "Prensa de Pierna" },
                    { 6, "Entrenamiento de fuerza que se utiliza para trabajar los músculos aductores de las piernas.", "Máquina de Aductor" },
                    { 7, "Fortalecimiento de los músculos del pecho, los hombros y los tríceps.", "Press de Banca" },
                    { 8, "Ejercicios de aislamiento para los isquiotibiales.", "Máquina para Femorales" },
                    { 9, "Sostiene el agarre y tira hacia abajo, cruzando los brazos en el proceso.", "Poleas Cruzadas" },
                    { 10, "Máquina de pectoral.", "Peck Deck" },
                    { 11, "Simula el movimiento de remar, trabaja varios grupos musculares.", "Remo" },
                    { 12, "Simula el subir escaleras, fortaleciendo las piernas y el sistema cardiovascular.", "Escaladora" },
                    { 13, "Aparato multifuncional para entrenamiento de fuerza guiado.", "Máquina Smith" },
                    { 14, "Permite ejercitar los músculos de los gemelos.", "Máquina de Gemelos" },
                    { 15, "Diseñada para trabajar y fortalecer los músculos abdominales.", "Máquina de Abdominales" },
                    { 16, "Permite realizar diferentes ejercicios en una misma máquina.", "Multifuncional" },
                    { 17, "Diseñada para trabajar y fortalecer los músculos glúteos.", "Máquina de Glúteos" },
                    { 18, "Fortalecimiento de los hombros y los tríceps.", "Press Militar" },
                    { 19, "Ejercicios específicos para trabajar los pectorales.", "Máquina de Pecho" },
                    { 20, "Aparato para fortalecer y definir los músculos del tríceps.", "Máquina de Tríceps" },
                    { 21, "Diseñada para trabajar y fortalecer los bíceps.", "Máquina de Bíceps" },
                    { 22, "Permite ejercitar la musculatura de la espalda.", "Máquina de Espalda" },
                    { 23, "Aparato para fortalecer los músculos de los hombros.", "Máquina de Hombros" },
                    { 24, "Entrenamiento de fuerza para los músculos abductores de las piernas.", "Máquina de Abductores" },
                    { 25, "Ejercita y fortalece los músculos de las pantorrillas.", "Máquina de gemelos" },
                    { 26, "Fortalece la musculatura de la zona dorsal y lumbar, corrige la postura corporal.", "Máquina Dorsales" }
                });

            migrationBuilder.InsertData(
                table: "TipoRutinas",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Salud" },
                    { 2, "Competición amateur" },
                    { 3, "Competición profesional" }
                });

            migrationBuilder.InsertData(
                table: "TipoSocios",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Estandar" },
                    { 2, "Premium" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ejercicios_IdTipoMaquina",
                table: "Ejercicios",
                column: "IdTipoMaquina");

            migrationBuilder.CreateIndex(
                name: "IX_Locales_IdResponsableLocal",
                table: "Locales",
                column: "IdResponsableLocal",
                unique: true,
                filter: "[IdResponsableLocal] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Maquinas_IdLocal",
                table: "Maquinas",
                column: "IdLocal");

            migrationBuilder.CreateIndex(
                name: "IX_Maquinas_IdTipoMaquina",
                table: "Maquinas",
                column: "IdTipoMaquina");

            migrationBuilder.CreateIndex(
                name: "IX_RutinaEjercicios_IdEjercicio",
                table: "RutinaEjercicios",
                column: "IdEjercicio");

            migrationBuilder.CreateIndex(
                name: "IX_Rutinas_IdTipoRutina",
                table: "Rutinas",
                column: "IdTipoRutina");

            migrationBuilder.CreateIndex(
                name: "IX_SocioRutinas_IdRutina",
                table: "SocioRutinas",
                column: "IdRutina");

            migrationBuilder.CreateIndex(
                name: "IX_Socios_IdLocal",
                table: "Socios",
                column: "IdLocal");

            migrationBuilder.CreateIndex(
                name: "IX_Socios_IdTipoSocio",
                table: "Socios",
                column: "IdTipoSocio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Maquinas");

            migrationBuilder.DropTable(
                name: "RutinaEjercicios");

            migrationBuilder.DropTable(
                name: "SocioRutinas");

            migrationBuilder.DropTable(
                name: "Ejercicios");

            migrationBuilder.DropTable(
                name: "Rutinas");

            migrationBuilder.DropTable(
                name: "Socios");

            migrationBuilder.DropTable(
                name: "TipoMaquinas");

            migrationBuilder.DropTable(
                name: "TipoRutinas");

            migrationBuilder.DropTable(
                name: "Locales");

            migrationBuilder.DropTable(
                name: "TipoSocios");

            migrationBuilder.DropTable(
                name: "Responsables");
        }
    }
}
