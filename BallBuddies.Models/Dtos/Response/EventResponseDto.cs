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
        string Location,
        string State,
        string City,
        DateTime EventDate,
        DateTime CreatedAt,
        SportCategory Category,

        string CreatedByUserId
        );
}
