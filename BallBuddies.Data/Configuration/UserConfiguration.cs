using BallBuddies.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BallBuddies.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(

                new User
                {
                    Id = Guid.NewGuid().ToString(),
                    

                }

                );
        }
    }
}
