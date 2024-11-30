using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Entities;

namespace HRMS.Iservice
{
    public interface IStudentAttendanceService
    {
        Task<StudentAttendanceResponseDtos> AddStudentAttendance(Guid StudenId, StudentAttendanceRequestDtos studentAttendanceRequestDtos);
        Task<List<StudentAttendanceResponseDtos>> GetStudentAttendanceByStuId(Guid stuID);
        Task<List<StudentAttendanceResponseDtos>> GenerateAttendanceReport(DateTime startDate, DateTime endDate);
        Task<StudentAttendanceResponseDtos> UpdateStuAttendance(Guid studentId, DateTime date, StudentAttendanceRequestDtos studentAttendanceRequestDtos);
    }
}
