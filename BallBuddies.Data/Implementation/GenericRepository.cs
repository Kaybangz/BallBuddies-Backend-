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

        public void Create(T entity) =>  _dbContext.Set<T>().Add(entity);

        public void Delete(T entity) => _dbContext?.Set<T>().Remove(entity);

        public IQueryable<T> FindAll(bool trackChanges) => !trackChanges ?
            _dbContext.Set<T>()
            .AsNoTracking() :
            _dbContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ?
            _dbContext.Set<T>()
            .Where(expression)
            .AsNoTracking() :
            _dbContext.Set<T>()
            .Where(expression);
        public void Update(T entity) =>  _dbContext.Set<T>().Update(entity);
    }
}
