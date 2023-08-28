using BallBuddies.Models.Dtos.Request;
using BallBuddies.Models.Dtos.Response;
using BallBuddies.Models.RequestFeatures;

namespace BallBuddies.Services.Interface
{
    public interface IEventService
    {
        Task<IEnumerable<EventResponseDto>> GetAllEventsAsync(EventParameters eventParameters, bool trackChanges);
        Task<EventResponseDto> GetEventAsync(Guid eventId, bool trackChanges);
        Task<IEnumerable<EventResponseDto>> GetEventsCreatedByUserAsync(bool trackChanges);
        Task<EventResponseDto> CreateEventAsync(EventRequestDto eventRequestDto, bool trackChanges);
        Task UpdateEventAsync(Guid eventId, EventUpdateRequestDto eventUpdateRequestDto, bool trackChanges);
        Task DeleteEventAsync(Guid eventId, bool trackChanges);
    }
}
