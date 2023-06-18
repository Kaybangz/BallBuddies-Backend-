using BallBuddies.Models.Dtos.Response;

namespace BallBuddies.Services.Interface
{
    public interface IEventService
    {
        IEnumerable<EventResponseDto> GetAllEvents(bool trackChanges);
    }
}
