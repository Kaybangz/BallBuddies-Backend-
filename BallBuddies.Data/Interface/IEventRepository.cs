using BallBuddies.Models.Entities;


namespace BallBuddies.Data.Interface
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllEvents(bool trackChanges);
        Task<Event> GetEvent(Guid eventId, bool trackChanges);
        void CreateEvent(string userId,Event createdEvent);
        void UpdateEvent(Event updatedEvent);
        void DeleteEvent(Event eventToDelete);
    }
}
