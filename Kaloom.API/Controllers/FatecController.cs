using Kaloom.API.Context;
using Kaloom.API.Models;
using Kaloom.Communication.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [ProducesResponseType<List<Fatec>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync()
        {
            var fatecs = await this._context.Fatecs
                .AsNoTracking()
                .ToListAsync();

            if (fatecs == null || fatecs.Count == 0)
                return NotFound();

            return Ok(fatecs);
        }

        [HttpGet("{id}", Name = "GetFatecById")]
        [ProducesResponseType<Fatec>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var fatec = await this._context.Fatecs
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);

            if (fatec == null)
                return NotFound(new { message = $"Nenhuma Fatec encontrada com o ID {id}." });

            return Ok(fatec);
        }

        [HttpPost]
        [ProducesResponseType<Fatec>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] Fatec fatec)
        {
            if(string.IsNullOrWhiteSpace(fatec.NomeUnidade))
                return BadRequest(new { message = "O nome da unidade não pode ser vazio ou ter espaços em branco" });

            await _context.AddAsync(fatec);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetFatecById", new { id = fatec.Id }, fatec);
        }
    }
}