using BallBuddies.Models.Dtos.Request;
using BallBuddies.Models.Dtos.Response;
using BallBuddies.Models.Entities;


namespace BallBuddies.Data.Interface
{
    public interface IEventRepository
    {
       IEnumerable<Event> GetAllEvents(bool trackChanges);
    }
}
