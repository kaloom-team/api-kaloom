using KaloomAPI.Context;
using Microsoft.AspNetCore.Mvc;

namespace KaloomAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly KaloomContext _context;

        public AlunoController(KaloomContext context)
        {
            this._context = context;
        }

        [HttpGet("getAll")]
        public IActionResult getAll()
        {
            var alunos = this._context.Alunos;

            return Ok(alunos);
        }

        [HttpGet("getById/{id}")]
        public IActionResult getById(int id)
        {
            var alunos = this._context.Alunos.Find(id);
            
            if (alunos == null)
            {
                return NotFound();
            }

            return Ok(alunos);
        }
    }
}
