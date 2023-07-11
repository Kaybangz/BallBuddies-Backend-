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
            var users = await _service.UserService.GetAllUsersAsync(trackChanges: false);

            return Ok(users);
        }



        /// <summary>
        /// Gets a user by Id
        /// </summary>
        /// <returns>A single user</returns>
        /// <response code="200">Returns a single user from the database</response>
        /// <response code="401">Returns unauthorized access response</response>
        [HttpGet("{id:Guid}", Name = "GetSingleUser")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> GetUser(string Id)
        {
            var user = await _service.UserService.GetUserAsync(Id, trackChanges: false);

            return Ok(user);
        }
    }
}
