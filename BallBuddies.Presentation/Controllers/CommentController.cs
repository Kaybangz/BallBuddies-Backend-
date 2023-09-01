using BallBuddies.Models.Dtos.Request;
using BallBuddies.Services.ActionFilters;
using BallBuddies.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BallBuddies.Presentation.Controllers
{
    [ApiController]
    [Route("api/events/{eventId}/comments")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class CommentController: ControllerBase
    {
        private readonly IServiceManager _service;

        public CommentController(IServiceManager service) => _service = service;



        /// <summary>
        /// Gets all comments for an event
        /// </summary>
        /// <returns>A list of event comments</returns>
        /// <response code="200">Returns a list of event comments</response>
        [HttpGet(Name = "GetAllEventComments")]
        [ProducesResponseType(200)]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllEventComments(Guid eventId)
        {
            var comments = await _service.CommentService.GetCommentsAsync(eventId, trackChanges: false);

            return Ok(comments);
        }


        /// <summary>
        /// Gets single comment for an event
        /// </summary>
        /// <returns>A single event comment</returns>
        /// <response code="200">Returns a single event comment</response>
        [HttpGet("{id:Guid}", Name = "GetSingleEventComment")]
        [ProducesResponseType(200)]
        [AllowAnonymous]
        public async Task<IActionResult> GetEventComment(Guid eventId, Guid id)
        {
            var comment = await _service.CommentService.GetCommentAsync(eventId, id, trackChanges: false);

            return Ok(comment);
        }

        /// <summary>
        /// Create comment for an event
        /// </summary>
        /// <returns>A created comment</returns>
        /// <response code="200">Returns a created event comment</response>
        /// <response code="400">Returns comment request dto is null</response> 
        [HttpPost(Name = "New comment")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> CreateCommentForEvent(Guid eventId,
            [FromBody] CommentRequestDto commentRequest)
        {

            if (commentRequest is null)
                return BadRequest("Comment date is invalid.");

            var commentToReturn = await _service.CommentService.CreateCommentForEventAsync(eventId,
                commentRequest,
                trackChanges: false);

            return CreatedAtRoute("GetSingleEventComment", new
            {
                eventId,
                id = commentToReturn.Id
            }, commentToReturn);
        }



        /// <summary>
        /// Delete comment for an event
        /// </summary>
        /// <returns>Returns no content</returns>
        /// <response code="200">Returns no content</response>
        /// <response code="500">Returns Event does not exist in the database</response>
        [HttpDelete("{id:Guid}", Name = "Delete comment")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> DeleteCommentForEvent(Guid eventId, Guid id)
        {
            await _service.CommentService.DeleteCommentForEvent(eventId, id, trackChanges: false);

            return NoContent();
        }

    }
}
