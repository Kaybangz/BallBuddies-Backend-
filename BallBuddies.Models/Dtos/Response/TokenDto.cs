namespace BallBuddies.Models.Dtos.Response
{
    [Serializable]
    public record TokenDto(
        string AccessToken,
        string RefreshToken
        );
}
