﻿using BallBuddies.Models.Enums;


namespace BallBuddies.Models.Dtos.Response
{
    [Serializable]
    public record EventResponseDto(
        Guid Id,
        string Name,
        string Description,
        decimal Price,
        string EventImageUrl,
        uint Slots,
        string Venue,
        string State,
        string City,
        DateTime EventStartDate,
        DateTime EventEndDate,
        DateTime CreatedAt,
        SportCategory Category,

        string CreatedByUserId
        );
}
