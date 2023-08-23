using BallBuddies.Models.Dtos.Request;
using BallBuddies.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BallBuddies.Presentation.Controllers
{

    [ApiController]
    [Route("api/events/{eventId}/attendances")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class AttendanceController: ControllerBase
    {
        private readonly IServiceManager _service;

        public AttendanceController(IServiceManager service) => _service = service;


        [HttpGet(Name = "GetEventAttendances")]
        public async Task<IActionResult> GetEventAttendances(Guid eventId)
        {
            var attendances = await _service.AttendanceService.GetEventAttendancesAsync(eventId, trackChanges: false);

            return Ok(attendances);
        }

        [HttpPost(Name = "AddEventAttendance")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> AddEventAttendance(
            AttendanceRequestDto attendanceRequestDto)
        {
            if (attendanceRequestDto is null)
                return BadRequest("Attendance data is invalid");

            var attendanceToReturn = await _service
                .AttendanceService
                .AddEventAttendanceAsync(attendanceRequestDto, trackChanges: true);

            return Ok("User has successfully attended event.");

        }
    }
}
