namespace BallBuddies.Models.Exceptions
{
    public sealed class EventNotFoundException : NotFoundException
    {
        public EventNotFoundException(int eventId) : base($"The event with the Id: {eventId} doesn't exist in the database.")
        {
        }
    }
}
