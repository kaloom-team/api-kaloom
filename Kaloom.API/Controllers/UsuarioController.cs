using Kaloom.API.Context;
using Kaloom.API.Models;
using Kaloom.Communication.DTOs.Requests;
using Kaloom.Communication.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kaloom.API.UseCases.Users.GetAll;
using Kaloom.API.UseCases.Users.GetById;
using System.Linq;
using Kaloom.API.UseCases.Users;

namespace Kaloom.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsersUseCases _useCases;

        public UsuarioController(IUsersUseCases useCases)
        {
            this._useCases = useCases;
        }

        [HttpGet]
        [ProducesResponseType<IEnumerable<UserResponse>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync()
        {
            var usuarios = await this._useCases.GetAll.ExecuteAsync();

            return Ok(usuarios);
        }

        [HttpGet("{id}", Name = "GetUserById")]
        [ProducesResponseType<UserResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var usuario = await this._useCases.GetById.ExecuteAsync(id);

            return Ok(usuario);
        }

        [HttpPost]
        [ProducesResponseType<UserResponse>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] UserRequest request)
        {
            var response = await this._useCases.Register.ExecuteAsync(request);

            return CreatedAtRoute("GetUserById", new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UserRequest request)
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

        [HttpPost("Login")]
        [ProducesResponseType<UserLoginResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> LoginAsync([FromBody] UserRequest request)
        {
            var response = await this._useCases.Login.ExecuteAsync(request);

            return Ok(response);
        }
    }
}