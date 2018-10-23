using Microsoft.EntityFrameworkCore.Migrations;

namespace Quinelita.Data.Migrations
{
    public partial class AgregarColumnaNombreEnTablaJornada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Jornadas",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Jornadas");
        }
    }
}
