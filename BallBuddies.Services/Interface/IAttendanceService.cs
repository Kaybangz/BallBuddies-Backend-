using BallBuddies.Models.Dtos.Request;
using BallBuddies.Models.Dtos.Response;


namespace BallBuddies.Services.Interface
{
    public interface IAttendanceService
    {
        Task<IEnumerable<AttendanceResponseDto>> GetEventAttendancesAsync(Guid eventId,
            bool trackChanges);

        Task<AttendanceResponseDto> AddEventAttendanceAsync(
            AttendanceRequestDto attendanceRequestDto,
            bool trackChanges);

        Task DeleteEventAttendanceAsync(Guid eventId,
            Guid attendanceId,
            bool trackChanges);
    }
}
