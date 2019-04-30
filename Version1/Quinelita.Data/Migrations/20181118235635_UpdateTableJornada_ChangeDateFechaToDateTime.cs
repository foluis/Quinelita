using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quinelita.Data.Migrations
{
    public partial class UpdateTableJornada_ChangeDateFechaToDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                table: "Jornadas",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                table: "Jornadas",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
