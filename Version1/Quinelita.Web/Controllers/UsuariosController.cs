using Microsoft.AspNetCore.Mvc;
using Quinelita.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Quinelita.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly QuinelitaContext _context;

        public UsuariosController(QuinelitaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = usuario.Id }, usuario);
        }

        [HttpPost]
        public IActionResult GetByMailPass([FromBody] Usuario usuario)
        {
            var result = _context.Usuarios
               .Where(x => x.Email == usuario.Email && x.Password == usuario.Password)
               .FirstOrDefault();

            return Ok(result);
        }
    }
}