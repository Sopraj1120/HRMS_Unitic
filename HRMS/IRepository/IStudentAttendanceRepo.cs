using HRMS.DTOs.RequestDtos;
using HRMS.Entities;

namespace HRMS.IRepository
{
    public interface IStudentAttendanceRepo
    {
        Task<StudentAttendance> GetAttendanceForStudent(Guid Id);
        Task<StudentAttendance> AddAttendanceForStudmt(StudentAttendance studentAttendance);
        Task<StudentAttendance> GetStudentAttendanceByStuIdAndDate(Guid stuID, DateTime date);
        Task<List<StudentAttendance>> GenerateAttendanceReport(Guid StuId, DateTime startDate, DateTime endDate);
        Task<List<StudentAttendance>> GetAllAttendanceByDate();
        Task<StudentAttendance> UpdateStuAttendance(StudentAttendance studentAttendance);
    }
}
