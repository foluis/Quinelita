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
                name: "Jornadas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false),
                    AbiertaAlPublico = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jornadas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ligas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ligas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposPuntuacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposPuntuacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    LigaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipos_Ligas",
                        column: x => x.LigaId,
                        principalTable: "Ligas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Partidos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JornadaId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    MostrarMarcadores = table.Column<bool>(nullable: false),
                    EquipoLocalId = table.Column<int>(nullable: false),
                    EquipoVisitanteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partidos_Equipos",
                        column: x => x.EquipoLocalId,
                        principalTable: "Equipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partidos_Equipos1",
                        column: x => x.EquipoVisitanteId,
                        principalTable: "Equipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partidos_Jornadas",
                        column: x => x.JornadaId,
                        principalTable: "Jornadas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuinelasJornada",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(nullable: false),
                    PartidoId = table.Column<int>(nullable: false),
                    GanadorId = table.Column<int>(nullable: true),
                    MarcadorLocal = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    MarcadorVisitante = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuinelasJornada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuinelasJornada_Equipos",
                        column: x => x.GanadorId,
                        principalTable: "Equipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuinelasJornada_Partidos",
                        column: x => x.PartidoId,
                        principalTable: "Partidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuinelasJornada_Usuarios",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResultadosJornada",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PartidoId = table.Column<int>(nullable: false),
                    GanadorId = table.Column<int>(nullable: true),
                    MarcadorLocal = table.Column<int>(nullable: true),
                    MarcadorVisitante = table.Column<int>(nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultadosJornada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResultadosJornada_Equipos",
                        column: x => x.GanadorId,
                        principalTable: "Equipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResultadosJornada_Partidos",
                        column: x => x.PartidoId,
                        principalTable: "Partidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResultadosQuinela",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(nullable: false),
                    PartidoId = table.Column<int>(nullable: false),
                    Puntos = table.Column<int>(nullable: false),
                    TipoPuntuacionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultadosQuinela", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResultadosQuinela_Partidos",
                        column: x => x.PartidoId,
                        principalTable: "Partidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResultadosQuinela_TiposPuntuacion",
                        column: x => x.TipoPuntuacionId,
                        principalTable: "TiposPuntuacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResultadosQuinela_Usuarios",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_LigaId",
                table: "Equipos",
                column: "LigaId");

            migrationBuilder.CreateIndex(
                name: "IX_PartidosJornada_EquipoLocalId",
                table: "Partidos",
                column: "EquipoLocalId");

            migrationBuilder.CreateIndex(
                name: "IX_PartidosJornada_EquipoVisitanteId",
                table: "Partidos",
                column: "EquipoVisitanteId");

            migrationBuilder.CreateIndex(
                name: "IX_PartidosJornada_JornadaId",
                table: "Partidos",
                column: "JornadaId");

            migrationBuilder.CreateIndex(
                name: "IX_QuinelasJornada_GanadorId",
                table: "QuinelasJornada",
                column: "GanadorId");

            migrationBuilder.CreateIndex(
                name: "IX_QuinelasJornada_PartidoId",
                table: "QuinelasJornada",
                column: "PartidoId");

            migrationBuilder.CreateIndex(
                name: "IX_QuinelasJornada_UsuarioId",
                table: "QuinelasJornada",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultadosJornada_GanadorId",
                table: "ResultadosJornada",
                column: "GanadorId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultadosJornada_PartidoId",
                table: "ResultadosJornada",
                column: "PartidoId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultadosQuinela_PartidoId",
                table: "ResultadosQuinela",
                column: "PartidoId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultadosQuinela_TipoPuntuacionId",
                table: "ResultadosQuinela",
                column: "TipoPuntuacionId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultadosQuinela_UsuarioId",
                table: "ResultadosQuinela",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuinelasJornada");

            migrationBuilder.DropTable(
                name: "ResultadosJornada");

            migrationBuilder.DropTable(
                name: "ResultadosQuinela");

            migrationBuilder.DropTable(
                name: "Partidos");

            migrationBuilder.DropTable(
                name: "TiposPuntuacion");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Equipos");

            migrationBuilder.DropTable(
                name: "Jornadas");

            migrationBuilder.DropTable(
                name: "Ligas");
        }
    }
}
