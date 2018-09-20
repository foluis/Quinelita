using Microsoft.AspNetCore.Mvc;
using Quinelita.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quinelita.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ResultadosQuinelaController : ControllerBase
	{
		private readonly QuinelitaContext _context;

		public ResultadosQuinelaController(QuinelitaContext context)
		{
			_context = context;
		}

		[Route("Jornada/{jornadaId}")]
		[HttpGet]
		public IEnumerable<ResultadoQuinela> Get(int jornadaId)
		{
			return _context.ResultadosQuinela				
				.Where(l => l.Partido.JornadaId == jornadaId);
		}

		[Route("Jornada/{jornadaId}")]
		[HttpGet]
		public async Task<IActionResult> Get(int jornadaId)
		{
			List<ResultadoQuinela> resultadosQuinela = new List<ResultadoQuinela>();

			var quinelasJornada = _context.QuinelasJornada
				.Where(l => l.Partido.JornadaId == jornadaId);

			var resultadosJornada = _context.ResultadosJornada
				.Where(l => l.Partido.JornadaId == jornadaId);
			

			foreach (var resultado in resultadosJornada)
			{
				var grupoPartidoN = quinelasJornada.Where(p => p.PartidoId == resultado.PartidoId);

				foreach (var partido in grupoPartidoN)
				{
					if(resultado.GanadorId == partido.GanadorId)
					{

					}
				}
			}

			return Ok();
		}
	}
}