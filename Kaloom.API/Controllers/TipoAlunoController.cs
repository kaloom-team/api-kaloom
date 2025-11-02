using Kaloom.API.Context;
using Kaloom.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kaloom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoAlunoController : ControllerBase
    {
        private readonly KaloomContext _context;

        public TipoAlunoController(KaloomContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var tipo = this._context.TipoAlunos;

            return Ok(tipo);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(TipoAluno), StatusCodes.Status200OK)]
        public IActionResult GetById([FromRoute] int id)
        {
            var tipo = this._context.TipoAlunos.Find(id);

            if (tipo == null)
            {
                return NotFound();
            }

            return Ok(tipo);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TipoAluno tipo)
        {
            _context.TipoAlunos.Add(tipo);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = tipo.Id }, tipo);
        }
    }
}
