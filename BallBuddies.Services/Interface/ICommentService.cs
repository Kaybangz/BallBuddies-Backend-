﻿

using BallBuddies.Models.Dtos.Request;
using BallBuddies.Models.Dtos.Response;

namespace BallBuddies.Services.Interface
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentResponseDto>> GetCommentsAsync(int eventId, bool trackChanges);

        Task<CommentResponseDto> GetCommentAsync(int eventId, int commentId, bool trackChanges);

        Task<CommentResponseDto> CreateCommentForEventAsync(int eventId,
            CommentRequestDto commentRequestDto,
            bool trackChanges);

        Task DeleteCommentForEvent(int eventId, int commentId, bool trackChanges);
    }
}