using BallBuddies.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BallBuddies.Models.Enums;

namespace BallBuddies.Data.Configuration
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasData(

                new Event
                {
                    Id = 1,
                    Name = "3v3 basketball game",
                    Description = "This is a 2-quarter 3v3 basketball game",
                    Price = 1000,
                    EventImageUrl = "",
                    Location = "312c Forest Avenue, BF 923",
                    State = "Lagos",
                    City = "Lagos",
                    EventDate = new DateTime(),
                    Category = SportCategory.Basketball,
                    Status = EventStatus.Upcoming,

                    CreatedByUserId = "1495a2fb - dd14 - 495f - bc82 - e1c425203b4d"

                },
                new Event
                {
                    Id = 2,
                    Name = "Badmiton tournament",
                    Description = "",
                    Price = 500,
                    EventImageUrl = "",
                    Location = "583 Wall Oak, MD 21207",
                    State = "Edo",
                    City = "Benin",
                    EventDate = new DateTime(),
                    Category = SportCategory.Badminton,
                    Status = EventStatus.Ongoing,

                    CreatedByUserId = "1495a2fb - dd14 - 495f - bc82 - e1c425203b4d"

                }

                );
        }
    }
}
