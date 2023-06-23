using BallBuddies.Models.Entities;


namespace BallBuddies.Data.Interface
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllEvents(bool trackChanges);
        Task<Event> GetEvent(int eventId, bool trackChanges);
        void CreateEvent(Event createdEvent);
    }
}
