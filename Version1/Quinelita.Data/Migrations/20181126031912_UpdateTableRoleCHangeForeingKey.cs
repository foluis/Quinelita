using Microsoft.EntityFrameworkCore.Migrations;

namespace Quinelita.Data.Migrations
{
    public partial class UpdateTableRoleCHangeForeingKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rol_Usuarios_UsuarioId1",
                table: "Rol");

            migrationBuilder.DropIndex(
                name: "IX_Rol_UsuarioId1",
                table: "Rol");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "Rol");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Rol",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.CreateIndex(
                name: "IX_Rol_UsuarioId",
                table: "Rol",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rol_Usuarios_UsuarioId",
                table: "Rol",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rol_Usuarios_UsuarioId",
                table: "Rol");

            migrationBuilder.DropIndex(
                name: "IX_Rol_UsuarioId",
                table: "Rol");

            migrationBuilder.AlterColumn<long>(
                name: "UsuarioId",
                table: "Rol",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId1",
                table: "Rol",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rol_UsuarioId1",
                table: "Rol",
                column: "UsuarioId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Rol_Usuarios_UsuarioId1",
                table: "Rol",
                column: "UsuarioId1",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
