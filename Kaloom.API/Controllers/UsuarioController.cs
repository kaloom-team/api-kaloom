using Kaloom.API.Context;
using Kaloom.API.Models;
using Kaloom.Communication.DTOs.Requests;
using Kaloom.Communication.DTOs.Responses;
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

            if(usuarios.Count == 0)
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
        [ProducesResponseType<UserResponse>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] UserRequest request)
        {
            var usuario = new Usuario
            {
                Email = request.Email,
                Senha = request.Senha
            };

            await _context.AddAsync(usuario);
            await _context.SaveChangesAsync();

            var response = new UserResponse
            {
                Id = usuario.Id,
                Email = usuario.Email
            };

            return CreatedAtRoute("GetUserById", new { id = usuario.Id }, response);
        }

        [HttpPost("Login")]
        [ProducesResponseType<UserLoginResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> LoginAsync([FromBody] UserLoginRequest request)
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

            return Ok(new UserLoginResponse("Login realizado com sucesso!", aluno));
        }
    }
}