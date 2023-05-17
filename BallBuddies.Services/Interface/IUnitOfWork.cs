namespace BallBuddies.Services.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChangesAsync();
        Task DisposeAsync();

        IUserAuthentication UserAuthentication { get; }
    }
}
