using BallBuddies.Models.Dtos.Request;
using BallBuddies.Models.Dtos.Response;

namespace BallBuddies.Services.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<UserModelResponseDto>> GetAllUsersWithRolesAsync(bool trackChanges);
        Task<UserModelResponseDto> GetUserAsync(string userId, bool trackChanges);
        /*Task<IEnumerable<EventResponseDto>> GetUserEventsAsync(string userId,
            bool trackChanges);
        Task<IEnumerable<AttendanceResponseDto>> GetUserAttendanceAsync(string userId,
            bool trackChanges);*/
        Task UpdateUserAsync(UserModelRequestDto userModelRequestDto, bool trackChanges);
        Task<bool> UpdateUserRolesAsync(string userId, UserRolesDto userRolesDto, bool trackChanges);
        Task DeleteUserAsync(string userId, bool trackChanges);
    }
}
