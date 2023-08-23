using BallBuddies.Data.Context;
using BallBuddies.Data.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BallBuddies.Data.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        protected BallBuddiesDBContext _dbContext;

        public GenericRepository(BallBuddiesDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Any(Expression<Func<T, bool>> predicate) => 
            await _dbContext.Set<T>().AnyAsync(predicate);

        public async Task Create(T entity) =>  await _dbContext.Set<T>().AddAsync(entity);

        public void Delete(T entity) => _dbContext?.Set<T>().Remove(entity);

        public IQueryable<T> FindAll(bool trackChanges) => !trackChanges ?
            _dbContext.Set<T>()
            .AsNoTracking() :
            _dbContext.Set<T>();

        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate) =>
            await _dbContext?
            .Set<T>()
            .FirstOrDefaultAsync(predicate);

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
            bool trackChanges) =>
            !trackChanges ?
            _dbContext.Set<T>()
            .Where(expression)
            .AsNoTracking() :
            _dbContext.Set<T>()
            .Where(expression);
        public void Update(T entity) =>  _dbContext.Set<T>().Update(entity);
    }
}
