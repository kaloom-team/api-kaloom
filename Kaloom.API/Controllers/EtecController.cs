using Microsoft.AspNetCore.Mvc;
using KaloomAPI.Context;

namespace Kaloom.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class EtecController : Controller
    {
        private readonly KaloomContext _context;
        public EtecController(KaloomContext context)
        {
            this._context = context;
        }

        [HttpGet("getEtec")]
        public IActionResult Index()
        {
            var etec = this._context.Etecs;

            return Ok(etec);
        }
    }
}
