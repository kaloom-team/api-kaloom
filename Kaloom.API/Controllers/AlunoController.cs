using Kaloom.API.Context;
using Kaloom.API.Models;
using Kaloom.Communication.DTOs.Requests;
using Kaloom.Communication.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kaloom.API.UseCases.Students;

namespace Kaloom.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IStudentsUseCases _useCases;

        public AlunoController(IStudentsUseCases useCases)
        {
            this._useCases = useCases;
        }

        [HttpGet]
        [ProducesResponseType<IEnumerable<StudentResponse>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync()
        {
            var alunos = await this._useCases.GetAll.ExecuteAsync();

            return Ok(alunos);
        }

        [HttpGet("{id}", Name = "GetStudentById")]
        [ProducesResponseType<StudentResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var aluno = await this._useCases.GetById.ExecuteAsync(id);

            return Ok(aluno);
        }

        [HttpPost]
        [ProducesResponseType<StudentShortResponse>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] StudentRequest request)
        {
            var response = await this._useCases.Register.ExecuteAsync(request);

            return CreatedAtRoute("GetStudentById", new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] StudentRequest request)
        {
            await this._useCases.Update.ExecuteAsync(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await this._useCases.Delete.ExecuteAsync(id);
            return NoContent();
        }
    }
}