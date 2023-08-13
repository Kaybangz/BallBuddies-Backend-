using BallBuddies.Models.Dtos.Response;


namespace BallBuddies.Services.Interface
{
    public interface IAttendanceService
    {
        Task<IEnumerable<AttendanceResponseDto>> GetEventAttendancesAsync(int eventId, bool trackChanges);
        Task<AttendanceResponseDto> AddEventAttendanceAsync(int eventId,
            AttendanceResponseDto dto,
            bool trackChanges);

        Task DeleteEventAttendanceAsync(string eventId,
            int attendanceId,
            bool trackChanges);
    }
}
