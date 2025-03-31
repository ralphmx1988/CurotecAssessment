using Curotec.Application.Models;
using Curotec.Application.Services.User;
using Curotec.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Curotec.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService userService) : ControllerBase
    {
        /// <summary>
        /// Authenticates a user with the provided credentials.
        /// </summary>
        /// <param name="model">The authentication request model containing username and password.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the authentication response with user details and JWT token.</returns>
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest model)
        {
            var response = await userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        /// <summary>
        /// Adds a new user.
        /// </summary>
        /// <param name="userObj">The user entity to add.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the added user entity.</returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] User userObj, CancellationToken cancellationToken)
        {
            userObj.Id = 0;
            return Ok(await userService.AddOrUpdateUser(userObj, cancellationToken));
        }

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="id">The identifier of the user to update.</param>
        /// <param name="userObj">The user entity with updated information.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the updated user entity.</returns>
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, [FromBody] User userObj, CancellationToken cancellationToken)
        {
            return Ok(await userService.AddOrUpdateUser(userObj, cancellationToken));
        }
    }
}

