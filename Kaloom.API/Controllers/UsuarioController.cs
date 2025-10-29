using Kaloom.API.Context;
using Kaloom.API.Models;
using Kaloom.Communication.Requests;
using Kaloom.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAll()
        {
            var usuarios = this._context.Usuarios;

            return Ok(usuarios);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var usuarios = this._context.Alunos.Find(id);

            if (usuarios == null)
            {
                return NotFound();
            }

            return Ok(usuarios);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseUserJson), StatusCodes.Status201Created)]
        public IActionResult Create([FromBody] RequestUserJson request)
        {
            var usuario = new Usuario
            {
                Email = request.Email,
                Senha = request.Senha
            };

            _context.Add(usuario);
            _context.SaveChanges();

            var response = new ResponseUserJson
            {
                Id = usuario.Id,
                Email = usuario.Email
            };

            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, response);
        }
    }
}
