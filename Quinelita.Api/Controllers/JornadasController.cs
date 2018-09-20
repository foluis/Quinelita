using Microsoft.AspNetCore.Mvc;
using Quinelita.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quinelita.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class JornadasController : ControllerBase
	{
		private readonly QuinelitaContext _context;

		public JornadasController(QuinelitaContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IEnumerable<Jornada> Get()
		{
			var result = _context.Jornadas.Select(c =>
				new Jornada
				{
					Id = c.Id,
					Fecha = c.Fecha,
					Partidos = c.Partidos
				});

			return result;
		}

		[Route("{jornadaId}")]
		[HttpGet]
		public IEnumerable<Jornada> Get(int jornadaId)
		{
			var result = _context.Jornadas.Select(c =>
				new Jornada
				{
					Id = c.Id,
					Fecha = c.Fecha,
					Partidos = c.Partidos
				}).Where(x => x.Id == jornadaId);

			return result;
		}
		
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] string fecha)
		{
			Jornada jornada = new Jornada()
			{
				Fecha = DateTime.Parse(fecha)
			};

			_context.Jornadas.Add(jornada);
			await _context.SaveChangesAsync();
						
			return CreatedAtAction("Get", new { id = jornada.Id }, jornada);
		}
	}
}