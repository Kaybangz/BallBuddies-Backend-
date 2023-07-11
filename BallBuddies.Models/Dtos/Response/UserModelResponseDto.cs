namespace BallBuddies.Models.Dtos.Response
{
    public record UserModelResponseDto
    (
        string Id,
        string UserName,
        string Email,
        string PhoneNumber,
        string AvatarUrl
    );
}
