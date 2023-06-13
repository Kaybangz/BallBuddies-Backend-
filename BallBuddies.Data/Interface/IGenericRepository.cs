using System.Linq.Expressions;

namespace BallBuddies.Data.Interface
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetByIdAsync<TId>(TId id);
        Task Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity); 
    }
}
