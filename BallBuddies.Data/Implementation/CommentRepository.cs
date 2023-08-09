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

        public Task CreateCommentForEvent(int eventId, Comment comment)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCommentForEvent(int eventId, int commentId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Comment>> GetComments(int eventId, bool trackChanges) => 
            await FindByCondition(c => c.EventId.Equals(eventId), trackChanges)
            .OrderBy(c => c.CreatedAt)
            .ToListAsync();

        public Task<Comment> GetComment(int eventId, int commentId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        /*public Task<IEnumerable<Comment>> GetComments(int eventId, bool trackChanges)
        {
            throw new NotImplementedException();
        }*/
    }
}
