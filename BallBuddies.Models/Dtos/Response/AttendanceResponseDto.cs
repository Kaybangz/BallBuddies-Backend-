namespace BallBuddies.Models.Dtos.Response
{
    public record AttendanceResponseDto
    {
        public Guid EventId { get; set; }
        public string? UserId { get; set; }
    }
}
