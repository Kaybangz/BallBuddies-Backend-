namespace BallBuddies.Models.Dtos.Response
{
    public record TokenDto(
        string AccessToken,
        string RefreshToken
        );
}
