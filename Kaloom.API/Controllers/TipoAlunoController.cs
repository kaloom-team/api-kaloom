using Kaloom.API.Context;
using Kaloom.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [ProducesResponseType<List<TipoAluno>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync()
        {
            var tipo = await _context.TipoAlunos
                .AsNoTracking()
                .ToListAsync();

            if (tipo.Count == 0)
                return NotFound();

            return Ok(tipo);
        }

        [HttpGet("{id}", Name = "GetStudentTypeById")]
        [ProducesResponseType<TipoAluno>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var tipo = await this._context.TipoAlunos
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id);

            if (tipo == null)
                return NotFound(new { message = $"Nenhum tipo de aluno encontrado com o ID {id}." });

            return Ok(tipo);
        }

        [HttpPost]
        [ProducesResponseType<TipoAluno>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] TipoAluno tipo)
        {
            await _context.TipoAlunos.AddAsync(tipo);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetStudentTypeById", new { id = tipo.Id }, tipo);
        }
    }
}
