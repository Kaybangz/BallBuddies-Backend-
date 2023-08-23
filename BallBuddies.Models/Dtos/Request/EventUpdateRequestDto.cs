using BallBuddies.Models.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace BallBuddies.Models.Dtos.Request
{
    [Serializable]
    public record EventUpdateRequestDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "The event name is required")]
        [MaxLength(50, ErrorMessage = "Cannot exceed 50 characters")]
        public string Name { get; set; } = null!;
        [MaxLength(150, ErrorMessage = "Cannot exceed 150 characters")]
        public string? Description { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        public string? EventImageUrl { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Location is required")]
        [MaxLength(150, ErrorMessage = "Cannot exceed 150 characters")]
        public string Location { get; set; } = null!;

        [Required(AllowEmptyStrings = false, ErrorMessage = "State is required")]
        [MaxLength(150, ErrorMessage = "Cannot exceed 150 characters")]
        public string State { get; set; } = null!;

        [Required(AllowEmptyStrings = false, ErrorMessage = "City is required")]
        [MaxLength(150, ErrorMessage = "Cannot exceed 150 characters")]
        public string City { get; set; } = null!;
        public DateTime EventDate { get; set; }
        public SportCategory Category { get; set; }
    }
}
