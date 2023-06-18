using BallBuddies.Data.Interface;
using BallBuddies.Models.Entities;
using BallBuddies.Services.Interface;

namespace BallBuddies.Services.Implementation
{
    public class EventService: IEventService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerManager _logger;

        public EventService(IUnitOfWork unitOfWork, ILoggerManager logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public IEnumerable<Event> GetAllEvents(bool trackChanges)
        {
            try
            {
                var events = _unitOfWork.Event.GetAllEvents(trackChanges);

                return events;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllEvents)} service method {ex}");
                throw;
            }
        }
    }
}
