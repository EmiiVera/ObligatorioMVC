using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObligatorioMVC.Migrations
{
    /// <inheritdoc />
    public partial class Obligatorio_mvc1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisponibilidadMaquinas");

            migrationBuilder.AddColumn<int>(
                name: "IdDisponible",
                table: "Maquina",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Maquina_IdDisponible",
                table: "Maquina",
                column: "IdDisponible");

            migrationBuilder.AddForeignKey(
                name: "FK_Maquina_Disponibilidad_IdDisponible",
                table: "Maquina",
                column: "IdDisponible",
                principalTable: "Disponibilidad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maquina_Disponibilidad_IdDisponible",
                table: "Maquina");

            migrationBuilder.DropIndex(
                name: "IX_Maquina_IdDisponible",
                table: "Maquina");

            migrationBuilder.DropColumn(
                name: "IdDisponible",
                table: "Maquina");

            migrationBuilder.CreateTable(
                name: "DisponibilidadMaquinas",
                columns: table => new
                {
                    IdDisponibilidad = table.Column<int>(type: "int", nullable: false),
                    IdMaquina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisponibilidadMaquinas", x => new { x.IdDisponibilidad, x.IdMaquina });
                    table.ForeignKey(
                        name: "FK_DisponibilidadMaquinas_Disponibilidad_IdDisponibilidad",
                        column: x => x.IdDisponibilidad,
                        principalTable: "Disponibilidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisponibilidadMaquinas_Maquina_IdMaquina",
                        column: x => x.IdMaquina,
                        principalTable: "Maquina",
                        principalColumn: "IdMaquina",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DisponibilidadMaquinas_IdMaquina",
                table: "DisponibilidadMaquinas",
                column: "IdMaquina");
        }
    }
}
