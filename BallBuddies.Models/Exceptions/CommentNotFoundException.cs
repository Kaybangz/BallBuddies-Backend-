

namespace BallBuddies.Models.Exceptions
{
    public class CommentNotFoundException : NotFoundException
    {
        public CommentNotFoundException(Guid commentId) 
            : base($"Comment with id: {commentId} doesn't exist in the database.")
        {
        }
    }
}
