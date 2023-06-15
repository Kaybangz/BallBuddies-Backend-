using BallBuddies.Data.Interface;
using BallBuddies.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Salesforce.Common.Models.Json;
using Swashbuckle.AspNetCore.Annotations;

namespace BallBuddies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet("Events")]
        /*[SwaggerOperation(Summary = "Gets all events")]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Gets all events", Type = typeof(SuccessResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Something went wrong", Type = typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "It's not you, it's us", Type = typeof(ErrorResponse))]*/
        public ActionResult<IEnumerable<Event>> GetEvents()
        {
            var events = _unitOfWork.EventRepo.GetAllAsync();

            return Ok(events); 
        }

        [HttpGet("Event/:id")]
        public async Task  GetEvent(int id)
        {

        }

    }
}
