using HRMS.Entities;

namespace HRMS.IRepository
{
    public interface IStudentAttendanceRepo
    {
        Task<StudentAttendance> AddAttendanceForStudmt(StudentAttendance studentAttendance);
        Task<List<StudentAttendance>> GetStudentAttendanceByStuId(Guid stuID);
        Task<List<StudentAttendance>> GenerateAttendanceReport(DateTime startDate, DateTime endDate);
        Task<StudentAttendance> UpdateStuAttendance(StudentAttendance studentAttendance);
    }
}
