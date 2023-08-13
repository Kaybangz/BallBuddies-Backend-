using BallBuddies.Models.Entities;

namespace BallBuddies.Data.Interface
{
    public interface IAttendanceRepository
    {
        Task<IEnumerable<Attendance>> GetEventAttendances(int eventId, bool trackChanges);
        void AddEventAttendance(int eventId, Attendance attendance);
        void RemoveEventAttendance(Attendance attendance);
    }
}
