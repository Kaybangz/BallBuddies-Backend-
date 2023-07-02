using BallBuddies.Models.Entities;

namespace BallBuddies.Data.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers(bool trackChanges);
        Task<User> GetUser(string id, bool trackChanges);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
