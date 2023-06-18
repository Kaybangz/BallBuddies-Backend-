using BallBuddies.Data.Context;
using BallBuddies.Data.Interface;
using BallBuddies.Models.Entities;

namespace BallBuddies.Data.Implementation
{
    public class EventRepository: GenericRepository<Event>, IEventRepository
    {
        public EventRepository(BallBuddiesDBContext dbContext): base(dbContext)
        {}

        public IEnumerable<Event> GetAllEvents(bool trackChanges) => 
            FindAll(trackChanges)
            .OrderBy(e => e.Name)
            .ToList();
    }
}
