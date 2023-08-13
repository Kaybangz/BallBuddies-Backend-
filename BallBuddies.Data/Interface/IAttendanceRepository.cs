using BallBuddies.Models.Entities;

namespace BallBuddies.Data.Interface
{
    public interface IAttendanceRepository
    {
        Task<IEnumerable<Attendance>> GetEventAttendances(Guid eventId, bool trackChanges);
        void AddEventAttendance(Guid eventId, Attendance attendance);
        void RemoveEventAttendance(Attendance attendance);
    }
}
