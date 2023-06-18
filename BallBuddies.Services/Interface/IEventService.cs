using BallBuddies.Models.Entities;
using System;


namespace BallBuddies.Services.Interface
{
    public interface IEventService
    {
        IEnumerable<Event> GetAllEvents(bool trackChanges);
    }
}
