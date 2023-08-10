using System.ComponentModel.DataAnnotations;

namespace BallBuddies.Models.Dtos.Request
{
    public record CommentRequestDto
    {
        [Required(ErrorMessage = "Comment text is required.")]
        [MaxLength(300, ErrorMessage = "Comment cannot exceed 300 characters.")]
        public string Text { get; set; } = null!;
        public string UserId { get; set; } = null!;
    }
}
