using BallBuddies.Models.Dtos.Request;
using BallBuddies.Services.Interface;
using Microsoft.AspNetCore.Mvc;


namespace BallBuddies.Presentation.Controllers
{

    [ApiController]
    [Route("api/events")]
    public class EventsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public EventsController(IServiceManager service) => _service = service;


        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            var events = await _service.EventService.GetAllEventsAsync(trackChanges: false);

            return Ok(events);

        }

        [HttpGet("{id:int}", Name = "EventById")]
        public async Task<IActionResult> GetEvent(int id)
        {
            var myEvent = await _service.EventService.GetEventAsync(id, trackChanges: false);

            return Ok(myEvent);
        }

        [HttpPost("create event", Name = "Create new event")]
        public async Task<IActionResult> CreateEvent([FromBody] EventRequestDto eventRequest)
        {
            if (eventRequest == null)
                return BadRequest("EventRequestDto object is null");

            var createdEvent =  await _service.EventService.CreateEvent(eventRequest);

            return CreatedAtRoute("EventById", new { id = createdEvent.Id },
                createdEvent);

        }
    }
}
