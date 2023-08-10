using BallBuddies.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BallBuddies.Presentation.Controllers
{
    [ApiController]
    [Route("api/events/{eventId}/comments")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class CommentsController: ControllerBase
    {
        private readonly IServiceManager _service;

        public CommentsController(IServiceManager service) => _service = service;



        /// <summary>
        /// Gets all comments for an event
        /// </summary>
        /// <returns>A list of event comments</returns>
        /// <response code="200">Returns a list of event comments</response>
        [HttpGet(Name = "Comments")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAllEventComments(int eventId)
        {
            var comments = await _service.CommentService.GetCommentsAsync(eventId, trackChanges: false);

            return Ok(comments);
        }


        /// <summary>
        /// Gets single comment for an event
        /// </summary>
        /// <returns>A single event comment</returns>
        /// <response code="200">Returns a single event comment</response>
        [HttpGet("{id:int}", Name = "Comment")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetEventComment(int eventId, int id)
        {
            var comment = await _service.CommentService.GetCommentAsync(eventId, id, trackChanges: false);

            return Ok(comment);
        }
    }
}
