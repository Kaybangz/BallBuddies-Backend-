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
        /*[Authorize(Roles = "Admin")]
        [Authorize(Roles = "User")]*/
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
        [HttpGet("{id:int}", Name = "GetSingleEvent")]
        /*[Authorize(Roles = "Admin")]
        [Authorize(Roles = "User")]*/
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> GetEvent(int id)
        {
            var myEvent = await _service.EventService.GetEventAsync(id, trackChanges: false);

            return Ok(myEvent);
        }





        /// <summary>
        /// Creates a new event
        /// </summary>
        /// <param name="eventRequest"></param>
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
        /*[Authorize(Roles = "Admin")]
        [Authorize(Roles = "User")]*/
        public async Task<IActionResult> CreateEvent([FromBody] EventRequestDto eventRequest)
        {
            if (eventRequest == null)
                return BadRequest("EventRequestDto object is null");

            var createdEvent =  await _service.EventService.CreateEventAsync(eventRequest);

            return CreatedAtRoute("GetSingleEvent", new { id = createdEvent.Id },
                createdEvent);

        }





        /// <summary>
        /// Updates an event
        /// </summary>
        /// <returns>No content</returns>
        /// <response code="404">Returns NotFound error</response>
        /// <response code="401">Returns unauthorized access response</response>
        [HttpPut("{id:int}", Name = "UpdateEvent")]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        /*[Authorize(Roles = "Admin")]
        [Authorize(Roles = "User")]*/
        public async Task<IActionResult> UpdateEvent(int Id,
            [FromBody] EventRequestDto eventRequest)
        {
            if (eventRequest is null)
                return BadRequest("EventRequestDto object is null...");

            await _service.EventService.UpdateEventAsync(Id, eventRequest, trackChanges: true);

            return Ok("Event Updated!");
        }





        /// <summary>
        /// Deletes an event
        /// </summary>
        /// <returns>No content</returns>
        /// <response code="404">Returns NotFound error</response>
        /// <response code="401">Returns unauthorized access response</response>
        [HttpDelete("{id:int}", Name = "DeleteEvent")]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        /*[Authorize(Roles = "Admin")]
        [Authorize(Roles = "User")]*/
        public async Task<IActionResult> DeleteEvent(int Id)
        {
            await _service.EventService.DeleteEventAsync(Id, trackChanges: false);

            return NoContent();

        }
    }
}
