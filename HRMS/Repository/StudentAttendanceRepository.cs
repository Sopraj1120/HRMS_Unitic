using HRMS.DataBase;
using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Entities;
using HRMS.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Repository
{
    public class StudentAttendanceRepository : IStudentAttendanceRepo
    {
        private readonly HRMDBContext _context;

        public StudentAttendanceRepository(HRMDBContext context)
        {
            _context = context;
        }

        public async Task<StudentAttendance> AddAttendanceForStudmt(StudentAttendance studentAttendance)
        {
         
            var data = await _context.studentAttendances.AddAsync(studentAttendance);
            await _context.SaveChangesAsync();
            return studentAttendance;

        }

        public async Task<StudentAttendance> GetStudentAttendanceByStuIdAndDate(Guid stuID, DateTime date)
        {
            var data = await _context.studentAttendances.FirstOrDefaultAsync(x => x.StudentId == stuID && x.Date.Date == date.Date);
            return data;
        }

        public async Task<List<StudentAttendance>> GenerateAttendanceReport(Guid StuId, DateTime startDate, DateTime endDate)
        {
            var attendanceData = await _context.studentAttendances
                .Where(x => x.StudentId == StuId && x.Date >= startDate && x.Date <= endDate)
                 .ToListAsync();
            return attendanceData;
        }


        public async Task<List<StudentAttendance>> GetAllAttendanceByDate(DateTime date)
        {
            var attendanceData = await _context.studentAttendances
               .Where(x => x.Date.Date == date.Date)
               .ToListAsync();

            return attendanceData;
        }
        public async Task<StudentAttendance> UpdateStuAttendance(StudentAttendance studentAttendance)
        {
            var student = await _context.studentAttendances.FirstOrDefaultAsync(x => x.StudentId == studentAttendance.StudentId);
            if (student == null) return null;

            student.Status = studentAttendance.Status;

             _context.studentAttendances.Update(student);
            await _context.SaveChangesAsync();  
            return student;

        }
    }
}
