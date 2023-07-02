namespace BallBuddies.Models.Exceptions
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(string userId) : base($"The user with the Id: {userId} doesn't exist in the database.")
        {
        }
    }
}
