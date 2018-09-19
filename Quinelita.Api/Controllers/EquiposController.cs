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
    public class EquiposController : ControllerBase
    {
		private readonly QuinelitaContext _context;

		public EquiposController(QuinelitaContext context)
		{
			_context = context;
		}

		// GET api/customers
		[HttpGet]
		public IActionResult Get()
		{
			return Ok(_context.Equipo);
		}
	}
}