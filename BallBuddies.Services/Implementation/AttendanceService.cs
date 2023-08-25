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


        /*FOR ADDING USER ATTENDANCE*/
        public async Task<AttendanceResponseDto> AddEventAttendanceAsync(
            AttendanceRequestDto attendanceRequestDto,
            bool trackChanges)
        {
            var userId = _httpContextAccessor?
                .HttpContext?
                .User
                .FindFirst(ClaimTypes.NameIdentifier)?
                .Value;

            var eventId = attendanceRequestDto.EventId;

            await CheckIfEventExist(eventId, trackChanges);

            if(await _unitOfWork.Attendance.IsUserAttendingEvent(userId, eventId))
            {
                throw new Exception("User is already attending this event");
            }

            var newAttendance = new Attendance
            {
                EventId = eventId,
                UserId = userId,
            };

            await _unitOfWork.Attendance.AddEventAttendance(newAttendance);

            await _unitOfWork.SaveAsync();

            return _mapper.Map<AttendanceResponseDto>(newAttendance);

            /*var attendanceDto = _mapper.Map<Attendance>(attendanceRequestDto);

            _unitOfWork.Attendance.AddEventAttendance(attendanceDto, eventId, userId);

            await _unitOfWork.SaveAsync();

            return _mapper.Map<AttendanceResponseDto>(attendanceDto);*/

        }


        /*FOR DELETING USER ATTENDANCE*/
        public async Task DeleteEventAttendanceAsync(AttendanceRequestDto attendanceRequestDto,
            bool trackChanges)
        {
            var userId = _httpContextAccessor?
                .HttpContext?
                .User
                .FindFirst(ClaimTypes.NameIdentifier)?
                .Value;

            var eventId = attendanceRequestDto.EventId;

            await CheckIfEventExist(eventId, trackChanges);

            if (!await _unitOfWork.Attendance.IsUserAttendingEvent(userId, eventId))
            {
                throw new Exception("User is not attending this event");
            }

            var attendance = await _unitOfWork.Attendance.GetAttendanceAsync(eventId, userId);

            if (attendance is null)
                throw new Exception("Attendance record not found.");

            _unitOfWork.Attendance.RemoveEventAttendance(attendance);

            await _unitOfWork.SaveAsync();
        }



        /*FOR GETTING ALL EVENT ATTENDANCE*/
        public async Task<IEnumerable<AttendanceResponseDto>> GetEventAttendancesAsync(Guid eventId, bool trackChanges)
        {
            await CheckIfEventExist(eventId, trackChanges);

            var attendanceFromDb = await _unitOfWork.Attendance.GetEventAttendances(eventId, trackChanges);

            var attendanceDto = _mapper.Map<IEnumerable<AttendanceResponseDto>>(attendanceFromDb);

            return attendanceDto;
        }

        public async Task<IEnumerable<AttendanceRequestDto>> GetUserAttendanceAsync( bool trackChanges)
        {
            var userId = _httpContextAccessor?
                .HttpContext?
                .User
                .FindFirst(ClaimTypes.NameIdentifier)?
                .Value;

            var attendances = await _unitOfWork
                .Attendance
                .GetUserAttendances(userId, trackChanges);

            return _mapper.Map<IEnumerable<AttendanceRequestDto>>(attendances);
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
