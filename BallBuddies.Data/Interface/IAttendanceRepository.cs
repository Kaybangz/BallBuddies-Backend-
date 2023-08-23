using BallBuddies.Models.Entities;

namespace BallBuddies.Data.Interface
{
    public interface IAttendanceRepository
    {
        Task<IEnumerable<Attendance>> GetEventAttendances(Guid eventId, bool trackChanges);
        void AddEventAttendance(Attendance attendance, Guid eventId, string userId);
        void RemoveEventAttendance(Attendance attendance);

        Task<bool> IsUserAttendingEvent(string userId, Guid eventId);
    }
}
