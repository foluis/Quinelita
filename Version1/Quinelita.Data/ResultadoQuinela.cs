using System.ComponentModel.DataAnnotations.Schema;

namespace Quinelita.Data
{
    public partial class ResultadoQuinela
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int PartidoId { get; set; }
        public int Puntos { get; set; }
        public int TipoPuntuacionId { get; set; }

        [ForeignKey("PartidoId")]
        [InverseProperty("ResultadosQuinela")]
        public Partido Partido { get; set; }

        [ForeignKey("TipoPuntuacionId")]
        [InverseProperty("ResultadosQuinela")]
        public TipoPuntuacion TipoPuntuacion { get; set; }

        [ForeignKey("UsuarioId")]
        [InverseProperty("ResultadosQuinela")]
        public Usuario Usuario { get; set; }
    }
}
