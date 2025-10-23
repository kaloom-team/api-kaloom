using KaloomAPI.Context;
using Microsoft.AspNetCore.Mvc;
using KaloomAPI.Models;

namespace KaloomAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly KaloomContext _context;

        public AlunoController(KaloomContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var alunos = this._context.Alunos;

            return Ok(alunos);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var alunos = this._context.Alunos.Find(id);
            
            if (alunos == null)
            {
                return NotFound();
            }

            return Ok(alunos);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Aluno aluno)
        {
            _context.Add(aluno);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = aluno.Id }, aluno);
        }
    }
}
