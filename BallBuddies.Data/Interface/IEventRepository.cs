using BallBuddies.Models.Entities;


namespace BallBuddies.Data.Interface
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllEvents(bool trackChanges);
        Task<Event> GetEvent(Guid eventId, bool trackChanges);

        Task<IEnumerable<Event>> GetEventsCreatedByUser(string userId, bool trackChanges);
        Task CreateEvent(string userId, Event createdEvent);
        void UpdateEvent(Event updatedEvent);
        void DeleteEvent(Event eventToDelete);
    }
}
