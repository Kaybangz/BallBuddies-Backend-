using BallBuddies.Data.Configuration;
using BallBuddies.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
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
            

            /*builder.ApplyConfiguration(new EventConfiguration());*/
            builder.ApplyConfiguration(new RoleConfiguration());

            builder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();


            builder.Entity<Event>()
                .HasOne<User>(e => e.CreatedByUser)
                .WithMany(u => u.Events)
                .HasForeignKey(e => e.CreatedByUserId)
                .IsRequired();

            builder.Entity<Attendance>()
                .HasOne(a => a.Event)
                .WithMany(e => e.Attendances)
                .HasForeignKey(a => a.EventId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Comment>()
                .HasOne(a => a.Event)
                .WithMany(e => e.Comments)
                .HasForeignKey(a => a.EventId)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(builder);
        }

    }

}
