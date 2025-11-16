using Kaloom.API.Facades;
using Kaloom.Communication.DTOs.Requests;
using Kaloom.Communication.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Kaloom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoAlunoController : ControllerBase
    {
        private readonly IStudentTypeFacade _studentTypeFacade;

        public TipoAlunoController(IStudentTypeFacade studentTypeFacade)
        {
            this._studentTypeFacade = studentTypeFacade;
        }

        [HttpGet]
        [ProducesResponseType<IReadOnlyList<StudentTypeResponse>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync()
            => Ok(await this._studentTypeFacade.GetAll.ExecuteAsync());

        [HttpGet("{id}", Name = "GetStudentTypeById")]
        [ProducesResponseType<StudentTypeResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
            => Ok(await this._studentTypeFacade.GetById.ExecuteAsync(id));

        [HttpPost]
        [ProducesResponseType<StudentTypeResponse>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] StudentTypeRequest request)
        {
            var tipoAluno = await this._studentTypeFacade.Register.ExecuteAsync(request);

            return CreatedAtRoute("GetStudentTypeById", new { id = tipoAluno.Id }, tipoAluno);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] StudentTypeRequest request)
        {
            await this._studentTypeFacade.Update.ExecuteAsync(id, request);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await this._studentTypeFacade.Delete.ExecuteAsync(id);

            return NoContent();
        }
    }
}
