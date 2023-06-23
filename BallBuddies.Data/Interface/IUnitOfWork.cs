

namespace BallBuddies.Data.Interface
{
    public interface IUnitOfWork
    {
        IEventRepository Event { get; }
        IAttendanceRepository Attendance { get; }
        ICommentRepository Comment { get; }


        Task SaveAsync();
       
    }
}
