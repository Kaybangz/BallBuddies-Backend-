

namespace BallBuddies.Data.Interface
{
    public interface IUnitOfWork
    {
        IUserAuthentication UserAuthentication { get; }
        IEventRepository Event { get; }
        IAttendanceRepository Attendance { get; }
        ICommentRepository Comment { get; }


        Task Save();
       
    }
}
