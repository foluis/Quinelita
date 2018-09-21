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
		[HttpPost]
		public async Task<IActionResult> Post(int jornadaId)
		{
			List<ResultadoQuinela> resultadosQuinela = new List<ResultadoQuinela>();
			ResultadoQuinela resultadoQuinela;

			var quinelasJornada = _context.QuinelasJornada
				.Where(l => l.Partido.JornadaId == jornadaId);

			//var quinelasJornada = from x in _context.QuinelasJornada
			//					   join y in _context.ResultadosQuinela			
			//					   on new { x.UsuarioId, x.PartidoId } equals new { y.UsuarioId, y.PartidoId }
			//					   where x.Partido.JornadaId == jornadaId
			//					   select x;

			//var quinelasJornada = from x in _context.QuinelasJornada
			//					  join y in _context.ResultadosQuinela
			//					  on 1 equals 1
			//					  where x.Partido.JornadaId == jornadaId && (x.UsuarioId != y.UsuarioId && x.PartidoId != y.PartidoId)
			//					  select x;

			var resultadosJornada = _context.ResultadosJornada
				.Where(l => l.Partido.JornadaId == jornadaId);

			var resultadosQuinelaActual = _context.ResultadosQuinela
				.Where(l => l.Partido.JornadaId == jornadaId);


			foreach (var resultado in resultadosJornada)
			{
				var grupoPartidoN = quinelasJornada.Where(p => p.PartidoId == resultado.PartidoId);

				foreach (var partido in grupoPartidoN)
				{
					if(resultadosQuinelaActual.Any(x => x.UsuarioId == partido.UsuarioId && x.PartidoId == partido.PartidoId))
					{
						break;
					}

					//Tipo puntuacion - Acertar ganador
					if (resultado.GanadorId == partido.GanadorId)
					{
						resultadoQuinela = new ResultadoQuinela
						{
							PartidoId = resultado.PartidoId,
							Puntos = 1,
							UsuarioId = partido.UsuarioId,
							TipoPuntuacionId = (int)TipoPuntuacion.AcertarGanador
						};

						resultadosQuinela.Add(resultadoQuinela);
					}

					//Tipo puntuacion - Acertar marcador
					else if (resultado.MarcadorLocal == partido.MarcadorLocal
						&& resultado.MarcadorVisitante == partido.MarcadorVisitante
						&& resultado.Partido.MostrarMarcadores == true)
					{
						resultadoQuinela = new ResultadoQuinela
						{
							PartidoId = resultado.PartidoId,
							Puntos = 3,
							UsuarioId = partido.UsuarioId,
							TipoPuntuacionId = (int)TipoPuntuacion.AcertarGanador
						};

						resultadosQuinela.Add(resultadoQuinela);
					}
					else
					{
						resultadoQuinela = new ResultadoQuinela
						{
							PartidoId = resultado.PartidoId,
							Puntos = 0,
							UsuarioId = partido.UsuarioId,
							TipoPuntuacionId = (int)TipoPuntuacion.NoAcerto
						};

						resultadosQuinela.Add(resultadoQuinela);
					}
				}
			}

			_context.ResultadosQuinela.AddRangeAsync(resultadosQuinela);
			await _context.SaveChangesAsync();

			return Ok();
		}
	}

	public enum TipoPuntuacion
	{
		AcertarGanador = 1,         //1 puntos
		AcertarMarcador,            //3 puntos
		AcertarMarcadorInverso,
		AcertarGanadorMarcador,
		NoAcerto = 99,              //0 puntos
	}
}