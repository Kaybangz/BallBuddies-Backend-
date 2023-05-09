using System.ComponentModel.DataAnnotations;

namespace BallBuddies.Models.Dtos
{
    public class UserRegistrationDto
    {
        [Required(ErrorMessage = "Username is required", AllowEmptyStrings = false)]
        [MaxLength(50, ErrorMessage = "Username characters cannot exceed 50...")]
        public string UserName { get; init; } = null!;
        [Required(ErrorMessage = "Password is required", AllowEmptyStrings = false)]
        [MaxLength(15, ErrorMessage = "Password characters cannot exceed 15...")]
        public string Password { get; init; } = null!;
        public string? Email { get; init; }
        [MaxLength(13, ErrorMessage = "Phone number must not exceed 13 digits")]
        public string? PhoneNumber { get; set; }
        public IEnumerable<string>? Roles { get; init; }

    }
}
