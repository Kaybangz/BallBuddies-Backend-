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

        public void CreateEvent(Event createdEvent) => Create(createdEvent);

        public async Task<IEnumerable<Event>> GetAllEvents(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(e => e.Name)
            .ToListAsync();
            

        public async Task<Event> GetEvent(int eventId, bool trackChanges) =>
            await FindByCondition(e => e.Id.Equals(eventId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
