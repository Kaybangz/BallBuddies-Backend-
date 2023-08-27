﻿using BallBuddies.Models.Dtos.Request;
using BallBuddies.Models.Dtos.Response;

namespace BallBuddies.Services.Interface
{
    public interface IUserService
    {
        IQueryable<UserModelResponseDto> GetAllUsersAsync(bool trackChanges);
        Task<UserModelResponseDto> GetUserAsync(string userId, bool trackChanges);
        /*Task<IEnumerable<EventResponseDto>> GetUserEventsAsync(string userId,
            bool trackChanges);
        Task<IEnumerable<AttendanceResponseDto>> GetUserAttendanceAsync(string userId,
            bool trackChanges);*/
        Task UpdateUserAsync(string userId, UserModelRequestDto user, bool trackChanges);
        Task DeleteUserAsync(string userId, bool trackChanges);
    }
}
