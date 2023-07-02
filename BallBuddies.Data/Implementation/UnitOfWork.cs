using BallBuddies.Data.Context;
using BallBuddies.Data.Interface;


namespace BallBuddies.Data.Implementation
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly BallBuddiesDBContext _dbContext;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IEventRepository> _eventRepository;
        private readonly Lazy<IAttendanceRepository> _attendanceRepository;
        private readonly Lazy<ICommentRepository> _commentRepository;

        public UnitOfWork(BallBuddiesDBContext dbContext)
        {
            _dbContext = dbContext;
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(dbContext));
            _eventRepository = new Lazy<IEventRepository>(() => new EventRepository(dbContext));
            _attendanceRepository = new Lazy<IAttendanceRepository>(() => new AttendanceRepository(dbContext));
            _commentRepository = new Lazy<ICommentRepository>(() => new CommentRepository(dbContext));
        }


        public IUserRepository User => _userRepository.Value;

        public IEventRepository Event => _eventRepository.Value;

        public IAttendanceRepository Attendance => _attendanceRepository.Value;

        public ICommentRepository Comment => _commentRepository.Value;

     

        public async Task SaveAsync() => await _dbContext.SaveChangesAsync();
    }
}
