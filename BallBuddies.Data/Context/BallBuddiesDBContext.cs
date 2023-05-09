using BallBuddies.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BallBuddies.Data.Context
{
    public class BallBuddiesDBContext : IdentityDbContext<User>
    {
        public BallBuddiesDBContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }

}
