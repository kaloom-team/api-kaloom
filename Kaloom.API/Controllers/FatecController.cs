using Microsoft.AspNetCore.Mvc;
using KaloomAPI.Context;

namespace Kaloom.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class FatecController : Controller
    {
        private readonly KaloomContext _context;
        public FatecController(KaloomContext context)
        {
            this._context = context;
        }

        [HttpGet("getFatec")]
        public IActionResult Index()
        {
            var fatec = this._context.Fatecs;

            return Ok(fatec);
        }
    }
}
