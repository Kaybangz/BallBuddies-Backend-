using AutoMapper;
using BallBuddies.Data.Interface;
using BallBuddies.Models.ConfigurationModels;
using BallBuddies.Models.Entities;
using BallBuddies.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;


namespace BallBuddies.Services.Implementation
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IEventService> _eventService;
        private readonly Lazy<IAttendanceService> _attendanceService;
        private readonly Lazy<ICommentService> _commentService;
        private readonly Lazy<IAuthenticationService> _authenticationService;



        public ServiceManager(IUnitOfWork unitOfWork,
            ILoggerManager logger,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<JwtConfiguration> configuration,
            SignInManager<User> signInManager)
        {

            _userService = new Lazy<IUserService>(() => 
            new UserService(unitOfWork, userManager, logger, mapper, httpContextAccessor));

            _eventService = new Lazy<IEventService>(() => 
            new EventService(unitOfWork, logger, mapper, httpContextAccessor));

            _attendanceService = new Lazy<IAttendanceService>(() =>
            new AttendanceService(unitOfWork, logger, mapper, httpContextAccessor));

            _commentService = new Lazy<ICommentService>(() => 
            new CommentService(unitOfWork, logger, mapper, httpContextAccessor));

            _authenticationService = new Lazy<IAuthenticationService>(() =>
            new AuthenticationService(logger, mapper, userManager, roleManager, configuration, signInManager));
        }


        public IUserService UserService => _userService.Value;
        public IEventService EventService => _eventService.Value;
        public IAttendanceService AttendanceService => _attendanceService.Value;
        public ICommentService CommentService => _commentService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }

}
