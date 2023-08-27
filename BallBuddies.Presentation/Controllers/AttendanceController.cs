using BallBuddies.Models.Dtos.Request;
using BallBuddies.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BallBuddies.Presentation.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class AttendanceController: ControllerBase
    {
        private readonly IServiceManager _service;

        public AttendanceController(IServiceManager service) => _service = service;


        /// <summary>
        /// Gets all the attendance for an event
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns>New user registered</returns>
        /// <response code="200">Returns all the attendance for an event</response>
        /// <response code="401">Unauthorized access</response>
        [HttpGet("events/{eventId}/attendances", Name = "GetEventAttendances")]
        [AllowAnonymous]
        public async Task<IActionResult> GetEventAttendances(Guid eventId)
        {
            var attendances = await _service
                .AttendanceService
                .GetEventAttendancesAsync(eventId, trackChanges: false);

            return Ok(attendances);
        }


        [HttpGet("events/{eventId}/attendances/count", Name = "GetAttendanceNumber")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAttendanceNumber(Guid eventId)
        {
            var attendanceNumber = await _service
                .AttendanceService
                .GetAttendanceNumberAsync(eventId,
                trackChanges: false);

            return Ok(attendanceNumber);
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
        /// Adds user attendance to an event
        /// </summary>
        /// <param name="attendanceRequestDto"></param>
        /// <returns>201 status code</returns>
        /// <response code="201">Returns 201 response</response>
        /// <response code="401">Unauthorized access</response>
        [HttpPost("{eventId}/attend", Name = "AttendEvent")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> AddEventAttendance(
            AttendanceRequestDto attendanceRequestDto)
        {
            if (attendanceRequestDto is null)
                return BadRequest("Attendance data is invalid");

            await _service
                .AttendanceService
                .AddEventAttendanceAsync(attendanceRequestDto, trackChanges: true);

            return Ok();

        }



        /// <summary>
        /// Removes user attendance from an event
        /// </summary>
        /// <param name="attendanceRequestDto"></param>
        /// <response code="200">Returns success</response>
        /// <response code="401">Unauthorized access</response>
        [HttpDelete("{eventId}/unattend", Name = "UnattendEvent")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> RemoveEventAttendance(AttendanceRequestDto attendanceRequestDto)
        {
            if (attendanceRequestDto is null)
                return BadRequest("Attendance data is invalid");

            await _service.AttendanceService.DeleteEventAttendanceAsync(attendanceRequestDto,
                trackChanges: true);

            return Ok();
        }
    }
}
