using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quinelita.Data
{
    public partial class Jornada
    {
        public Jornada()
        {
            Partidos = new HashSet<Partido>();
        }

        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }

        [InverseProperty("Jornada")]
        public ICollection<Partido> Partidos { get; set; }
    }
}
