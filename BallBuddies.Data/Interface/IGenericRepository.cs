namespace BallBuddies.Data.Interface
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync<TId>(TId id);
        Task Add(TEntity entity);
        Task Update(string id, TEntity entity);
        Task Delete(string id, TEntity entity);
    }
}
