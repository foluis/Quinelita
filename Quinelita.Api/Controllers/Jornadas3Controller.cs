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
    public class Jornadas3Controller : ControllerBase
    {
        private readonly QuinelitaContext _context;

        public Jornadas3Controller(QuinelitaContext context)
        {
            _context = context;
        }

        // GET: api/Jornada3
        [HttpGet]
        public IEnumerable<Jornada> GetJornada()
        {
            return _context.Jornada;
        }

        // GET: api/Jornada3/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJornada([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jornada = await _context.Jornada.FindAsync(id);

            if (jornada == null)
            {
                return NotFound();
            }

            return Ok(jornada);
        }

        // PUT: api/Jornada3/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJornada([FromRoute] int id, [FromBody] Jornada jornada)
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

        // POST: api/Jornada3
        [HttpPost]
        public async Task<IActionResult> PostJornada([FromBody] Jornada jornada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Jornada.Add(jornada);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJornada", new { id = jornada.Id }, jornada);
        }

        // DELETE: api/Jornada3/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJornada([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jornada = await _context.Jornada.FindAsync(id);
            if (jornada == null)
            {
                return NotFound();
            }

            _context.Jornada.Remove(jornada);
            await _context.SaveChangesAsync();

            return Ok(jornada);
        }

        private bool JornadaExists(int id)
        {
            return _context.Jornada.Any(e => e.Id == id);
        }
    }
}