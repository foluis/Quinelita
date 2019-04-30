using System.ComponentModel.DataAnnotations;

namespace Quinelita.Data
{
    public partial class Rol
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
    }
}
