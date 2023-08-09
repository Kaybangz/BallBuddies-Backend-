

using BallBuddies.Models.Dtos.Response;

namespace BallBuddies.Services.Interface
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentResponseDto>> GetCommentsAsync(int eventId, bool trackChanges);
    }
}
