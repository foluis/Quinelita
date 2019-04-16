using System;
using System.Collections.Generic;
using System.Text;

namespace Quinelita.Models
{
	public class PartidosJornadaModel
	{
		public int Id { get; set; }
		
		public DateTime? Fecha { get; set; }

		public bool MostrarMarcadores { get; set; }

		public EquipoModel EquipoLocal { get; set; }

		public EquipoModel EquipoVisitante { get; set; }
	}
}
