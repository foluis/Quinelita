﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Quinelita.Data;

namespace Quinelita.Data.Migrations
{
    [DbContext(typeof(QuinelitaContext))]
    [Migration("20181023020716_AgregarColumnaNombreEnTablaJornada")]
    partial class AgregarColumnaNombreEnTablaJornada
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Quinelita.Data.Equipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LigaId");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("LigaId")
                        .HasName("IX_Equipo_LigaId");

                    b.ToTable("Equipos");
                });

            modelBuilder.Entity("Quinelita.Data.Jornada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("AbiertaAlPublico");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("date");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Jornadas");
                });

            modelBuilder.Entity("Quinelita.Data.Liga", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Ligas");
                });

            modelBuilder.Entity("Quinelita.Data.Partido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EquipoLocalId");

                    b.Property<int>("EquipoVisitanteId");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime");

                    b.Property<int>("JornadaId");

                    b.Property<bool>("MostrarMarcadores");

                    b.HasKey("Id");

                    b.HasIndex("EquipoLocalId")
                        .HasName("IX_PartidosJornada_EquipoLocalId");

                    b.HasIndex("EquipoVisitanteId")
                        .HasName("IX_PartidosJornada_EquipoVisitanteId");

                    b.HasIndex("JornadaId")
                        .HasName("IX_PartidosJornada_JornadaId");

                    b.ToTable("Partidos");
                });

            modelBuilder.Entity("Quinelita.Data.QuinelaJornada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime");

                    b.Property<int?>("GanadorId");

                    b.Property<int?>("MarcadorLocal")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<int?>("MarcadorVisitante")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<int>("PartidoId");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("GanadorId");

                    b.HasIndex("PartidoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("QuinelasJornada");
                });

            modelBuilder.Entity("Quinelita.Data.ResultadoJornada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime");

                    b.Property<int?>("GanadorId");

                    b.Property<int?>("MarcadorLocal");

                    b.Property<int?>("MarcadorVisitante");

                    b.Property<int>("PartidoId");

                    b.HasKey("Id");

                    b.HasIndex("GanadorId");

                    b.HasIndex("PartidoId");

                    b.ToTable("ResultadosJornada");
                });

            modelBuilder.Entity("Quinelita.Data.ResultadoQuinela", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PartidoId");

                    b.Property<int>("Puntos");

                    b.Property<int>("TipoPuntuacionId");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("PartidoId");

                    b.HasIndex("TipoPuntuacionId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("ResultadosQuinela");
                });

            modelBuilder.Entity("Quinelita.Data.TipoPuntuacion", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("TiposPuntuacion");
                });

            modelBuilder.Entity("Quinelita.Data.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Quinelita.Data.Equipo", b =>
                {
                    b.HasOne("Quinelita.Data.Liga", "Liga")
                        .WithMany("Equipos")
                        .HasForeignKey("LigaId")
                        .HasConstraintName("FK_Equipos_Ligas");
                });

            modelBuilder.Entity("Quinelita.Data.Partido", b =>
                {
                    b.HasOne("Quinelita.Data.Equipo", "EquipoLocal")
                        .WithMany("PartidosEquipoLocal")
                        .HasForeignKey("EquipoLocalId")
                        .HasConstraintName("FK_Partidos_Equipos");

                    b.HasOne("Quinelita.Data.Equipo", "EquipoVisitante")
                        .WithMany("PartidosEquipoVisitante")
                        .HasForeignKey("EquipoVisitanteId")
                        .HasConstraintName("FK_Partidos_Equipos1");

                    b.HasOne("Quinelita.Data.Jornada", "Jornada")
                        .WithMany("Partidos")
                        .HasForeignKey("JornadaId")
                        .HasConstraintName("FK_Partidos_Jornadas");
                });

            modelBuilder.Entity("Quinelita.Data.QuinelaJornada", b =>
                {
                    b.HasOne("Quinelita.Data.Equipo", "Ganador")
                        .WithMany("QuinelasJornada")
                        .HasForeignKey("GanadorId")
                        .HasConstraintName("FK_QuinelasJornada_Equipos");

                    b.HasOne("Quinelita.Data.Partido", "Partido")
                        .WithMany("QuinelasJornada")
                        .HasForeignKey("PartidoId")
                        .HasConstraintName("FK_QuinelasJornada_Partidos");

                    b.HasOne("Quinelita.Data.Usuario", "Usuario")
                        .WithMany("QuinelasJornada")
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("FK_QuinelasJornada_Usuarios");
                });

            modelBuilder.Entity("Quinelita.Data.ResultadoJornada", b =>
                {
                    b.HasOne("Quinelita.Data.Equipo", "Ganador")
                        .WithMany("ResultadosJornada")
                        .HasForeignKey("GanadorId")
                        .HasConstraintName("FK_ResultadosJornada_Equipos");

                    b.HasOne("Quinelita.Data.Partido", "Partido")
                        .WithMany("ResultadosJornada")
                        .HasForeignKey("PartidoId")
                        .HasConstraintName("FK_ResultadosJornada_Partidos");
                });

            modelBuilder.Entity("Quinelita.Data.ResultadoQuinela", b =>
                {
                    b.HasOne("Quinelita.Data.Partido", "Partido")
                        .WithMany("ResultadosQuinela")
                        .HasForeignKey("PartidoId")
                        .HasConstraintName("FK_ResultadosQuinela_Partidos");

                    b.HasOne("Quinelita.Data.TipoPuntuacion", "TipoPuntuacion")
                        .WithMany("ResultadosQuinela")
                        .HasForeignKey("TipoPuntuacionId")
                        .HasConstraintName("FK_ResultadosQuinela_TiposPuntuacion");

                    b.HasOne("Quinelita.Data.Usuario", "Usuario")
                        .WithMany("ResultadosQuinela")
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("FK_ResultadosQuinela_Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
