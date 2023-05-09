using BallBuddies.Data.Context;
using BallBuddies.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace BallBuddies.Data.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        protected readonly BallBuddiesDBContext _dbContext;

        internal DbSet<T> _DbSet { get; set; }

        public GenericRepository(BallBuddiesDBContext dbContext)
        {
            _dbContext = dbContext;
            _DbSet = _dbContext.Set<T>();
        }


        public virtual Task<bool> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _DbSet.ToListAsync();
        }

        public virtual Task<T> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
