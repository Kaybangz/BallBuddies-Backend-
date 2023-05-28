using BallBuddies.Data.Configuration;
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

        public DbSet<Event> Events { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Comment> Comments { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.ApplyConfiguration(new RoleConfiguration());

            builder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }

    }

}
