

using BallBuddies.Models.Entities;

namespace BallBuddies.Data.Interface
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetComments(int eventId, bool trackChanges);
        Task<Comment> GetComment(int eventId, int commentId, bool trackChanges);
        void CreateCommentForEvent(int eventId, Comment comment);
        Task DeleteCommentForEvent(int eventId, int commentId);
    }
}
