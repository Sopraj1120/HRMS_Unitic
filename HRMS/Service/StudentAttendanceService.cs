using Azure;
using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Entities;
using HRMS.IRepository;
using HRMS.Iservice;
using HRMS.Repository;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.VisualBasic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HRMS.Service
{
    public class StudentAttendanceService : IStudentAttendanceService
    {
        private readonly IStudentAttendanceRepo _studentAttendanceRepo;
        private readonly IStudentRepo _studentRepo;
      

        public StudentAttendanceService(IStudentAttendanceRepo studentAttendanceRepo,IStudentRepo studentRepo)
        {
            _studentAttendanceRepo = studentAttendanceRepo;
            _studentRepo = studentRepo;
        }

        public async Task<StudentAttendanceResponseDtos> AddStudentAttendance(Guid StudenId, StudentAttendanceRequestDtos studentAttendanceRequestDtos)
        {
            var student = await _studentRepo.GetStudentById(StudenId);
            var attendance = new StudentAttendance
            {
                Id = Guid.NewGuid(),
                StudentId = StudenId,
                Name = student.FirstName,
                Date = studentAttendanceRequestDtos.Date,
                Status = studentAttendanceRequestDtos.Status
            };
            var data = await _studentAttendanceRepo.AddAttendanceForStudmt(attendance);

            var responce = new StudentAttendanceResponseDtos
            {
                Id = data.Id,
                StudentId = data.StudentId,
                Name = data.Name,
                Date = data.Date.ToString("yyyy-MM-dd"),
                Status = data.Status.ToString()

            };
            return responce;
        }
       public async  Task<StudentAttendanceResponseDtos> GetStudentAttendanceByStuIdAndDate(Guid stuID, DateTime date)
        {
            var data = await _studentAttendanceRepo.GetStudentAttendanceByStuIdAndDate(stuID, date).ConfigureAwait(false);
            var responce = new StudentAttendanceResponseDtos
            {
                Id = data.Id,
                StudentId = data.StudentId,
                Name = data.Name,
                Date = data.Date.ToString("yyyy-MM-dd"),
                Status = data.Status.ToString()

            };
            return responce;
        }

       

        public async Task<AttendanceReportWithStatusCount> GenerateAttendanceReport(Guid StuId, DateTime startDate, DateTime endDate)
        {


            var report = await _studentAttendanceRepo.GenerateAttendanceReport(StuId, startDate, endDate).ConfigureAwait(false);

            var statusCount = report.GroupBy(x => x.Status).Select(a => new AttendanceReportDto
            {
                Status = a.Key.ToString(),
                Count = a.Count()
            }).ToList();
            

                var responce = report.Select(x => new StudentAttendanceResponseDtos
 {
                  Id = x.Id,
                  StudentId = x.StudentId,
                  Name = x.Name,
                  Date = x.Date.ToString("yyyy-MM-dd"),
                  Status = x.Status.ToString()
                 }).ToList();

            var attendanceReport = new AttendanceReportWithStatusCount
            {
                AttendanceDetails = responce,
                StatusCount = statusCount
            };

            return attendanceReport;

        }
       public async Task<List<StudentAttendanceResponseDtos>> GetAllAttendanceByDate(DateTime date)
        {
            var data = await _studentAttendanceRepo.GetAllAttendanceByDate(date).ConfigureAwait(false);
            
                

                var responce = data.Select(x => new StudentAttendanceResponseDtos
                {
                    Id = x.Id,
                    StudentId = x.StudentId,
                    Name = x.Name,
                    Date = x.Date.ToString("yyyy-MM-dd"),
                    Status = x.Status.ToString()
                }).ToList();

                return responce;
       }
        
        public async Task<StudentAttendanceResponseDtos> UpdateStuAttendance(Guid studentId, DateTime date, StudentAttendanceRequestDtos studentAttendanceRequestDtos)
        {
           
            var student = await _studentAttendanceRepo.GetStudentAttendanceByStuIdAndDate(studentId, date).ConfigureAwait(false);

            student.Status = studentAttendanceRequestDtos.Status;

            var data = await _studentAttendanceRepo.UpdateStuAttendance(student).ConfigureAwait(false);
            var response = new StudentAttendanceResponseDtos
            {
                Id = data.Id,
                StudentId = data.StudentId,
                Name = data.Name,
                Date = data.Date.ToString("yyyy-MM-dd"),
                Status = data.Status.ToString()
            };

            return response;
        }


    }
}
