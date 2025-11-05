using Kaloom.API.Context;
using Kaloom.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kaloom.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EtecController : Controller
    {
        private readonly KaloomContext _context;
        public EtecController(KaloomContext context)
        {
            this._context = context;
        }

        [HttpGet]
        [ProducesResponseType<List<Etec>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync()
        {
            var etecs = await this._context.Etecs
                .AsNoTracking()
                .ToListAsync();

            if (etecs.Count == 0)
                return NotFound();

            return Ok(etecs);
        }

        [HttpGet("{id}", Name = "GetEtecById")]
        [ProducesResponseType<Etec>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var etec = await this._context.Etecs
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);

            if (etec == null)
                return NotFound(new { message = $"Nenhuma Etec encontrada com o ID {id}." });

            return Ok(etec);
        }

        [HttpPost]
        [ProducesResponseType<Etec>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] Etec etec)
        {
            if (string.IsNullOrWhiteSpace(etec.NomeUnidade))
                return BadRequest(new { message = "O nome da unidade não pode ser vazio ou ter espaços em branco" });

            await _context.AddAsync(etec);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetEtecById", new { id = etec.Id }, etec);
        }
    }
}