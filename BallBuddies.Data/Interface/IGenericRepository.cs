using System.Linq.Expressions;

namespace BallBuddies.Data.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        /*Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetByIdAsync<TId>(TId id);
        Task Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);*/
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
