namespace BallBuddies.Models.Dtos.Response
{
    public record CommentResponseDto(
        int Id,
        string Text,
        DateTime CreatedAt
        );
}
