using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quinelita.Data;

namespace Quinelita.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultadosJornadaController : ControllerBase
    {
		private readonly QuinelitaContext _context;

		public ResultadosJornadaController(QuinelitaContext context)
		{
			_context = context;
		}

		[Route("Jornada/{jornadaId}")]
		[HttpGet]
		public IEnumerable<ResultadoJornada> Get(int jornadaId)
		{
			var result = _context.ResultadosJornada
				//.Include(p => p.Partido)
				.Where(l => l.Partido.JornadaId == jornadaId);

			return result;
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] ResultadoJornada resultadoJornada)
		{
			_context.ResultadosJornada.Add(resultadoJornada);
			await _context.SaveChangesAsync();

			return Ok();
		}
	}
}