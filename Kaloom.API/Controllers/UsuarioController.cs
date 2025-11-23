using Kaloom.Communication.DTOs.Requests;
using Kaloom.Communication.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;
using Kaloom.Application.Facades;

namespace Kaloom.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUserFacade _userFacade;

        public UsuarioController(IUserFacade userFacade)
        {
            this._userFacade = userFacade;
        }

        [HttpGet]
        [ProducesResponseType<IEnumerable<UserResponse>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync()
            => Ok(await this._userFacade.GetAll.ExecuteAsync());

        [HttpGet("{id}", Name = "GetUserById")]
        [ProducesResponseType<UserResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
            => Ok(await this._userFacade.GetById.ExecuteAsync(id));

        [HttpPost]
        [ProducesResponseType<UserResponse>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] UserRequest request)
        {
            var response = await this._userFacade.Register.ExecuteAsync(request);

            return CreatedAtRoute("GetUserById", new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UserRequest request)
        {
            await this._userFacade.Update.ExecuteAsync(id, request);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await this._userFacade.Delete.ExecuteAsync(id);

            return NoContent();
        }

        [HttpPost("Login")]
        [ProducesResponseType<UserLoginResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> LoginAsync([FromBody] UserRequest request)
            => Ok(await this._userFacade.Login.ExecuteAsync(request));
    }
}