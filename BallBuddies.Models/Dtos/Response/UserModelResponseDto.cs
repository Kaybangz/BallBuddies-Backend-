namespace BallBuddies.Models.Dtos.Response
{
    [Serializable]
    public record UserModelResponseDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string AvatarUrl { get; set; }
        public ICollection<string> Roles { get; set; }
    }
}
