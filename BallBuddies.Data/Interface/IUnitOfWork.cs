

namespace BallBuddies.Data.Interface
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
        IEventRepository Event { get; }
        IAttendanceRepository Attendance { get; }
        ICommentRepository Comment { get; }


        Task SaveAsync();
       
    }
}
