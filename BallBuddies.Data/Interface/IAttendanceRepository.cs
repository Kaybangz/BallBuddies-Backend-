using BallBuddies.Models.Entities;

namespace BallBuddies.Data.Interface
{
    public interface IAttendanceRepository
    {
        Task<IEnumerable<Attendance>> GetEventAttendances(Guid eventId, bool trackChanges);
        Task<int> GetAttendanceNumber(Guid eventId, bool trackChanges);

        Task<IEnumerable<Attendance>> GetUserAttendances(string userId, bool trackChanges);

        Task<Attendance> GetAttendanceAsync(Guid eventId, string userId);

        Task AddEventAttendance(Attendance attendance);
        void RemoveEventAttendance(Attendance attendance);

        Task<bool> IsUserAttendingEvent(string userId, Guid eventId);
    }
}
