using BallBuddies.Models.Entities;


namespace BallBuddies.Data.Interface
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllEventsAsync(bool trackChanges);
        Task<Event> GetEventAsync(int eventId, bool trackChanges);
        void CreateEvent(Event createdEvent);
        void UpdateEvent(Event updatedEvent);
        void DeleteEvent(Event eventToDelete);
    }
}
