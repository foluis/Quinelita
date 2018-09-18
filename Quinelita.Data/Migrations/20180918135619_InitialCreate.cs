using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quinelita.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jornada",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jornada", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Liga",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Liga", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    LigaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipo_Liga",
                        column: x => x.LigaId,
                        principalTable: "Liga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PartidosJornada",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PartidoId = table.Column<int>(nullable: false),
                    JornadaId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    MostrarMarcadores = table.Column<bool>(nullable: false),
                    EquipoLocalId = table.Column<int>(nullable: false),
                    EquipoVisitanteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartidosJornada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartidosJornada_Equipo",
                        column: x => x.EquipoLocalId,
                        principalTable: "Equipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PartidosJornada_Equipo1",
                        column: x => x.EquipoVisitanteId,
                        principalTable: "Equipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PartidosJornada_Jornada",
                        column: x => x.JornadaId,
                        principalTable: "Jornada",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_LigaId",
                table: "Equipo",
                column: "LigaId");

            migrationBuilder.CreateIndex(
                name: "IX_PartidosJornada_EquipoLocalId",
                table: "PartidosJornada",
                column: "EquipoLocalId");

            migrationBuilder.CreateIndex(
                name: "IX_PartidosJornada_EquipoVisitanteId",
                table: "PartidosJornada",
                column: "EquipoVisitanteId");

            migrationBuilder.CreateIndex(
                name: "IX_PartidosJornada_JornadaId",
                table: "PartidosJornada",
                column: "JornadaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartidosJornada");

            migrationBuilder.DropTable(
                name: "Equipo");

            migrationBuilder.DropTable(
                name: "Jornada");

            migrationBuilder.DropTable(
                name: "Liga");
        }
    }
}
