namespace BallBuddies.Models.Dtos.Request
{
    [Serializable]
    public record UserModelRequestDto
    (
        string UserName,
        string Email,
        string PhoneNumber,
        string AvatarUrl
    );
}
