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

        public void CreateCommentForEvent(int eventId, Comment comment)
        {
            comment.EventId = eventId;
            Create(comment);
        }

        public void DeleteCommentForEvent(Comment comment) => Delete(comment);
            

        public async Task<IEnumerable<Comment>> GetComments(int eventId, bool trackChanges) => 
            await FindByCondition(c => c.EventId.Equals(eventId), trackChanges)
            .OrderBy(c => c.CreatedAt)
            .ToListAsync();

        public async Task<Comment> GetComment(int eventId, int commentId, bool trackChanges) =>
            await FindByCondition(c => c.EventId.Equals(eventId) && c.Id.Equals(commentId), trackChanges)
            .SingleOrDefaultAsync();

    }
}
