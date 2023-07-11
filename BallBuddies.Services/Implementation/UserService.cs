using AutoMapper;
using BallBuddies.Data.Interface;
using BallBuddies.Models.Dtos.Response;
using BallBuddies.Models.Entities;
using BallBuddies.Models.Exceptions;
using BallBuddies.Services.Interface;

namespace BallBuddies.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork,
            ILoggerManager logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserModelResponseDto>> GetAllUsersAsync(bool trackChanges)
        {
            var users = await _unitOfWork.User.GetAllUsers(trackChanges);

            var usersDto = _mapper.Map<IEnumerable<UserModelResponseDto>>(users);

            return usersDto;
        }



        public async Task<UserModelResponseDto> GetUserAsync(string Id, bool trackChanges)
        {
            var user = await _unitOfWork.User.GetUser(Id, trackChanges);

            if (user is null)
                throw new UserNotFoundException(Id);

            var userDto = _mapper.Map<UserModelResponseDto>(user);

            return userDto;
        }
    }
}
