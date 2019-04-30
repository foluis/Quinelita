using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quinelita.Data
{
    public partial class QuinelaJornada
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int PartidoId { get; set; }
        public int? GanadorId { get; set; }
        public int? MarcadorLocal { get; set; }
        public int? MarcadorVisitante { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Fecha { get; set; }

        [ForeignKey("GanadorId")]
        [InverseProperty("QuinelasJornada")]
        public Equipo Ganador { get; set; }
        [ForeignKey("PartidoId")]
        [InverseProperty("QuinelasJornada")]
        public Partido Partido { get; set; }
        [ForeignKey("UsuarioId")]
        [InverseProperty("QuinelasJornada")]
        public Usuario Usuario { get; set; }
    }
}
