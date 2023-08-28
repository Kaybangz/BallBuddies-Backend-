using BallBuddies.Models.Entities;
using BallBuddies.Models.RequestFeatures;

namespace BallBuddies.Data.Interface
{
    public interface IEventRepository
    {
        Task<PagedList<Event>> GetAllEvents(EventParameters eventParameters, bool trackChanges);
        Task<Event> GetEvent(Guid eventId, bool trackChanges);

        Task<IEnumerable<Event>> GetEventsCreatedByUser(string userId, bool trackChanges);
        Task CreateEvent(string userId, Event createdEvent);
        void UpdateEvent(Event updatedEvent);
        void DeleteEvent(Event eventToDelete);
    }
}
