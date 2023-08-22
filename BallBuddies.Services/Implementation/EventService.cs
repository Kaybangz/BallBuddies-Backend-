using AutoMapper;
using BallBuddies.Data.Interface;
using BallBuddies.Models.Dtos.Request;
using BallBuddies.Models.Dtos.Response;
using BallBuddies.Models.Entities;
using BallBuddies.Models.Exceptions;
using BallBuddies.Services.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BallBuddies.Services.Implementation
{
    public class EventService: IEventService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EventService(IUnitOfWork unitOfWork,
            ILoggerManager logger,
            IMapper mapper,
           IHttpContextAccessor httpContextAccessor
            )
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<EventResponseDto> CreateEventAsync(EventRequestDto eventRequestDto,
            bool trackChanges)
        {
            var userId = _httpContextAccessor
                .HttpContext
                ?.User
                .FindFirst(ClaimTypes.NameIdentifier)
                ?.Value;

            

            var eventEntity = _mapper.Map<Event>(eventRequestDto);


            _unitOfWork.Event.CreateEvent(userId, eventEntity);
            await _unitOfWork.SaveAsync();

            var eventToReturn = _mapper.Map<EventResponseDto>(eventEntity);

            return eventToReturn;
        }

        public async Task DeleteEventAsync(Guid eventId, bool trackChanges)
        {
            var userId = _httpContextAccessor
                .HttpContext
                ?.User
                .FindFirst(ClaimTypes.NameIdentifier)
                ?.Value;

            var existingEvent = await CheckIfEventExists(eventId, trackChanges);

            if (existingEvent.CreatedByUserId != userId)
                throw new UnauthorizedAccessException("You do not have permission to " +
                    "delete this event.");

            _unitOfWork.Event.DeleteEvent(existingEvent);

            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<EventResponseDto>> GetAllEventsAsync(bool trackChanges)
        {
            
                var events = await _unitOfWork.Event.GetAllEvents(trackChanges);

                var eventsDto = _mapper.Map<IEnumerable<EventResponseDto>>(events);

                return eventsDto;
        }

        public async Task<EventResponseDto> GetEventAsync(Guid eventId, 
            bool trackChanges)
        {
            var existingEvent = await CheckIfEventExists(eventId, trackChanges);

            var eventDto = _mapper.Map<EventResponseDto>(existingEvent);

            return eventDto;
        }

        public async Task UpdateEventAsync(Guid eventId, 
            EventUpdateRequestDto eventUpdateRequestDto, 
            bool trackChanges)
        {
            var userId = _httpContextAccessor
                .HttpContext
                ?.User
                .FindFirst(ClaimTypes.NameIdentifier)
                ?.Value;


            var existingEvent = await CheckIfEventExists(eventId, trackChanges);

            if (existingEvent.CreatedByUserId != userId)
                throw new UnauthorizedAccessException("You do not have permission to " +
                    "update this event.");

            var updatedEvent = _mapper.Map(eventUpdateRequestDto, existingEvent);

            _unitOfWork.Event.UpdateEvent(updatedEvent);

            await _unitOfWork.SaveAsync();
        }



        private async Task<Event> CheckIfEventExists(Guid eventId, bool trackChanges)
        {
            var eventEntity = await _unitOfWork.Event.GetEvent(eventId, trackChanges);

            if(eventEntity is null)
            {
                _logger.LogError($"Event with Id: {eventId} not found");
                throw new EventNotFoundException(eventId);
            }
                

            return eventEntity;
        }

    }
}
