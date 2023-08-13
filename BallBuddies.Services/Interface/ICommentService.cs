

using BallBuddies.Models.Dtos.Request;
using BallBuddies.Models.Dtos.Response;

namespace BallBuddies.Services.Interface
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentResponseDto>> GetCommentsAsync(Guid eventId, bool trackChanges);

        Task<CommentResponseDto> GetCommentAsync(Guid eventId, Guid commentId, bool trackChanges);

        Task<CommentResponseDto> CreateCommentForEventAsync(Guid eventId,
            CommentRequestDto commentRequestDto,
            bool trackChanges);

        Task DeleteCommentForEvent(Guid eventId, Guid commentId, bool trackChanges);
    }
}
