

using BallBuddies.Models.Entities;

namespace BallBuddies.Data.Interface
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetAllEventComments(int eventId, bool trackChanges);
        /*Task CreateCommentForEvent(Comment comment);*/
    }
}
