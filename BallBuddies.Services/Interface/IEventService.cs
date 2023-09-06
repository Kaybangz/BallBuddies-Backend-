using BallBuddies.Models.Dtos.Request;
using BallBuddies.Models.Dtos.Response;
using BallBuddies.Models.Entities;
using BallBuddies.Models.RequestFeatures;

namespace BallBuddies.Services.Interface
{
    public interface IEventService
    {
        Task<(IEnumerable<EventResponseDto> eventResponseDto,
            MetaData metaData)> GetAllEventsAsync(EventParameters eventParameters,
            bool trackChanges);
        Task<EventResponseDto> GetEventAsync(Guid eventId,
            bool trackChanges);
        Task<IEnumerable<EventResponseDto>> GetEventsCreatedByUserAsync(bool trackChanges);
        Task<EventResponseDto> CreateEventAsync(EventRequestDto eventRequestDto,
            bool trackChanges);
        Task UpdateEventAsync(Guid eventId, 
            EventUpdateRequestDto eventUpdateRequestDto,
            bool trackChanges);

        Task<(EventUpdateRequestDto eventToPatch,
            Event eventEntity)> GetEventForPatch(Guid eventId,
            bool compTrackChanges,
            bool empTrackChanges);

        Task SaveChangesForPatch(EventUpdateRequestDto eventToPatch,
            Event eventEntity);

        Task DeleteEventAsync(Guid eventId, bool trackChanges);
    }
}
