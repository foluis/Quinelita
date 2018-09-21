using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quinelita.Data
{
    public partial class TipoPuntuacion
    {
        public TipoPuntuacion()
        {
            ResultadosQuinela = new HashSet<ResultadoQuinela>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [InverseProperty("TipoPuntuacion")]
        public ICollection<ResultadoQuinela> ResultadosQuinela { get; set; }
    }
}
