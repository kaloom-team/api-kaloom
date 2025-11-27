using Kaloom.Users.Application.Facades;
using Kaloom.Users.Communication.DTOs.Requests;
using Kaloom.Users.Communication.DTOs.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kaloom.Users.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUserFacade _userFacade;

        public UsuarioController(IUserFacade userFacade)
        {
            this._userFacade = userFacade;
        }

        [HttpGet]
        [ProducesResponseType<IEnumerable<UserResponse>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync()
            => Ok(await this._userFacade.GetAll.ExecuteAsync());

        [HttpGet("{id}", Name = "GetUserById")]
        [ProducesResponseType<UserResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
            => Ok(await this._userFacade.GetById.ExecuteAsync(id));

        [HttpPost]
        [AllowAnonymous]
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
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UserRequest request)
        {
            await this._userFacade.Update.ExecuteAsync(id, request);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await this._userFacade.Delete.ExecuteAsync(id);

            return NoContent();
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        [ProducesResponseType<UserLoginResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> LoginAsync([FromBody] UserLoginRequest request)
            => Ok(await this._userFacade.Login.ExecuteAsync(request));

        [HttpPost("LoginGoogle")]
        [AllowAnonymous]
        [ProducesResponseType<UserLoginResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> LoginGoogleAsync([FromBody] GoogleLoginRequest request)
            => Ok(await this._userFacade.LoginGoogle.ExecuteAsync(request));

        [HttpPost("LoginGithub")]
        [AllowAnonymous]
        [ProducesResponseType<UserLoginResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> LoginGithubAsync([FromBody] GithubLoginRequest request)
            => Ok(await this._userFacade.LoginGithub.ExecuteAsync(request));
    }
}