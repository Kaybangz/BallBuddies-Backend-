using AutoMapper;
using BallBuddies.Data.Interface;
using BallBuddies.Models.ConfigurationModels;
using BallBuddies.Models.Entities;
using BallBuddies.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;


namespace BallBuddies.Services.Implementation
{
    public class ServiceManager : IServiceManager
    {

        private readonly Lazy<IEventService> _eventService;
        private readonly Lazy<IAttendanceService> _attendanceService;
        private readonly Lazy<ICommentService> _commentService;
        private readonly Lazy<IAuthenticationService> _authenticationService;


        public ServiceManager(IUnitOfWork unitOfWork,
            ILoggerManager logger,
            IMapper mapper,
            UserManager<User> userManager,
            IOptions<JwtConfiguration> configuration)
        {
            _eventService = new Lazy<IEventService>(() => 
            new EventService(unitOfWork, logger, mapper));

            _attendanceService = new Lazy<IAttendanceService>(() =>
            new AttendanceService(unitOfWork, logger, mapper));

            _commentService = new Lazy<ICommentService>(() => 
            new CommentService(unitOfWork, logger, mapper));

            _authenticationService = new Lazy<IAuthenticationService>(() =>
            new AuthenticationService(logger, mapper, userManager, configuration));
        }

        public IEventService EventService => _eventService.Value;
        public IAttendanceService AttendanceService => _attendanceService.Value;
        public ICommentService CommentService => _commentService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }

}
