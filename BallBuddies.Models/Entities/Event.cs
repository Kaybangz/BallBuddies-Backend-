using BallBuddies.Models.Enums;

namespace BallBuddies.Models.Entities
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Location { get; set; } = null!;
        public DateTime Date { get; set; }
        public SportCategory Category { get; set; }

        //An event can be created by only 1 user
        public string CreatedByUserId { get; set; } = null!;
        public User CreatedByUser { get; set; } = null!;


        //An event can have many attendees
        public IEnumerable<Attendance>? Attendances { get; set; }
    }
}
