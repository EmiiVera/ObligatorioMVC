using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObligatorioMVC.Migrations
{
    /// <inheritdoc />
    public partial class Obligatorio_mvc2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoRutinaIdTipoRutina",
                table: "Usuario",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_TipoRutinaIdTipoRutina",
                table: "Usuario",
                column: "TipoRutinaIdTipoRutina");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_TipoRutina_TipoRutinaIdTipoRutina",
                table: "Usuario",
                column: "TipoRutinaIdTipoRutina",
                principalTable: "TipoRutina",
                principalColumn: "IdTipoRutina");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_TipoRutina_TipoRutinaIdTipoRutina",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_TipoRutinaIdTipoRutina",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "TipoRutinaIdTipoRutina",
                table: "Usuario");
        }
    }
}
