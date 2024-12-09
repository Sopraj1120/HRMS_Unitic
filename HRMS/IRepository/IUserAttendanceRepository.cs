using HRMS.DTOs.RequestDtos;
using HRMS.Entities;

namespace HRMS.IRepository
{
    public interface IUserAttendanceRepository
    {
        Task<UserAttendance> AddAttendanceForUser(UserAttendance userAttendance);
        Task<UserAttendance> GetUserAttendanceByUserIdAndDate(Guid userId, DateTime date);
        Task<List<UserAttendance>> GenerateUserAttendanceReportByUser(Guid userId, DateTime startDate, DateTime endDate);
        Task<List<UserAttendance>> GetAllAttendanceByDate();
        Task<UserAttendance> UpdateUserAttendance(UserAttendance userAttendance);
        Task<UserAttendance> GetAttendanceForUser(Guid Id);
    }
}
