namespace BallBuddies.Data.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChangesAsync();
        Task DisposeAsync();
    }
}
