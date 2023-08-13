using BallBuddies.Services.Interface;
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
    }
}
