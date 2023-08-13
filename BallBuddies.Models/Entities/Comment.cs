using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BallBuddies.Models.Entities
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter a comment")]
        [MaxLength(300, ErrorMessage = "Comment cannot exceed 300 characters")]
        public string Text { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.Now;


        [ForeignKey("User")]
        public string UserId { get; set; } = null!;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public User User { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [ForeignKey("Event")]
        public Guid EventId { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Event Event { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
