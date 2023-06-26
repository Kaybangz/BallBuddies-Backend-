using BallBuddies.Models.Enums;


namespace BallBuddies.Models.Dtos.Response
{
    public class EventResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? EventImageUrl { get; set; }
        public string Location { get; set; } = null!;
        public string State { get; set; } = null!;
        public string City { get; set; } = null!;
        public DateTime EventDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public SportCategory Category { get; set; }


        public string? CreatedByUserId { get; set; }

    }
}
