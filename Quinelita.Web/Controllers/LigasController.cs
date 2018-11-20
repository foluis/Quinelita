
using Microsoft.AspNetCore.Mvc;
using Quinelita.Data;

namespace Quinelita.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LigasController : ControllerBase
    {
        private readonly QuinelitaContext _context;

        public LigasController(QuinelitaContext context)
        {
            _context = context;
        }

        // GET api/customers
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Ligas);
        }
    }
}