﻿using BallBuddies.Models.Dtos.Request;
using BallBuddies.Services.ActionFilters;
using BallBuddies.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BallBuddies.Presentation.Controllers
{

    [ApiController]
    [Route("api/events")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class EventsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public EventsController(IServiceManager service) => _service = service;




        /// <summary>
        /// Gets a list of all events
        /// </summary>
        /// <returns>The event list</returns>
        /// <response code="200">Returns all the events in the database</response>
        /// <response code="401">Returns unauthorized access response</response>
        [HttpGet(Name = "GetAllEvents")]
        [AllowAnonymous]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> GetEvents()
        {
            var events = await _service.EventService.GetAllEventsAsync(trackChanges: false);

            return Ok(events);

        }



        /// <summary>
        /// Gets an event by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A single event</returns>
        /// /// <response code="200">Returns a single event with the Id</response>
        /// <response code="401">Returns unauthorized access response</response>
        [HttpGet("{id:Guid}", Name = "GetSingleEvent")]
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "User")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> GetEvent(Guid id)
        {
            var myEvent = await _service.EventService.GetEventAsync(id, trackChanges: false);

            return Ok(myEvent);
        }




        /// <summary>
        /// Creates a new event
        /// </summary>
        /// <param name="eventRequestDto"></param>
        /// <returns>A newly created event</returns>
        /// <response code="201">Returns the newly created event</response>
        /// <response code="400">If the item is null</response>
        /// <response code="401">Returns unauthorized access response</response>
        /// <response code="422">If the model is invalid</response>
        [HttpPost(Name = "CreateEvent")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        [ProducesResponseType(401)]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> CreateEvent( [FromBody] EventRequestDto eventRequestDto)
        {
            if (eventRequestDto is null)
                return BadRequest("Event data is invalid.");

            var createdEvent =  await _service.EventService.CreateEventAsync(eventRequestDto, trackChanges: true);

            return CreatedAtRoute("GetSingleEvent", new { id = createdEvent.Id },
                createdEvent);

        }



        [HttpGet("{userId}/events", Name = "Current_user_events")]
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> GetCurrentUserEvents()
        {
            var currentUserEvents = await _service.EventService
                .GetEventsCreatedByUserAsync(trackChanges: false);

            return Ok(currentUserEvents);
        }



        /// <summary>
        /// Updates an event
        /// </summary>
        /// <param name="id"></param>
        /// <param name="eventUpdateRequestDto"></param>
        /// <returns>No content</returns>
        /// <response code="404">Returns NotFound error</response>
        /// <response code="401">Returns unauthorized access response</response>
        /// <response code="200">Returns success message</response>
        [HttpPut("{id:Guid}", Name = "UpdateEvent")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> UpdateEvent(Guid id,
            [FromBody] EventUpdateRequestDto eventUpdateRequestDto)
        {
            if(eventUpdateRequestDto is null)
                return BadRequest("Event data is invalid.");

            await _service.EventService.UpdateEventAsync(id, eventUpdateRequestDto, trackChanges: true);

            return NoContent();
        }



        /// <summary>
        /// Deletes an event
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No content</returns>
        /// <response code="404">Returns NotFound error</response>
        /// <response code="401">Returns unauthorized access response</response>
        /// <response code="200">Returns success response</response>
        [HttpDelete("{id:Guid}", Name = "DeleteEvent")]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(200)]
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> DeleteEvent(Guid id)
        {
            await _service.EventService.DeleteEventAsync(id, trackChanges: false);

            return NoContent();

        }
    }
}
