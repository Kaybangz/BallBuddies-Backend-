using AutoMapper;
using BallBuddies.Data.Interface;
using BallBuddies.Models.Dtos.Request;
using BallBuddies.Models.Dtos.Response;
using BallBuddies.Models.Entities;
using BallBuddies.Models.Exceptions;
using BallBuddies.Services.Interface;
using Microsoft.AspNetCore.Http;

namespace BallBuddies.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IUnitOfWork unitOfWork,
            ILoggerManager logger,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task DeleteUserAsync(string userId, bool trackChanges)
        {
            var existingUser = await _unitOfWork.User.GetUser(userId, trackChanges);

            if (existingUser != null)
                throw new UserNotFoundException(userId);

#pragma warning disable CS8604 // Possible null reference argument.
            _unitOfWork.User.DeleteUser(existingUser);
#pragma warning restore CS8604 // Possible null reference argument.

            await _unitOfWork.SaveAsync();
        }


        public async Task<IEnumerable<UserModelResponseDto>> GetAllUsersAsync(bool trackChanges)
        {
            var users = await _unitOfWork.User.GetAllUsers(trackChanges);

            var usersDto = _mapper.Map<IEnumerable<UserModelResponseDto>>(users);

            return usersDto;
        }



        public async Task<UserModelResponseDto> GetUserAsync(string userId, bool trackChanges)
        {
            var user = await _unitOfWork.User.GetUser(userId, trackChanges);

            if (user is null)
                throw new UserNotFoundException(userId);

            var userDto = _mapper.Map<UserModelResponseDto>(user);

            return userDto;
        }

        public async Task UpdateUserAsync(string userId,
            UserModelRequestDto userModelRequestDto,
            bool trackChanges)
        {
            var existingUser = await _unitOfWork.User.GetUser(userId, trackChanges);

            if(existingUser is null)
                throw new UserNotFoundException(userId);

            var updatedUser = _mapper.Map(userModelRequestDto, existingUser);

            _unitOfWork.User.UpdateUser(updatedUser);

            await _unitOfWork.SaveAsync();
        }
    }
}
