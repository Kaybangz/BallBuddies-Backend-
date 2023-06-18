using AutoMapper;
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


        public ServiceManager(IUnitOfWork unitOfWork,
            ILoggerManager logger,
            IMapper mapper)
        {
            _eventService = new Lazy<IEventService>(() => new EventService(unitOfWork, logger, mapper));
            _attendanceService = new Lazy<IAttendanceService>(() => new AttendanceService(unitOfWork, logger, mapper));
            _commentService = new Lazy<ICommentService>(() => new CommentService(unitOfWork, logger, mapper));
        }

        public IEventService EventService => _eventService.Value;
        public IAttendanceService AttendanceService => _attendanceService.Value;
        public ICommentService CommentService => _commentService.Value;
    }

}
