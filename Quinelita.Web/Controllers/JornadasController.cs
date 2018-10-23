using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quinelita.Data;

namespace Quinelita.Web.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class JornadasController : ControllerBase
    {
        private readonly QuinelitaContext _context;

        public JornadasController(QuinelitaContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public IEnumerable<Jornada> Get()
        //{
        //	var result = _context.Jornadas.Select(c =>
        //		new Jornada
        //		{
        //			Id = c.Id,
        //			Fecha = c.Fecha,
        //			Partidos = c.Partidos
        //		});

        //	return result;
        //}

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _context.Jornadas.Select(c =>
                    new Jornada
                    {
                        Id = c.Id,
                        Fecha = c.Fecha,
                        Partidos = c.Partidos
                    });

                return Ok(result);
            }
            catch (Exception ex)
            {
                var error = ex.ToString();
                return StatusCode(500); 
            }
        }

        [Authorize(Policy = "EsAuditor")]
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] Jornada jornada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jornada.Id)
            {
                return BadRequest();
            }

            _context.Entry(jornada).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JornadaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id, [FromBody] Jornada jornada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jornada.Id)
            {
                return BadRequest();
            }           

            return NoContent();
        }

        private bool JornadaExists(int id)
        {
            return _context.Jornadas.Any(e => e.Id == id);
        }
    }
}