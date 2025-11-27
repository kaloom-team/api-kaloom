using Kaloom.SharedContracts.DTOs;
using Kaloom.Students.Application.Facades;
using Kaloom.Students.Communication.DTOs.Requests;
using Kaloom.Students.Communication.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Kaloom.Students.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IStudentFacade _studentFacade;

        public AlunoController(IStudentFacade studentFacade)
        {
            this._studentFacade = studentFacade;
        }

        [HttpGet]
        [ProducesResponseType<IEnumerable<StudentResponse>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync()
            => Ok(await this._studentFacade.GetAll.ExecuteAsync());

        [HttpGet("{id}", Name = "GetStudentById")]
        [ProducesResponseType<StudentResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
            => Ok(await this._studentFacade.GetById.ExecuteAsync(id));

        [HttpGet("GetByReferenceId/{id}")]
        [ProducesResponseType<StudentResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByUserIdAsync([FromRoute] int id)
            => Ok(await this._studentFacade.GetByReferenceId.ExecuteAsync(id));

        [HttpPost]
        [ProducesResponseType<StudentShortResponse>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] StudentRequest request)
        {
            var response = await this._studentFacade.Register.ExecuteAsync(request);

            return CreatedAtRoute("GetStudentById", new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] StudentRequest request)
        {
            await this._studentFacade.Update.ExecuteAsync(id, request);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await this._studentFacade.Delete.ExecuteAsync(id);

            return NoContent();
        }
    }
}