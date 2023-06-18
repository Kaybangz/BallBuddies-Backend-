using BallBuddies.Data.Interface;
using BallBuddies.Services.Interface;
using System;


namespace BallBuddies.Services.Implementation
{
    public class ServiceManager : IServiceManager
    {

        private readonly Lazy<IEventService> _eventService;
        private readonly Lazy<IAttendanceService> _attendanceService;
        private readonly Lazy<ICommentService> _commentService;


        public ServiceManager(IUnitOfWork unitOfWork, ILoggerManager logger)
        {
            _eventService = new Lazy<IEventService>(() => new EventService(unitOfWork, logger));
            _attendanceService = new Lazy<IAttendanceService>(() => new AttendanceService(unitOfWork, logger));
            _commentService = new Lazy<ICommentService>(() => new CommentService(unitOfWork, logger));
        }

        public IEventService EventService => _eventService.Value;
        public IAttendanceService AttendanceService => _attendanceService.Value;
        public ICommentService CommentService => _commentService.Value;
    }

}
