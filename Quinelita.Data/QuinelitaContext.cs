using Microsoft.EntityFrameworkCore;

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

        public virtual DbSet<Equipo> Equipos { get; set; }
        public virtual DbSet<Jornada> Jornadas { get; set; }
        public virtual DbSet<Liga> Ligas { get; set; }
        public virtual DbSet<Partido> Partidos { get; set; }
        public virtual DbSet<QuinelaJornada> QuinelasJornada { get; set; }
        public virtual DbSet<ResultadoJornada> ResultadosJornada { get; set; }
        public virtual DbSet<ResultadoQuinela> ResultadosQuinela { get; set; }
        public virtual DbSet<TipoPuntuacion> TiposPuntuacion { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Rol> Roles { get; set; }
        public virtual DbSet<RoleUsuario> RolesUsuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Server=MTYSUSDSL001710;Database=Quinelita2;Trusted_Connection=True;");
                optionsBuilder.UseSqlServer("Server=DESKTOP-SU2HP93;Database=Quinelita2;Trusted_Connection=True;");
                //optionsBuilder.UseSqlServer("Server=DESKTOP-SU2HP93;Database=Quinelita1;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipo>(entity =>
            {
                entity.HasIndex(e => e.LigaId)
                    .HasName("IX_Equipo_LigaId");

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.HasOne(d => d.Liga)
                    .WithMany(p => p.Equipos)
                    .HasForeignKey(d => d.LigaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Equipos_Ligas");
            });

            modelBuilder.Entity<Liga>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<Partido>(entity =>
            {
                entity.HasIndex(e => e.EquipoLocalId)
                    .HasName("IX_PartidosJornada_EquipoLocalId");

                entity.HasIndex(e => e.EquipoVisitanteId)
                    .HasName("IX_PartidosJornada_EquipoVisitanteId");

                entity.HasIndex(e => e.JornadaId)
                    .HasName("IX_PartidosJornada_JornadaId");

                entity.HasOne(d => d.EquipoLocal)
                    .WithMany(p => p.PartidosEquipoLocal)
                    .HasForeignKey(d => d.EquipoLocalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Partidos_Equipos");

                entity.HasOne(d => d.EquipoVisitante)
                    .WithMany(p => p.PartidosEquipoVisitante)
                    .HasForeignKey(d => d.EquipoVisitanteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Partidos_Equipos1");

                entity.HasOne(d => d.Jornada)
                    .WithMany(p => p.Partidos)
                    .HasForeignKey(d => d.JornadaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Partidos_Jornadas");
            });

            modelBuilder.Entity<QuinelaJornada>(entity =>
            {
                entity.Property(e => e.MarcadorLocal).HasDefaultValueSql("((0))");

                entity.Property(e => e.MarcadorVisitante).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Ganador)
                    .WithMany(p => p.QuinelasJornada)
                    .HasForeignKey(d => d.GanadorId)
                    .HasConstraintName("FK_QuinelasJornada_Equipos");

                entity.HasOne(d => d.Partido)
                    .WithMany(p => p.QuinelasJornada)
                    .HasForeignKey(d => d.PartidoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuinelasJornada_Partidos");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.QuinelasJornada)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuinelasJornada_Usuarios");
            });

            modelBuilder.Entity<ResultadoJornada>(entity =>
            {
                entity.HasOne(d => d.Ganador)
                    .WithMany(p => p.ResultadosJornada)
                    .HasForeignKey(d => d.GanadorId)
                    .HasConstraintName("FK_ResultadosJornada_Equipos");

                entity.HasOne(d => d.Partido)
                    .WithMany(p => p.ResultadosJornada)
                    .HasForeignKey(d => d.PartidoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResultadosJornada_Partidos");
            });

            modelBuilder.Entity<ResultadoQuinela>(entity =>
            {
                entity.HasOne(d => d.Partido)
                    .WithMany(p => p.ResultadosQuinela)
                    .HasForeignKey(d => d.PartidoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResultadosQuinela_Partidos");

                entity.HasOne(d => d.TipoPuntuacion)
                    .WithMany(p => p.ResultadosQuinela)
                    .HasForeignKey(d => d.TipoPuntuacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResultadosQuinela_TiposPuntuacion");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.ResultadosQuinela)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResultadosQuinela_Usuarios");
            });

            modelBuilder.Entity<TipoPuntuacion>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Email).IsUnicode(false);
            });

            modelBuilder.Entity<RoleUsuario>()
                .HasKey(x => new { x.RolId, x.UsuarioId });
        }
    }
}
