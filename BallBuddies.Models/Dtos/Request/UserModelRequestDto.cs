namespace BallBuddies.Models.Dtos.Request
{
    public record UserModelRequestDto
    (
        string UserName,
        string Email,
        string PhoneNumber,
        string AvatarUrl
    );
}
