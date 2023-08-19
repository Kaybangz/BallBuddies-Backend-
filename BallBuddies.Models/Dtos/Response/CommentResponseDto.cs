namespace BallBuddies.Models.Dtos.Response
{
    public record CommentResponseDto(
        Guid Id,
        string Text,
        DateTime CreatedAt,
        string userId
        );
}
