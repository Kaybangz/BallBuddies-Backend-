using BallBuddies.Data.Context;
using BallBuddies.Data.Interface;
using BallBuddies.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BallBuddies.Data.Implementation
{
    public class EventRepository: GenericRepository<Event>, IEventRepository
    {
        public EventRepository(BallBuddiesDBContext dbContext): base(dbContext)
        {}

        public void CreateEvent(string userId, Event createdEvent)
        {
            createdEvent.CreatedByUserId = userId;
            Create(createdEvent);
        }

        public void DeleteEvent(Event eventToDelete) => Delete(eventToDelete);

        public async Task<IEnumerable<Event>> GetAllEvents(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(e => e.Name)
            .ToListAsync();


#pragma warning disable CS8603 // Possible null reference return.
        public async Task<Event> GetEvent(Guid eventId, bool trackChanges) =>
            await FindByCondition(e => e.Id.Equals(eventId), trackChanges)
            .SingleOrDefaultAsync();

        public void UpdateEvent(Event updatedEvent) =>
            Update(updatedEvent);
#pragma warning restore CS8603 // Possible null reference return.
    }
}
