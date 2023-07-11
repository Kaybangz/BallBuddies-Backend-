using BallBuddies.Models.Dtos.Request;
using BallBuddies.Models.Dtos.Response;
using BallBuddies.Models.Entities;

namespace BallBuddies.Services.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<UserModelResponseDto>> GetAllUsersAsync(bool trackChanges);
        Task<UserModelResponseDto> GetUserAsync(string Id, bool trackChanges);
    }
}
