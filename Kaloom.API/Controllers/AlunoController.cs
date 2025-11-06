using Kaloom.API.Context;
using Kaloom.API.Models;
using Kaloom.Communication.DTOs.Requests;
using Kaloom.Communication.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kaloom.API.UseCases.Students.Register;
using Kaloom.API.UseCases.Students.GetAll;
using Kaloom.API.UseCases.Students.GetById;

namespace Kaloom.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly KaloomContext _context;
        private readonly IRegisterStudentsUseCase _registerStudentsUseCase;
        private readonly IGetAllStudentsUseCase _getAllStudentsUseCase;
        private readonly IGetStudentByIdUseCase _getStudentByIdUseCase;

        public AlunoController(KaloomContext context, IRegisterStudentsUseCase registerStudentsUseCase, IGetAllStudentsUseCase getAllStudentsUseCase, IGetStudentByIdUseCase getStudentByIdUseCase)
        {
            this._context = context;
            this._registerStudentsUseCase = registerStudentsUseCase;
            this._getAllStudentsUseCase = getAllStudentsUseCase;
            this._getStudentByIdUseCase = getStudentByIdUseCase;
        }

        [HttpGet]
        [ProducesResponseType<List<Aluno>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync()
        {
            var alunos = await this._getAllStudentsUseCase.ExecuteAsync();

            if(alunos.Count == 0)
                return NotFound();

            return Ok(alunos);
        }

        [HttpGet("{id}", Name = "GetStudentById")]
        [ProducesResponseType<Aluno>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var aluno = await _getStudentByIdUseCase.ExecuteAsync(id);
            
            if (aluno == null)
            {
                return NotFound(new { message = $"Nenhum aluno encontrado com o ID {id}." });
            }

            return Ok(aluno);
        }

        [HttpPost]
        [ProducesResponseType<StudentResponse>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] StudentRequest request)
        {
            var response = await this._registerStudentsUseCase.ExecuteAsync(request);

            return CreatedAtRoute("GetStudentById", new { id = response.Id }, response);
        }
    }
}
