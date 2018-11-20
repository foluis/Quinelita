using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quinelita.Data;
using Quinelita.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quinelita.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartidosController : ControllerBase
    {
        private readonly QuinelitaContext _context;

        public PartidosController(QuinelitaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Partido> GetPartidosJornada()
        {
            return _context.Partidos;
        }

        [Route("GetPartidosJornadaXJornada/{jornadaId}")]
        [HttpGet]
        public IEnumerable<PartidosJornadaModel> GetPartidosJornadaXJornada(int jornadaId)
        {
            return _context.Partidos
                .Include(l => l.EquipoLocal)
                .Include(v => v.EquipoVisitante)
                .Where(x => x.JornadaId == jornadaId)
                .Select(c =>
                        new PartidosJornadaModel
                        {
                            Id = c.Id,
                            Fecha = c.Fecha,
                            EquipoLocal = new EquipoModel()
                            {
                                Id = c.EquipoLocal.Id,
                                Nombre = c.EquipoLocal.Nombre
                            },
                            EquipoVisitante = new EquipoModel()
                            {
                                Id = c.EquipoVisitante.Id,
                                Nombre = c.EquipoVisitante.Nombre
                            }
                        });

        }

        [HttpPost]
        public async Task<IActionResult> PostPartidosJornada([FromBody] Partido partidosJornada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Partidos.Add(partidosJornada);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPartidosJornada", new { id = partidosJornada.Id }, partidosJornada);
        }
    }
}
