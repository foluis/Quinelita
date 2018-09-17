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
            PartidosJornada = new HashSet<PartidosJornada>();
        }

        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }

        [InverseProperty("Jornada")]
        public ICollection<PartidosJornada> PartidosJornada { get; set; }
    }
}
