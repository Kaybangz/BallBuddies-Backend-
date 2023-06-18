using BallBuddies.Data.Context;
using BallBuddies.Data.Interface;
using BallBuddies.Models.Entities;

namespace BallBuddies.Data.Implementation
{
    public class AttendanceRepository: GenericRepository<Attendance>, IAttendanceRepository
    {
        public AttendanceRepository(BallBuddiesDBContext dbContext): base(dbContext)
        {}
    }
}
