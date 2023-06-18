using BallBuddies.Data.Context;
using BallBuddies.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallBuddies.Data.Implementation
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly BallBuddiesDBContext _dbContext;
        private readonly Lazy<IEventRepository> _eventRepository;
        private readonly Lazy<IAttendanceRepository> _attendanceRepository;
        private readonly Lazy<ICommentRepository> _commentRepository;

        public UnitOfWork(BallBuddiesDBContext dbContext)
        {
            _dbContext = dbContext;
            _eventRepository = new Lazy<IEventRepository>(() => new EventRepository(dbContext));
            _attendanceRepository = new Lazy<IAttendanceRepository>(() => new AttendanceRepository(dbContext));
            _commentRepository = new Lazy<ICommentRepository>(() => new CommentRepository(dbContext));
        }

        public IUserAuthentication UserAuthentication => throw new NotImplementedException();

        public IEventRepository Event => _eventRepository.Value;

        public IAttendanceRepository Attendance => _attendanceRepository.Value;

        public ICommentRepository Comment => _commentRepository.Value;

     

        public async Task Save() => await _dbContext.SaveChangesAsync();
    }
}
