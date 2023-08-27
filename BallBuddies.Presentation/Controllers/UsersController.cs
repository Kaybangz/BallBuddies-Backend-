using BallBuddies.Models.Dtos.Request;
using BallBuddies.Models.Dtos.Response;
using BallBuddies.Services.ActionFilters;
using BallBuddies.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BallBuddies.Presentation.Controllers
{

    [ApiController]
    [Route("api/users")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class UsersController: ControllerBase
    {
        private readonly IServiceManager _service;
        public UsersController(IServiceManager service) => _service = service;



        /// <summary>
        /// Gets a list of all users
        /// </summary>
        /// <returns>The user list</returns>
        /// <response code="200">Returns all the users in the database</response>
        /// <response code="401">Returns unauthorized access response</response>
        [HttpGet]
        /*[Authorize(Roles = "Admin")]*/
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public IActionResult GetUsers()
        {
            var users = _service.UserService.GetAllUsersAsync(trackChanges: false);

            return Ok(users);
        }



        /// <summary>
        /// Gets a user by Id
        /// </summary>
        /// <returns>A single user</returns>
        /// <response code="200">Returns a single user from the database</response>
        /// <response code="401">Returns unauthorized access response</response>
        [HttpGet("{id}", Name = "GetSingleUser")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _service.UserService.GetUserAsync(id, trackChanges: false);

            return Ok(user);
        }

        /// <summary>
        /// Updates a user
        /// </summary>
        /// <returns>Updates a single user</returns>
        /// <response code="200">Updates a single user in the database</response>
        /// <response code="401">Returns unauthorized access response</response>
        [HttpPut("{id}", Name = "UpdateUser")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult<UserModelResponseDto>> UpdateUser(string id,
            [FromBody] UserModelRequestDto userModelRequestDto)
        {
            if (userModelRequestDto == null)
                return BadRequest("User data is invalid.");

            await _service.UserService.UpdateUserAsync(id, userModelRequestDto, trackChanges: true);

            return NoContent();
        }




        /// <summary>
        /// Deletes a user
        /// </summary>
        /// <returns>Deletes a single user</returns>
        /// <response code="200">Deletes a single user from the database</response>
        /// <response code="401">Returns unauthorized access response</response>
        /*[HttpDelete("{id}", Name = "DeleteUser")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await _service.UserService.DeleteUserAsync(id, trackChanges: false);

            return NoContent();
        }*/
    }
}
