using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ObligatorioMVC.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Responsable",
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
                    table.PrimaryKey("PK_Responsable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoMaquina",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMaquina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoRutina",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoRutina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoSocio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoSocio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Local",
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
                    table.PrimaryKey("PK_Local", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Local_Responsable_IdResponsableLocal",
                        column: x => x.IdResponsableLocal,
                        principalTable: "Responsable",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ejercicio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTipoMaquina = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ejercicio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ejercicio_TipoMaquina_IdTipoMaquina",
                        column: x => x.IdTipoMaquina,
                        principalTable: "TipoMaquina",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rutina",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionRutina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calificacion = table.Column<int>(type: "int", nullable: false),
                    IdTipoRutina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rutina", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rutina_TipoRutina_IdTipoRutina",
                        column: x => x.IdTipoRutina,
                        principalTable: "TipoRutina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Maquina",
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
                    table.PrimaryKey("PK_Maquina", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maquina_Local_IdLocal",
                        column: x => x.IdLocal,
                        principalTable: "Local",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Maquina_TipoMaquina_IdTipoMaquina",
                        column: x => x.IdTipoMaquina,
                        principalTable: "TipoMaquina",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Socio",
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
                    table.PrimaryKey("PK_Socio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Socio_Local_IdLocal",
                        column: x => x.IdLocal,
                        principalTable: "Local",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Socio_TipoSocio_IdTipoSocio",
                        column: x => x.IdTipoSocio,
                        principalTable: "TipoSocio",
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
                        name: "FK_RutinaEjercicios_Ejercicio_IdEjercicio",
                        column: x => x.IdEjercicio,
                        principalTable: "Ejercicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RutinaEjercicios_Rutina_IdRutina",
                        column: x => x.IdRutina,
                        principalTable: "Rutina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocioRutina",
                columns: table => new
                {
                    IdSocio = table.Column<int>(type: "int", nullable: false),
                    IdRutina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocioRutina", x => new { x.IdSocio, x.IdRutina });
                    table.ForeignKey(
                        name: "FK_SocioRutina_Rutina_IdRutina",
                        column: x => x.IdRutina,
                        principalTable: "Rutina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SocioRutina_Socio_IdSocio",
                        column: x => x.IdSocio,
                        principalTable: "Socio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TipoMaquina",
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
                table: "TipoRutina",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Salud" },
                    { 2, "Competición amateur" },
                    { 3, "Competición profesional" }
                });

            migrationBuilder.InsertData(
                table: "TipoSocio",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Estandar" },
                    { 2, "Premium" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ejercicio_IdTipoMaquina",
                table: "Ejercicio",
                column: "IdTipoMaquina");

            migrationBuilder.CreateIndex(
                name: "IX_Local_IdResponsableLocal",
                table: "Local",
                column: "IdResponsableLocal",
                unique: true,
                filter: "[IdResponsableLocal] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Maquina_IdLocal",
                table: "Maquina",
                column: "IdLocal");

            migrationBuilder.CreateIndex(
                name: "IX_Maquina_IdTipoMaquina",
                table: "Maquina",
                column: "IdTipoMaquina");

            migrationBuilder.CreateIndex(
                name: "IX_Rutina_IdTipoRutina",
                table: "Rutina",
                column: "IdTipoRutina");

            migrationBuilder.CreateIndex(
                name: "IX_RutinaEjercicios_IdEjercicio",
                table: "RutinaEjercicios",
                column: "IdEjercicio");

            migrationBuilder.CreateIndex(
                name: "IX_Socio_IdLocal",
                table: "Socio",
                column: "IdLocal");

            migrationBuilder.CreateIndex(
                name: "IX_Socio_IdTipoSocio",
                table: "Socio",
                column: "IdTipoSocio");

            migrationBuilder.CreateIndex(
                name: "IX_SocioRutina_IdRutina",
                table: "SocioRutina",
                column: "IdRutina");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Maquina");

            migrationBuilder.DropTable(
                name: "RutinaEjercicios");

            migrationBuilder.DropTable(
                name: "SocioRutina");

            migrationBuilder.DropTable(
                name: "Ejercicio");

            migrationBuilder.DropTable(
                name: "Rutina");

            migrationBuilder.DropTable(
                name: "Socio");

            migrationBuilder.DropTable(
                name: "TipoMaquina");

            migrationBuilder.DropTable(
                name: "TipoRutina");

            migrationBuilder.DropTable(
                name: "Local");

            migrationBuilder.DropTable(
                name: "TipoSocio");

            migrationBuilder.DropTable(
                name: "Responsable");
        }
    }
}
