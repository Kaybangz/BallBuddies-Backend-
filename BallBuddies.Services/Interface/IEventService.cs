using BallBuddies.Models.Dtos.Request;
using BallBuddies.Models.Dtos.Response;

namespace BallBuddies.Services.Interface
{
    public interface IEventService
    {
        Task<IEnumerable<EventResponseDto>> GetAllEventsAsync(bool trackChanges);
        Task<EventResponseDto> GetEventAsync(int eventId, bool trackChanges);
        Task<EventResponseDto> CreateEventAsync(EventRequestDto eventRequest);
        Task UpdateEventAsync(int eventId, EventRequestDto eventRequest, bool trackChanges);
        Task DeleteEventAsync(int eventId, bool trackChanges);
    }
}
