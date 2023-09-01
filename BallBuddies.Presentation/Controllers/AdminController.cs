using BallBuddies.Models.Dtos.Request;
using BallBuddies.Services.ActionFilters;
using BallBuddies.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BallBuddies.Presentation.Controllers
{
    [ApiController]
    [Route("api/admin")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Authorize(Roles = "Admin")]
    public class AdminController: ControllerBase
    {
        private readonly IServiceManager _service;
        public AdminController(IServiceManager service) => _service = service;



        /// <summary>
        /// Gets a list of all users
        /// </summary>
        /// <returns>The user list</returns>
        /// <response code="200">Returns all the users in the database</response>
        /// <response code="401">Returns unauthorized access response</response>
        [HttpGet(Name = "GetUsers")]
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
        /*[Authorize(Roles = "Admin")]*/
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _service
                .UserService
                .GetUserWithRolesAsync(id,
                trackChanges: false);

            return Ok(user);
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
           [FromBody] UserRolesDto userRolesDto)
        {
            if (userRolesDto == null)
                return BadRequest("User model request data is invalid.");

            await _service.UserService.UpdateUserRolesAsync(id, userRolesDto, trackChanges: true);

            return NoContent();
        }




        /// <summary>
        /// User account deletion by Admin
        /// </summary>
        /// <returns>Deletes a single user</returns>
        /// <response code="200">Deletes a single user from the database</response>
        /// <response code="401">Returns unauthorized access response</response>
        [HttpDelete(Name = "DeleteUserByAdmin")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            await _service.UserService.DeleteUserAsync(userId, trackChanges: false);

            return NoContent();
        }
    }
}
