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
    public class UsuarioController : ControllerBase
    {
        private readonly KaloomContext _context;

        public UsuarioController(KaloomContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var usuarios = await this._context.Usuarios.ToListAsync();

            return Ok(usuarios);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var usuarios = await this._context.Alunos.FindAsync(id);

            if (usuarios == null)
            {
                return NotFound();
            }

            return Ok(usuarios);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseUserJson), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateAsync([FromBody] RequestUserJson request)
        {
            var usuario = new Usuario
            {
                Email = request.Email,
                Senha = request.Senha
            };

            await _context.AddAsync(usuario);
            await _context.SaveChangesAsync();

            var response = new ResponseUserJson
            {
                Id = usuario.Id,
                Email = usuario.Email
            };

            return CreatedAtAction(nameof(GetByIdAsync), new { id = usuario.Id }, response);
        }

        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(typeof(ResponseUserLoginJson), StatusCodes.Status200OK)]
        public async Task<IActionResult> LoginAsync([FromBody] RequestUserLoginJson request)
        {
            var usuarios = await this._context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == request.Email);

            if (usuarios == null)
                return Unauthorized(new { message = "Usuário não encontrado." });

            if (usuarios.Senha != request.Senha)
                return Unauthorized(new { message = "Senha incorreta." });

            var aluno = await this._context.Alunos
                .AsNoTracking()
                .Include(u => u.TipoAluno)
                .FirstOrDefaultAsync(a => a.IdUsuario == usuarios.Id);

            if (aluno == null)
                return NotFound(new { message = "Aluno não encontrado para este usuário." });

            return Ok(new ResponseUserLoginJson("Login realizado com sucesso!", aluno));
        }
    }
}