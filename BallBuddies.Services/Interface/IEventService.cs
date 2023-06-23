using BallBuddies.Models.Dtos.Request;
using BallBuddies.Models.Dtos.Response;

namespace BallBuddies.Services.Interface
{
    public interface IEventService
    {
        Task<IEnumerable<EventResponseDto>> GetAllEventsAsync(bool trackChanges);
        Task<EventResponseDto> GetEventAsync(int eventId, bool trackChanges);
        EventResponseDto CreateEvent(EventRequestDto eventRequest);
    }
}
