using BallBuddies.Data.Context;
using BallBuddies.Data.Extensions;
using BallBuddies.Data.Interface;
using BallBuddies.Models.Entities;
using BallBuddies.Models.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace BallBuddies.Data.Implementation
{
    public class EventRepository: GenericRepository<Event>, IEventRepository
    {
        public EventRepository(BallBuddiesDBContext dbContext): base(dbContext)
        {}

        public async Task CreateEvent(string userId, Event createdEvent)
        {
            createdEvent.CreatedByUserId = userId;
            await Create(createdEvent);
        }

        public void DeleteEvent(Event eventToDelete) => Delete(eventToDelete);

        public async Task<PagedList<Event>> GetAllEvents(EventParameters eventParameters,
            bool trackChanges)
        {
            var events = await FindAll(trackChanges)
                .FilterEventsByPrice(eventParameters.MinPrice,
                                     eventParameters.MaxPrice,
                                     eventParameters.MinSlots,
                                     eventParameters.MaxSlots)
                .Search(eventParameters.SearchTerm)
                .Sort(eventParameters.OrderBy)
                .ToListAsync();

            var count = await FindAll(trackChanges)
                .CountAsync();

            return PagedList<Event>.ToPagedList(events,
                eventParameters.PageNumber,
                eventParameters.PageSize);
        } 
            
           


#pragma warning disable CS8603 // Possible null reference return.
        public async Task<Event> GetEvent(Guid eventId, bool trackChanges) =>
            await FindByCondition(e => e.Id.Equals(eventId), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Event>> GetEventsCreatedByUser(string userId,
            bool trackChanges) => 
            await FindByCondition(e => e.CreatedByUserId.Equals(userId), trackChanges)
            .ToListAsync();
       

        public void UpdateEvent(Event updatedEvent) =>
            Update(updatedEvent);
#pragma warning restore CS8603 // Possible null reference return.
    }
}
