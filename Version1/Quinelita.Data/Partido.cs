using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quinelita.Data
{
    public partial class Partido
    {
        public Partido()
        {
            QuinelasJornada = new HashSet<QuinelaJornada>();
            ResultadosJornada = new HashSet<ResultadoJornada>();
            ResultadosQuinela = new HashSet<ResultadoQuinela>();
        }

        public int Id { get; set; }
        public int JornadaId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Fecha { get; set; }
        public bool MostrarMarcadores { get; set; }
        public int EquipoLocalId { get; set; }
        public int EquipoVisitanteId { get; set; }

        [ForeignKey("EquipoLocalId")]
        [InverseProperty("PartidosEquipoLocal")]
        public Equipo EquipoLocal { get; set; }
        [ForeignKey("EquipoVisitanteId")]
        [InverseProperty("PartidosEquipoVisitante")]
        public Equipo EquipoVisitante { get; set; }
        [ForeignKey("JornadaId")]
        [InverseProperty("Partidos")]
        public Jornada Jornada { get; set; }
        [InverseProperty("Partido")]
        public ICollection<QuinelaJornada> QuinelasJornada { get; set; }
        [InverseProperty("Partido")]
        public ICollection<ResultadoJornada> ResultadosJornada { get; set; }
        [InverseProperty("Partido")]
        public ICollection<ResultadoQuinela> ResultadosQuinela { get; set; }
    }
}
