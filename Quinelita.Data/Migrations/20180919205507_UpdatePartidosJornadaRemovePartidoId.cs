using Microsoft.EntityFrameworkCore.Migrations;

namespace Quinelita.Data.Migrations
{
    public partial class UpdatePartidosJornadaRemovePartidoId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartidoId",
                table: "PartidosJornada");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PartidoId",
                table: "PartidosJornada",
                nullable: false,
                defaultValue: 0);
        }
    }
}
