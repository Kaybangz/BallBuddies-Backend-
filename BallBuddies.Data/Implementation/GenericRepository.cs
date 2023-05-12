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


        public virtual async Task<bool> Create(T entity)
        {
            return await _DbSet.AddAsync(entity);
        }

        public virtual async Task<bool> Delete(string id)
        {
            return await _DbSet.Remove(id);
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _DbSet.ToListAsync();
        }

        public virtual Task<T> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
