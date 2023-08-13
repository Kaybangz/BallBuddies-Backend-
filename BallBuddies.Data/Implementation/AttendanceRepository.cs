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

        public void AddEventAttendance(int eventId, Attendance attendance)
        {
            attendance.EventId = eventId;
            Create(attendance);
        }

        public async Task<IEnumerable<Attendance>> GetEventAttendances(int eventId, bool trackChanges) =>
            await FindByCondition(a => a.EventId.Equals(eventId), trackChanges)
            .ToListAsync();

        public void RemoveEventAttendance(Attendance attendance) => Delete(attendance);
    }
}
