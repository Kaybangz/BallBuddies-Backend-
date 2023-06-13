

namespace BallBuddies.Data.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IUserAuthentication UserAuthentication { get; }
        /*IEventRepo EventRepo { get; }
        IAttendanceRepo AttendanceRepo { get; }
        ICommentRepo CommentRepo { get; }*/

         
        Task SaveChangesAsync();
        Task DisposeAsync();
    }
}
