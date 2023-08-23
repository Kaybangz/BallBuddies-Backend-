namespace BallBuddies.Models.Dtos.Response
{
    [Serializable]
    public record CommentResponseDto(
        Guid Id,
        string Text,
        DateTime CreatedAt,
        string userId
        );
}
