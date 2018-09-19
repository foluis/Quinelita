using Microsoft.AspNetCore.Mvc;
using Quinelita.Data;
using System.Collections.Generic;
using System.Linq;

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

		// GET api/customers
		[HttpGet]
		public IEnumerable<Jornada> Get()
		{
			var result = _context.Jornada.Select(c =>
				new Jornada
				{
					Id = c.Id,
					Fecha = c.Fecha,
					PartidosJornada = c.PartidosJornada
				});

			return result;
		}
	}
}