using BallBuddies.Models.Enums;


namespace BallBuddies.Models.Dtos.Response
{
    [Serializable]
    public record EventResponseDto(
        int Id,
        string Name,
        string Description,
        decimal Price,
        string EventImageUrl,
        string Venue,
        string State,
        string City,
        DateTime EventStartDate,
        DateTime EventEndDate,
        DateTime CreatedAt,
        SportCategory Category
        );
}
