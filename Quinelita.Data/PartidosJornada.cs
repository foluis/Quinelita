using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quinelita.Data
{
    public partial class PartidosJornada
    {
        public int Id { get; set; }

        //public int PartidoId { get; set; }

        public int JornadaId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? Fecha { get; set; }

        public bool MostrarMarcadores { get; set; }

        public int EquipoLocalId { get; set; }

        public int EquipoVisitanteId { get; set; }

        [ForeignKey("EquipoLocalId")]
        [InverseProperty("PartidosJornadaEquipoLocal")]
        public Equipo EquipoLocal { get; set; }

        [ForeignKey("EquipoVisitanteId")]
        [InverseProperty("PartidosJornadaEquipoVisitante")]
        public Equipo EquipoVisitante { get; set; }

        [ForeignKey("JornadaId")]
        [InverseProperty("PartidosJornada")]
        public Jornada Jornada { get; set; }
    }
}
