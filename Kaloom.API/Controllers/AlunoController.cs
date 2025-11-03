using Kaloom.API.Context;
using Kaloom.API.Models;
using Kaloom.Communication.Requests;
using Kaloom.Communication.Responses;
using Microsoft.AspNetCore.Mvc;
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
        [ProducesResponseType<List<Aluno>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync()
        {
            var alunos = await this._context.Alunos
                .Include(u => u.Usuario)
                .Include(u => u.TipoAluno)
                .AsNoTracking()
                .ToListAsync();

            if(alunos == null || alunos.Count == 0)
                return NotFound();

            return Ok(alunos);
        }

        [HttpGet("{id}", Name = "GetStudentById")]
        [ProducesResponseType<Aluno>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var alunos = await this._context.Alunos
                .Include(u => u.Usuario)
                .Include(u => u.TipoAluno)
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);
            
            if (alunos == null)
            {
                return NotFound(new { message = $"Nenhum aluno encontrado com o ID {id}." });
            }

            return Ok(alunos);
        }

        [HttpPost]
        [ProducesResponseType<ResponseStudentJson>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] RequestStudentJson request)
        {
            if 
            (
                string.IsNullOrWhiteSpace(request.Nome) || 
                string.IsNullOrWhiteSpace(request.Sobrenome) || 
                string.IsNullOrWhiteSpace(request.NomeUsuario)
            )
            {
                return BadRequest(new { message = "Os campos de texto não podem ser vazios ou conter apenas espaços." });
            }

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

            await _context.AddAsync(aluno);
            await _context.SaveChangesAsync();

            var response = new ResponseStudentJson
            {
                Id = aluno.Id,
                Nome = aluno.Nome
            };

            return CreatedAtRoute("GetStudentById", new { id = aluno.Id }, response);
        }
    }
}
