using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quinelita.Data
{
    public partial class ResultadoJornada
    {
        public int Id { get; set; }
        public int PartidoId { get; set; }
        public int? GanadorId { get; set; }
        public int? MarcadorLocal { get; set; }
        public int? MarcadorVisitante { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Fecha { get; set; }

        [ForeignKey("GanadorId")]
        [InverseProperty("ResultadosJornada")]
        public Equipo Ganador { get; set; }
        [ForeignKey("PartidoId")]
        [InverseProperty("ResultadosJornada")]
        public Partido Partido { get; set; }
    }
}
