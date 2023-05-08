using BallBuddies.Data.Context;
using BallBuddies.Data.Interface;

namespace BallBuddies.Data.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BallBuddiesDBContext _dbContext;

        public UnitOfWork(BallBuddiesDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
