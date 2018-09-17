using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quinelita.Data
{
    public partial class Equipo
    {
        public Equipo()
        {
            PartidosJornadaEquipoLocal = new HashSet<PartidosJornada>();
            PartidosJornadaEquipoVisitante = new HashSet<PartidosJornada>();
        }

        public int Id { get; set; }

		[Required]
        [StringLength(50)]
		public string Nombre { get; set; }

		public int LigaId { get; set; }

        [ForeignKey("LigaId")]
        [InverseProperty("Equipo")]
        public Liga Liga { get; set; }

        [InverseProperty("EquipoLocal")]
        public ICollection<PartidosJornada> PartidosJornadaEquipoLocal { get; set; }

        [InverseProperty("EquipoVisitante")]
        public ICollection<PartidosJornada> PartidosJornadaEquipoVisitante { get; set; }
    }
}
