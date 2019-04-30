namespace Quinelita.Data
{
    public partial class RoleUsuario
    {
        public int RolId { get; set; }
        public Rol Rol { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
