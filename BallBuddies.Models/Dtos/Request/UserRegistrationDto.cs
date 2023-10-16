using System.ComponentModel.DataAnnotations;

namespace BallBuddies.Models.Dtos.Request
{
    [Serializable]
    public record UserRegistrationDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required")]
        [MaxLength(50, ErrorMessage = "Username cannot exceed 50 characters")]
        [DataType(DataType.Text)]
        public string UserName { get; init; } = null!;


        [MaxLength(13, ErrorMessage = "Phone number must not exceed 13 digits")]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; init; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [MaxLength(15, ErrorMessage = "Password cannot exceed 15 characters")]
        [DataType(DataType.Password)]
        public string Password { get; init; } = null!;


        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Both password and confirm password must match")]
        public string ConfirmPassword { get; init; } = null!;


        public virtual ICollection<string>? Roles { get; init; } = new List<string> { "User" };

    }
}
