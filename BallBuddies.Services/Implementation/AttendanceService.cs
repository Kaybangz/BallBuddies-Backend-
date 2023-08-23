using AutoMapper;
using BallBuddies.Data.Interface;
using BallBuddies.Models.Dtos.Request;
using BallBuddies.Models.Dtos.Response;
using BallBuddies.Models.Entities;
using BallBuddies.Models.Exceptions;
using BallBuddies.Services.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BallBuddies.Services.Implementation
{
    public class AttendanceService: IAttendanceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AttendanceService(IUnitOfWork unitOfWork, 
            ILoggerManager logger, 
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<AttendanceResponseDto> AddEventAttendanceAsync(Guid eventId,
            AttendanceRequestDto attendanceRequestDto,
            bool trackChanges)
        {
            var userId = _httpContextAccessor?
                .HttpContext?
                .User
                .FindFirst(ClaimTypes.NameIdentifier)?
                .Value;

            var existingEvent = await CheckIfEventExist(eventId, trackChanges);

            if(await _unitOfWork.Attendance.IsUserAttendingEvent(userId, eventId))
            {
                throw new Exception("User is already attending this event");
            }

            var attendanceDto = _mapper.Map<Attendance>(attendanceRequestDto);

            _unitOfWork.Attendance.AddEventAttendance(attendanceDto, eventId, userId);

            await _unitOfWork.SaveAsync();

            return _mapper.Map<AttendanceResponseDto>(attendanceDto);

        }

        public Task DeleteEventAttendanceAsync(Guid eventId, Guid attendanceId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AttendanceResponseDto>> GetEventAttendancesAsync(Guid eventId, bool trackChanges)
        {
            await CheckIfEventExist(eventId, trackChanges);

            var attendanceFromDb = await _unitOfWork.Attendance.GetEventAttendances(eventId, trackChanges);

            var attendanceDto = _mapper.Map<IEnumerable<AttendanceResponseDto>>(attendanceFromDb);

            return attendanceDto;
        }


        private async Task<Event> CheckIfEventExist(Guid eventId, bool trackChanges)
        {
            var existingEvent = await _unitOfWork.Event.GetEvent(eventId, trackChanges);

            if (existingEvent is null)
            {
                _logger.LogError($"Event with Id: {eventId} not found");
                throw new EventNotFoundException(eventId);
            }
                

            return existingEvent;
        }
    }
}
