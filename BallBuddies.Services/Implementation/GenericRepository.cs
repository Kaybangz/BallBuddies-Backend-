using BallBuddies.Data.Context;
using BallBuddies.Data.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BallBuddies.Services.Implementation
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        private readonly BallBuddiesDBContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(BallBuddiesDBContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }



        public virtual async Task Add(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual async Task Delete(string id, TEntity entity)
        {
            var existingEntity = await _dbSet.FindAsync(id);

            if (existingEntity != null)
                _dbSet.Remove(existingEntity);

        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            
        }

        public virtual async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync<TId>(TId id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _dbSet.FindAsync(id);
#pragma warning restore CS8603 // Possible null reference return.
        }

       /* public virtual async Task Update(string id, TEntity entity)
        {
            var existingEntity = await _dbSet.FindAsync(id);

            if (existingEntity != null)
                _dbSet.Update(existingEntity);
        }*/

        public virtual void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
