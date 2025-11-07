using Kaloom.API.Context;
using Kaloom.API.Models;
using Kaloom.Communication.DTOs.Requests;
using Kaloom.Communication.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kaloom.API.UseCases.Students.Register;
using Kaloom.API.UseCases.Students.GetAll;
using Kaloom.API.UseCases.Students.GetById;
using Kaloom.API.UseCases.Students.Delete;
using Kaloom.API.UseCases.Students.Update;

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
        private readonly IDeleteStudentUseCase _deleteStudentUseCase;
        private readonly IUpdateStudentUseCase _updateStudentUseCase;

        public AlunoController(KaloomContext context, IRegisterStudentsUseCase registerStudentsUseCase, IGetAllStudentsUseCase getAllStudentsUseCase, IGetStudentByIdUseCase getStudentByIdUseCase, IDeleteStudentUseCase deleteStudentUseCase, IUpdateStudentUseCase updateStudentUseCase)
        {
            this._context = context;
            this._registerStudentsUseCase = registerStudentsUseCase;
            this._getAllStudentsUseCase = getAllStudentsUseCase;
            this._getStudentByIdUseCase = getStudentByIdUseCase;
            this._deleteStudentUseCase = deleteStudentUseCase;
            this._updateStudentUseCase = updateStudentUseCase;
        }

        [HttpGet]
        [ProducesResponseType<IEnumerable<Aluno>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync()
        {
            var alunos = await this._getAllStudentsUseCase.ExecuteAsync();

            if(alunos.Count == 0)
                return NoContent();

            return Ok(alunos);
        }

        [HttpGet("{id}", Name = "GetStudentById")]
        [ProducesResponseType<Aluno>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var aluno = await _getStudentByIdUseCase.ExecuteAsync(id);

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

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] StudentRequest request)
        {
            await this._updateStudentUseCase.ExecuteAsync(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await this._deleteStudentUseCase.ExecuteAsync(id);
            return NoContent();
        }
    }
}