using Kaloom.Application.Facades;
using Kaloom.Communication.DTOs.Requests;
using Kaloom.Communication.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Kaloom.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EtecController : Controller
    {
        private readonly IEtecFacade _etecFacade;
        public EtecController(IEtecFacade etecFacade)
        {
            this._etecFacade = etecFacade;
        }

        [HttpGet]
        [ProducesResponseType<IEnumerable<EtecResponse>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync()
            => Ok(await this._etecFacade.GetAll.ExecuteAsync());

        [HttpGet("{id}", Name = "GetEtecById")]
        [ProducesResponseType<EtecResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
            => Ok(await this._etecFacade.GetById.ExecuteAsync(id));
        
        [HttpPost]
        [ProducesResponseType<EtecResponse>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] EtecRequest etec)
        {
            var response = await this._etecFacade.Register.ExecuteAsync(etec);

            return CreatedAtRoute("GetEtecById", new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] EtecRequest etec)
        {
            await this._etecFacade.Update.ExecuteAsync(id, etec);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await this._etecFacade.Delete.ExecuteAsync(id);

            return NoContent();
        }
    }
}