using System.ComponentModel.DataAnnotations;

namespace Quinelita.Data
{
    public class Rol
    {
        public int Id { get; set; }

        public long UsuarioId { get; set; }

        [Required]
        public string Nombre { get; set; }
    }
}
