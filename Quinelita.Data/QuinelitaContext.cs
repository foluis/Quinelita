using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Quinelita.Data
{
    public partial class QuinelitaContext : DbContext
    {
        public QuinelitaContext()
        {
        }

        public QuinelitaContext(DbContextOptions<QuinelitaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Equipo> Equipo { get; set; }
        public virtual DbSet<Jornada> Jornada { get; set; }
        public virtual DbSet<Liga> Liga { get; set; }
        public virtual DbSet<PartidosJornada> PartidosJornada { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=MTYSUSDSL001710;Database=Quinelita;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipo>(entity =>
            {
                entity.Property(e => e.Nombre).IsUnicode(false); //varchar

                entity.HasOne(d => d.Liga)
                    .WithMany(p => p.Equipo)
                    .HasForeignKey(d => d.LigaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Equipo_Liga");
            });

            modelBuilder.Entity<Liga>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<PartidosJornada>(entity =>
            {
                entity.HasOne(d => d.EquipoLocal)
                    .WithMany(p => p.PartidosJornadaEquipoLocal)
                    .HasForeignKey(d => d.EquipoLocalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PartidosJornada_Equipo");

                entity.HasOne(d => d.EquipoVisitante)
                    .WithMany(p => p.PartidosJornadaEquipoVisitante)
                    .HasForeignKey(d => d.EquipoVisitanteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PartidosJornada_Equipo1");

                entity.HasOne(d => d.Jornada)
                    .WithMany(p => p.PartidosJornada)
                    .HasForeignKey(d => d.JornadaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PartidosJornada_Jornada");
            });
        }
    }
}
