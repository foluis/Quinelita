using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quinelita.Data;
using Quinelita.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quinelita.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PartidosJornadasController : ControllerBase
	{
		private readonly QuinelitaContext _context;

		public PartidosJornadasController(QuinelitaContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IEnumerable<PartidosJornada> GetPartidosJornada()
		{
			return _context.PartidosJornada;
		}

		[Route("{jornadaId}")]
		[HttpGet]
		public IEnumerable<PartidosJornadaDTO> GetPartidosJornadaXJornada(int jornadaId)
		{
			return _context.PartidosJornada
				.Include(l => l.EquipoLocal)
				.Include(v => v.EquipoVisitante)
				.Where(x => x.JornadaId == jornadaId)
				.Select(c =>
						new PartidosJornadaDTO
						{
							Id = c.Id,
							Fecha = c.Fecha,
							EquipoLocal = new EquipoDTO()
							{
								Id = c.EquipoLocal.Id,
								Nombre = c.EquipoLocal.Nombre
							},
							EquipoVisitante = new EquipoDTO()
							{
								Id = c.EquipoVisitante.Id,
								Nombre = c.EquipoVisitante.Nombre
							}
						});

		}

		[HttpPost]
		public async Task<IActionResult> PostPartidosJornada([FromBody] PartidosJornada partidosJornada)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			_context.PartidosJornada.Add(partidosJornada);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetPartidosJornada", new { id = partidosJornada.Id }, partidosJornada);
		}
	}
}