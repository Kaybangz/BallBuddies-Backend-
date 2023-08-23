

using System.ComponentModel.DataAnnotations;

namespace BallBuddies.Models.Dtos.Request
{
    [Serializable]
    public record UserAuthenticationDto
    {
        [Required(ErrorMessage = "Username is required")]
        public string? UserName { get; init; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; init; }
    }
}
