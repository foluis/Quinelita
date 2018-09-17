using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
	public class Partido
	{
		public int Id { get; set; }
		public int EquipoLocalId { get; set; }
		public int EquipoVisitanteId { get; set; }
		public int? ResultadoEquipoLocal { get; set; }
		public int? ResultadoEquipoVisitante { get; set; }
		public bool MostrarResultados { get; set; }
	}
}
