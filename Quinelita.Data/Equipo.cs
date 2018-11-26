using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quinelita.Data
{
    public partial class Equipo
    {
        public Equipo()
        {
            PartidosEquipoLocal = new HashSet<Partido>();
            PartidosEquipoVisitante = new HashSet<Partido>();
            QuinelasJornada = new HashSet<QuinelaJornada>();
            ResultadosJornada = new HashSet<ResultadoJornada>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        public int LigaId { get; set; }

        [ForeignKey("LigaId")]
        [InverseProperty("Equipos")]
        public Liga Liga { get; set; }
        [InverseProperty("EquipoLocal")]
        public ICollection<Partido> PartidosEquipoLocal { get; set; }
        [InverseProperty("EquipoVisitante")]
        public ICollection<Partido> PartidosEquipoVisitante { get; set; }
        [InverseProperty("Ganador")]
        public ICollection<QuinelaJornada> QuinelasJornada { get; set; }
        [InverseProperty("Ganador")]
        public ICollection<ResultadoJornada> ResultadosJornada { get; set; }
    }
}
