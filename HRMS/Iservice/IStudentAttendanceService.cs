using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Entities;

namespace HRMS.Iservice
{
    public interface IStudentAttendanceService
    {
        Task<StudentAttendanceResponseDtos> AddStudentAttendance(Guid StudenId, StudentAttendanceRequestDtos studentAttendanceRequestDtos);
        Task<StudentAttendanceResponseDtos> GetStudentAttendanceByStuIdAndDate(Guid stuID, DateTime date);
        Task<AttendanceReportWithStatusCount> GenerateAttendanceReport(Guid StuId, DateTime startDate, DateTime endDate);
        Task<List<StudentAttendanceResponseDtos>> GetAllAttendanceByDate(DateTime date);
        Task<StudentAttendanceResponseDtos> UpdateStuAttendance(Guid studentId, DateTime date, StudentAttendanceRequestDtos studentAttendanceRequestDtos);
    }
}
