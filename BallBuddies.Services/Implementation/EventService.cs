﻿using AutoMapper;
using BallBuddies.Data.Interface;
using BallBuddies.Models.Dtos.Request;
using BallBuddies.Models.Dtos.Response;
using BallBuddies.Models.Entities;
using BallBuddies.Models.Exceptions;
using BallBuddies.Services.Interface;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BallBuddies.Services.Implementation
{
    public class EventService: IEventService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        /*private readonly IHttpContextAccessor _httpContextAccessor;*/

        public EventService(IUnitOfWork unitOfWork,
            ILoggerManager logger,
            IMapper mapper
           /*IHttpContextAccessor httpContextAccessor*/
            )
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            /*_httpContextAccessor = httpContextAccessor;*/
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
            /*var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;*/

            var existingEvent = await _unitOfWork.Event.GetEvent(eventId, trackChanges);
            

            if (existingEvent is null)
                throw new EventNotFoundException(eventId);
            
            _unitOfWork.Event.DeleteEvent(existingEvent);

            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<EventResponseDto>> GetAllEventsAsync(bool trackChanges)
        {
            
                var events = await _unitOfWork.Event.GetAllEvents(trackChanges);

                var eventsDto = _mapper.Map<IEnumerable<EventResponseDto>>(events);

                return eventsDto;
        }

        public async Task<EventResponseDto> GetEventAsync(int eventId, 
            bool trackChanges)
        {
            var eventExists = await CheckIfEventExists(eventId, trackChanges);

            if (eventExists is null)
                throw new EventNotFoundException(eventId);

            var eventDto = _mapper.Map<EventResponseDto>(eventExists);

            return eventDto;
        }

        public async Task UpdateEventAsync(int eventId, 
            EventUpdateRequestDto eventUpdateRequest, 
            bool trackChanges)
        {
            var existingEvent = await _unitOfWork.Event.GetEvent(eventId, trackChanges);

            if(existingEvent is null)
                throw new EventNotFoundException(eventId);

            var updatedEvent = _mapper.Map(eventUpdateRequest, existingEvent);

            _unitOfWork.Event.UpdateEvent(updatedEvent);

            await _unitOfWork.SaveAsync();
        }



        private async Task<Event> CheckIfEventExists(int eventId, bool trackChanges)
        {
            var eventEntity = await _unitOfWork.Event.GetEvent(eventId, trackChanges);

            if(eventEntity is null)
                throw new EventNotFoundException(eventId);

            return eventEntity;
        }
    }
}
