namespace BallBuddies.Data.Interface
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
