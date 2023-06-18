using BallBuddies.Models.Enums;


namespace BallBuddies.Models.Dtos.Response
{

    public record EventResponseDto(
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
        EventStatus Status
        );
}
