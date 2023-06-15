using BallBuddies.Data.Context;
using BallBuddies.Data.Interface;
using BallBuddies.Models.Entities;

namespace BallBuddies.Services.Implementation
{
    public class CommentRepo: GenericRepository<Comment>, ICommentRepo
    {
        public CommentRepo(BallBuddiesDBContext dbContext): base(dbContext)
        {
            
        }
    }
}
