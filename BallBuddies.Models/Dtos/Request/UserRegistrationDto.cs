using System.ComponentModel.DataAnnotations;

namespace BallBuddies.Models.Dtos.Request
{
    public class UserRegistrationDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required")]
        [MaxLength(50, ErrorMessage = "Username cannot exceed 50 characters")]
        public string UserName { get; init; } = null!;

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Email address is invalid")]
        public string Email { get; init; } = null!;


        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [MaxLength(15, ErrorMessage = "Password cannot exceed 15 characters")]
        public string Password { get; init; } = null!;


        public virtual ICollection<string>? Roles { get; init; }

    }
}
