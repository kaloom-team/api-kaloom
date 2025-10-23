using KaloomAPI.Context;
using Microsoft.AspNetCore.Mvc;
using KaloomAPI.Models;

namespace KaloomAPI.Controllers
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
        public IActionResult Create([FromBody] Usuario usuario)
        {
            _context.Add(usuario);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
        }
    }
}
