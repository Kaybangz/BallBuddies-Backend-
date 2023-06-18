using BallBuddies.Data.Context;
using BallBuddies.Data.Interface;
using BallBuddies.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallBuddies.Data.Implementation
{
    public class EventRepository: GenericRepository<Event>, IEventRepository
    {
        public EventRepository(BallBuddiesDBContext dbContext): base(dbContext)
        {}
    }
}
