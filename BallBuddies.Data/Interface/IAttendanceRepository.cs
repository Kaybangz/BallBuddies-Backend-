using BallBuddies.Models.Entities;

namespace BallBuddies.Data.Interface
{
    public interface IAttendanceRepository
    {
        IEnumerable<Attendance> GetAttendances(bool trackChanges);
        void AddAttendance();
        void RemoveAttendance();
    }
}
