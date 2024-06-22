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
            migrationBuilder.DropColumn(
                name: "Promedio",
                table: "Rutina");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Rutina",
                newName: "DescripcionRutina");

            migrationBuilder.AddColumn<int>(
                name: "Calificacion",
                table: "Rutina",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calificacion",
                table: "Rutina");

            migrationBuilder.RenameColumn(
                name: "DescripcionRutina",
                table: "Rutina",
                newName: "Descripcion");

            migrationBuilder.AddColumn<double>(
                name: "Promedio",
                table: "Rutina",
                type: "float",
                nullable: true);
        }
    }
}
