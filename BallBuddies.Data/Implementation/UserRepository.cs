using BallBuddies.Data.Context;
using BallBuddies.Data.Interface;
using BallBuddies.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BallBuddies.Data.Implementation
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {

        public UserRepository(BallBuddiesDBContext dbContext): base(dbContext)
        {}

        public void DeleteUser(User user) => Delete(user);

#pragma warning disable CS8603 // Possible null reference return.
        public async Task<User> GetUser(string userId, bool trackChanges) =>
            await FindByCondition(u => u.Id.Equals(userId), trackChanges)
            .SingleOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.

        public async Task<IEnumerable<User>> GetAllUsers(bool trackChanges) => 
            await FindAll(trackChanges)
            .OrderBy(u => u.UserName)
            .ToListAsync();

        public void UpdateUser(User user) => Update(user);

        /*public void UpdateUser(string eventId, User user)
        {
            throw new NotImplementedException();   
        }*/
    }
}
