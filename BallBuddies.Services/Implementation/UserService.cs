using AutoMapper;
using BallBuddies.Data.Interface;
using BallBuddies.Models.Dtos.Request;
using BallBuddies.Models.Dtos.Response;
using BallBuddies.Models.Entities;
using BallBuddies.Models.Exceptions;
using BallBuddies.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BallBuddies.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IUnitOfWork unitOfWork,
            UserManager<User> userManager,
            ILoggerManager logger,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
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


        public async Task<IEnumerable<UserModelResponseDto>> GetAllUsersWithRolesAsync(bool trackChanges)
        {
            /*var users = await _unitOfWork.User.GetAllUsers(trackChanges);*/
            var users = await _userManager.Users.ToListAsync();

            var userDtos = new List<UserModelResponseDto>();

            foreach(var user in users)
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var userDto = _mapper.Map<UserModelResponseDto>(user);

                userDto.Roles = userRoles.ToList();

                userDtos.Add(userDto);
            }

            

            return userDtos;
        }



        public async Task<UserModelResponseDto> GetUserAsync(string userId, bool trackChanges)
        {
            var user = await _unitOfWork.User.GetUser(userId, trackChanges);

            if (user is null)
                throw new UserNotFoundException(userId);

            var userDto = _mapper.Map<UserModelResponseDto>(user);

            return userDto;
        }

       
        /*public async Task UpdateUserAsync(
            UserModelRequestDto userModelRequestDto,
            bool trackChanges)
        {
            var userId = _httpContextAccessor
                .HttpContext
                ?.User
                .FindFirst(ClaimTypes.NameIdentifier)
                ?.Value;


            var existingUser = await _userManager.FindByIdAsync(userId);


            var updatedUser = _mapper.Map(userModelRequestDto, existingUser);

            _unitOfWork.User.UpdateUser(updatedUser);

            await _unitOfWork.SaveAsync();
        }*/

        public async Task<bool> UpdateUserRolesAsync(string userId, UserRolesDto userRolesDto , bool trackChanges)
        {
            var user = await FindUserAsync(userId);

            /*var userDto = _mapper.Map(userModelRequest, user);*/

            var existingRoles = await _userManager.GetRolesAsync(user);


            var rolesToAdd = userRolesDto.Roles.Except(existingRoles);
            /*var rolesToAdd = newRoles.Except(existingRoles);*/
            var rolesToRemove = existingRoles.Except(userRolesDto.Roles);


            await _userManager.AddToRolesAsync(user, rolesToAdd);
            await _userManager.RemoveFromRolesAsync(user, rolesToRemove);


            return true;


        }

        public async Task<User> FindUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if(user is null)
                throw new UserNotFoundException(userId);

            return user;
        }
    }
}
