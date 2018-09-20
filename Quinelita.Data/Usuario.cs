using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quinelita.Data
{
    public partial class Usuario
    {
        public Usuario()
        {
            QuinelasJornada = new HashSet<QuinelaJornada>();
            ResultadosQuinela = new HashSet<ResultadoQuinela>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [InverseProperty("Usuario")]
        public ICollection<QuinelaJornada> QuinelasJornada { get; set; }
        [InverseProperty("Usuario")]
        public ICollection<ResultadoQuinela> ResultadosQuinela { get; set; }
    }
}
