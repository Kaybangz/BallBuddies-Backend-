

using BallBuddies.Models.Entities;

namespace BallBuddies.Data.Interface
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetComments(Guid eventId, bool trackChanges);
        Task<Comment> GetComment(Guid eventId, Guid commentId, bool trackChanges);
        void CreateCommentForEvent(string userId, Guid eventId, Comment comment);
        void DeleteCommentForEvent(Comment comment);
    }
}
