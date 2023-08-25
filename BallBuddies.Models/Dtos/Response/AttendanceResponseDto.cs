namespace BallBuddies.Models.Dtos.Response
{
    [Serializable]
    public record AttendanceResponseDto
    {
        /*public Guid EventId { get; set; }*/
        public string? UserId { get; set; }
    }
}
