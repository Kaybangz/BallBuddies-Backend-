using Microsoft.AspNetCore.Identity;

namespace BallBuddies.Models.Entities
{
    public class User : IdentityUser
    {
        public string? AvatarUrl { get; set; }


        //A user can organize many sport events
        public IEnumerable<Event>? Events { get; set; }

        //A user can attend as many events
        public IEnumerable<Attendance>? Attendances { get; set; }
    }
}
