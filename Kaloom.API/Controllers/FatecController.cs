using Microsoft.AspNetCore.Mvc;
using Kaloom.API.Context;
using Kaloom.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Kaloom.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class FatecController : Controller
    {
        private readonly KaloomContext _context;
        public FatecController(KaloomContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var fatec = this._context.Fatecs;

            return Ok(fatec);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var fatec = this._context.Fatecs.Find(id);

            if (fatec == null)
                return BadRequest();

            return Ok(fatec);
        }

        [HttpPost]
        public IActionResult AddFatecs(Fatec fatec)
        {
            _context.Add(fatec);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = fatec.Id }, fatec);
        }
    }
}
