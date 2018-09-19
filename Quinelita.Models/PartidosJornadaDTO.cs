using System;
using System.Collections.Generic;
using System.Text;

namespace Quinelita.Models
{
	public class PartidosJornadaDTO
	{
		public int Id { get; set; }
		
		public DateTime? Fecha { get; set; }

		public bool MostrarMarcadores { get; set; }

		public EquipoDTO EquipoLocal { get; set; }

		public EquipoDTO EquipoVisitante { get; set; }
	}
}
