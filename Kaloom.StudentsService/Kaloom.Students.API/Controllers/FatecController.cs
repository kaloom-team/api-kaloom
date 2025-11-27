using Kaloom.Students.Application.Facades;
using Kaloom.Students.Communication.DTOs.Requests;
using Kaloom.Students.Communication.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Kaloom.Students.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class FatecController : Controller
    {
        private readonly IFatecFacade _fatecFacade;

        public FatecController(IFatecFacade fatecFacade)
        {
            this._fatecFacade = fatecFacade;
        }

        [HttpGet]
        [ProducesResponseType<IEnumerable<FatecResponse>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync()
            => Ok(await this._fatecFacade.GetAll.ExecuteAsync());

        [HttpGet("{id}", Name = "GetFatecById")]
        [ProducesResponseType<FatecResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
            => Ok(await this._fatecFacade.GetById.ExecuteAsync(id));

        [HttpPost]
        [ProducesResponseType<FatecResponse>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] FatecRequest fatec)
        {
            var response = await this._fatecFacade.Register.ExecuteAsync(fatec);

            return CreatedAtRoute("GetFatecById", new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] FatecRequest fatec)
        {
            await this._fatecFacade.Update.ExecuteAsync(id, fatec);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await this._fatecFacade.Delete.ExecuteAsync(id);

            return NoContent();
        }
    }
}