using AutoMapper;
using BallBuddies.Data.Interface;
using BallBuddies.Models.Dtos.Response;
using BallBuddies.Models.Exceptions;
using BallBuddies.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallBuddies.Services.Implementation
{
    public class AttendanceService: IAttendanceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public AttendanceService(IUnitOfWork unitOfWork, 
            ILoggerManager logger, 
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<AttendanceResponseDto> AddEventAttendanceAsync(int eventId, AttendanceResponseDto dto, bool trackChanges)
        {
            await CheckIfEventExist(eventId, trackChanges);


        }

        public Task DeleteEventAttendanceAsync(string eventId, int attendanceId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AttendanceResponseDto>> GetEventAttendancesAsync(int eventId, bool trackChanges)
        {
            await CheckIfEventExist(eventId, trackChanges);

            var attendanceFromDb = await _unitOfWork.Attendance.GetEventAttendances(eventId, trackChanges);

            var attendanceDto = _mapper.Map<IEnumerable<AttendanceResponseDto>>(attendanceFromDb);

            return attendanceDto;
        }


        private async Task CheckIfEventExist(int eventId, bool trackChanges)
        {
            var existingEvent = await _unitOfWork.Event.GetEvent(eventId, trackChanges);

            if (existingEvent is null)
                throw new EventNotFoundException(eventId);

        }
    }
}
