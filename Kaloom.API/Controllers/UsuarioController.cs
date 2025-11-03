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
        [ProducesResponseType<List<Usuario>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync()
        {
            var usuarios = await this._context.Usuarios
                .AsNoTracking()
                .ToListAsync();

            if(usuarios == null || usuarios.Count == 0)
                return NotFound();

            return Ok(usuarios);
        }

        [HttpGet("{id}", Name = "GetUserById")]
        [ProducesResponseType<Usuario>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var usuario = await this._context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);

            if (usuario == null)
            {
                return NotFound(new { message = $"Nenhum usuário encontrado com o ID {id}." });
            }

            return Ok(usuario);
        }

        [HttpPost]
        [ProducesResponseType<ResponseUserJson>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

            return CreatedAtRoute("GetUserById", new { id = usuario.Id }, response);
        }

        [HttpPost("Login")]
        [ProducesResponseType<ResponseUserLoginJson>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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