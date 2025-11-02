using Kaloom.API.Context;
using Microsoft.AspNetCore.Mvc;
using Kaloom.API.Models;
using Kaloom.Communication.Responses;
using Kaloom.Communication.Requests;
using Microsoft.EntityFrameworkCore;

namespace Kaloom.API.Controllers
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
        public async Task<IActionResult> GetAll()
        {
            var alunos = await this._context.Alunos
                .Include(u => u.Usuario)
                .Include(u => u.TipoAluno)
                .ToListAsync();

            return Ok(alunos);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var alunos = this._context.Alunos
                .Include(u => u.Usuario)
                .Include(u => u.TipoAluno)
                .ToList()
                .Where(a => a.Id == id);
            
            if (alunos == null)
            {
                return NotFound();
            }

            return Ok(alunos);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseStudentJson), StatusCodes.Status201Created)]
        public IActionResult Create([FromBody] RequestStudentJson request)
        {
            var aluno = new Aluno
            {
                Nome = request.Nome,
                Sobrenome = request.Sobrenome,
                NomeUsuario = request.NomeUsuario,
                DataNascimento = DateOnly.FromDateTime(request.DataNascimento),
                DataCadastro = DateTime.Now,
                IdUsuario = request.IdUsuario,
                IdTipoAluno = request.IdTipoAluno
            };

            _context.Add(aluno);
            _context.SaveChanges();

            var response = new ResponseStudentJson
            {
                Id = aluno.Id,
                Nome = aluno.Nome
            };

            return CreatedAtAction(nameof(GetById), new { id = aluno.Id }, response);
        }
    }
}
