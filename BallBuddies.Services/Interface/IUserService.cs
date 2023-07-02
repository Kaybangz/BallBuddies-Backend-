using BallBuddies.Models.Dtos.Request;
using BallBuddies.Models.Dtos.Response;
using BallBuddies.Models.Entities;

namespace BallBuddies.Services.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync(bool trackChanges);
        Task<User> GetUserAsync(string Id, bool trackChanges);
    }
}
