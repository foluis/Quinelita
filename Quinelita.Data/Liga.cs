using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quinelita.Data
{
    public partial class Liga
    {
        public Liga()
        {
            Equipos = new HashSet<Equipo>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [InverseProperty("Liga")]
        public ICollection<Equipo> Equipos { get; set; }
    }
}
