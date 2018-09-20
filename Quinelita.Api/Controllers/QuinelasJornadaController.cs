using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quinelita.Data;

namespace Quinelita.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuinelasJornadaController : ControllerBase
    {
		private readonly QuinelitaContext _context;

		public QuinelasJornadaController(QuinelitaContext context)
		{
			_context = context;
		}


		[Route("Jornada/{jornadaId}")]
		[HttpGet]
		public IEnumerable<QuinelaJornada> Get(int jornadaId)
		{
			var result = _context.QuinelasJornada
				//.Include(p => p.Partido)
				.Where(l => l.Partido.JornadaId == jornadaId);

			return result;
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] QuinelaJornada quinelaJornada)
		{
			_context.QuinelasJornada.Add(quinelaJornada);
			await _context.SaveChangesAsync();

			return Ok();
		}
	}
}