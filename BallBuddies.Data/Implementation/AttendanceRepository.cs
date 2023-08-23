using BallBuddies.Data.Context;
using BallBuddies.Data.Interface;
using BallBuddies.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BallBuddies.Data.Implementation
{
    public class AttendanceRepository: GenericRepository<Attendance>, IAttendanceRepository
    {
        public AttendanceRepository(BallBuddiesDBContext dbContext): base(dbContext)
        {}

        public void AddEventAttendance(Attendance attendance, Guid eventId, string userId)
        {
            attendance.UserId = userId;
            attendance.EventId = eventId;
            Create(attendance);
        }

        public async Task<IEnumerable<Attendance>> GetEventAttendances(Guid eventId,
            bool trackChanges) =>
            await FindByCondition(a => a.EventId.Equals(eventId), trackChanges)
            .ToListAsync();

        public async Task<bool> IsUserAttendingEvent(string userId,
            Guid eventId) => await
            Any(a => a.UserId ==  userId && a.EventId == eventId);

        public void RemoveEventAttendance(Attendance attendance) => Delete(attendance);
    }
}
