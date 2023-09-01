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
    public class UserController: ControllerBase
    {
        private readonly IServiceManager _service;
        public UserController(IServiceManager service) => _service = service;



        [HttpGet("{userId}/events", Name = "Current_user_events")]
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> GetCurrentUserEvents()
        {
            var currentUserEvents = await _service.EventService
                .GetEventsCreatedByUserAsync(trackChanges: false);

            return Ok(currentUserEvents);
        }


        /// <summary>
        /// Gets all events a user is attending
        /// </summary>
        /// <returns>New user registered</returns>
        /// <response code="200">Returns 200 status code response</response>
        /// <response code="401">Unauthorized access</response>
        [HttpGet("{userId}/attendances", Name = "GetUserAttendances")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetCurrentUserAttendances()
        {
            var currentUserAttendances = await _service
                .AttendanceService
                .GetUserAttendanceAsync(trackChanges: false);

            return Ok(currentUserAttendances);
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
        [Authorize(Roles = "User")]
        public async Task<ActionResult> UpdateUser(
            [FromBody] UserModelRequestDto userModelRequestDto)
        {
            if (userModelRequestDto == null)
                return BadRequest("User model request data is invalid.");

            await _service.UserService.UpdateUserAsync(userModelRequestDto, trackChanges: true);

            return NoContent();
        }




        /// <summary>
        /// Self account deletion by user
        /// </summary>
        /// <returns>Deletes a single user</returns>
        /// <response code="200">Deletes a single user from the database</response>
        /// <response code="401">Returns unauthorized access response</response>
        [HttpDelete("delete-account", Name = "DeleteUser")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> DeleteUser()
        {
            await _service.UserService.UserSelfDeleteAsync(trackChanges: false);

            return NoContent();
        }
    }
}
