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
        public async Task<IActionResult> GetUsers()
        {
            var users = await _service.UserService.GetAllUsersWithRolesAsync(trackChanges: false);

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
        [HttpPut("update", Name = "UpdateUser")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult> UpdateUser(
            [FromBody] UserModelRequestDto userModelRequestDto)
        {
            if (userModelRequestDto == null)
                return BadRequest("User model request data is invalid.");

            await _service.UserService.UpdateUserAsync(userModelRequestDto, trackChanges: true);

            return NoContent();
        }




        /// <summary>
        /// Updates a user's roles
        /// </summary>
        /// <returns>Updates a single user's roles</returns>
        /// <response code="200">Updates a single user's role in the database</response>
        /// <response code="401">Returns unauthorized access response</response>
        [HttpPut("{id}/roles", Name = "UpdateUserRoles")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult> UpdateUserRoles(string id,
           [FromBody] UserRolesDto userRolesDto )
        {
            if (userRolesDto == null)
                return BadRequest("User model request data is invalid.");

            await _service.UserService.UpdateUserRolesAsync(id, userRolesDto, trackChanges: true);

            return NoContent() ;
        }






        /// <summary>
        /// Deletes a user
        /// </summary>
        /// <returns>Deletes a single user</returns>
        /// <response code="200">Deletes a single user from the database</response>
        /// <response code="401">Returns unauthorized access response</response>
        [HttpDelete(Name = "DeleteUser")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> DeleteUser()
        {
            await _service.UserService.DeleteUserAsync(trackChanges: false);

            return NoContent();
        }
    }
}
