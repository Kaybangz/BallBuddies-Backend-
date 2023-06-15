using BallBuddies.Data.Interface;
using BallBuddies.Models.Entities;
using BallBuddies.Data.Context;

namespace BallBuddies.Services.Implementation
{
    public class EventRepo: GenericRepository<Event>, IEventRepo
    {

        public EventRepo(BallBuddiesDBContext dbContext): base(dbContext)
        {
        }


    }
}
