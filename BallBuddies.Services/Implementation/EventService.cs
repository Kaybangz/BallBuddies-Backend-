using AutoMapper;
using BallBuddies.Data.Interface;
using BallBuddies.Models.Dtos.Request;
using BallBuddies.Models.Dtos.Response;
using BallBuddies.Models.Entities;
using BallBuddies.Models.Exceptions;
using BallBuddies.Services.Interface;

namespace BallBuddies.Services.Implementation
{
    public class EventService: IEventService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public EventService(IUnitOfWork unitOfWork,
            ILoggerManager logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<EventResponseDto> CreateEventAsync(EventRequestDto eventRequest)
        {
            var eventEntity = _mapper.Map<Event>(eventRequest);

            _unitOfWork.Event.CreateEvent(eventEntity);
            await _unitOfWork.SaveAsync();

            var eventToReturn = _mapper.Map<EventResponseDto>(eventEntity);

            return eventToReturn;
        }

        public async Task DeleteEventAsync(int eventId, bool trackChanges)
        {
            var existingEvent = await _unitOfWork.Event.GetEventAsync(eventId, trackChanges);

            if (existingEvent is null)
                throw new EventNotFoundException(eventId);
            
            _unitOfWork.Event.DeleteEvent(existingEvent);

            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<EventResponseDto>> GetAllEventsAsync(bool trackChanges)
        {
            
                var events = await _unitOfWork.Event.GetAllEventsAsync(trackChanges);

                var eventsDto = _mapper.Map<IEnumerable<EventResponseDto>>(events);

                return eventsDto;
        }

        public async Task<EventResponseDto> GetEventAsync(int eventId, 
            bool trackChanges)
        {
            var myEvent = await _unitOfWork.Event.GetEventAsync(eventId, trackChanges);

            if (myEvent is null)
                throw new EventNotFoundException(eventId);

            var eventDto = _mapper.Map<EventResponseDto>(myEvent);

            return eventDto;
        }

        public async Task UpdateEventAsync(int eventId, 
            EventRequestDto eventRequest, 
            bool trackChanges)
        {
            var existingEvent = await _unitOfWork.Event.GetEventAsync(eventId, trackChanges);

            if(existingEvent is null)
                throw new EventNotFoundException(eventId);

            var updatedEvent = _mapper.Map(eventRequest, existingEvent);

            _unitOfWork.Event.UpdateEvent(updatedEvent);

            await _unitOfWork.SaveAsync();
        }
    }
}
