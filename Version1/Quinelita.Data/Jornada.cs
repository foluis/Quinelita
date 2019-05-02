﻿using System;
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

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        
        public DateTime Fecha { get; set; }
        public bool? AbiertaAlPublico { get; set; }

        [InverseProperty("Jornada")]
        public ICollection<Partido> Partidos { get; set; }
    }
}