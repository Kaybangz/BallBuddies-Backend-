using BallBuddies.Data.Context;
using BallBuddies.Data.Interface;
using BallBuddies.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BallBuddies.Data.Implementation
{
    public class CommentRepository: GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(BallBuddiesDBContext dbContext): base(dbContext)
        {}

        public async Task<IEnumerable<Comment>> GetAllEventComments(int eventId, bool trackChanges) => 
            await FindByCondition(c => c.EventId.Equals(eventId), trackChanges)
            .OrderBy(c => c.CreatedAt)
            .ToListAsync();
    }
}
