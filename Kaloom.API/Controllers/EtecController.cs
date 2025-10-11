using KaloomAPI.Context;
using KaloomAPI.Models;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public IActionResult Index()
        {
            var etec = this._context.Etecs;

            return Ok(etec);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var etec = this._context.Etecs.Find(id);

            if (etec == null)
                return BadRequest();

            return Ok(etec);
        }

        [HttpPost]
        public IActionResult AddEtecs(Etec etec)
        {
            _context.Add(etec);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = etec.Id }, etec);
        }
    }
}
