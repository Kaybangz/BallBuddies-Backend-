using BallBuddies.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BallBuddies.Models.Entities
{
    public class Event
    {
        [Key]
        public Guid Id{ get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "The event name is required")]
        [MaxLength(50, ErrorMessage = "Cannot exceed 50 characters")]
        public string Name { get; set; } = null!;
        [MaxLength(150, ErrorMessage = "Cannot exceed 150 characters")]
        public string? Description { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        public string? EventImageUrl { get; set; }

        [Required(ErrorMessage = "Specify number of slots")]
        public uint Slots { get; set; }  

        [Required(AllowEmptyStrings = false, ErrorMessage = "Location is required")]
        [MaxLength(150, ErrorMessage = "Cannot exceed 150 characters")]
        public string Venue { get; set; } = null!;

        [Required(AllowEmptyStrings = false, ErrorMessage = "State is required")]
        [MaxLength(150, ErrorMessage = "Cannot exceed 150 characters")]
        public string State { get; set; } = null!;

        [Required(AllowEmptyStrings = false, ErrorMessage = "City is required")]
        [MaxLength(150, ErrorMessage = "Cannot exceed 150 characters")]
        public string City { get; set; } = null!;
        public DateTime EventStartDate { get; set; }
        public DateTime EventEndDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public SportCategory Category { get; set; }


        //An event can be created by only 1 user
        [ForeignKey("User")]
        public string CreatedByUserId { get; set; } = null!;
        public User CreatedByUser { get; set; } = null!;


        //An event can have many attendees
        public IEnumerable<Attendance>? Attendances { get; set; }


        //An event can have many comments
        public IEnumerable<Comment>? Comments { get; set; }
    }
}
