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
            StudentAttendance studentAttendance = new StudentAttendance();
            var student = await _studentRepo.GetStudentById(StudenId).ConfigureAwait(false);
            studentAttendance = await _studentAttendanceRepo.GetAttendanceForStudent(student.Id).ConfigureAwait(false);

            if (studentAttendance == null)
            {
                studentAttendance = new StudentAttendance
                {
                    Id = Guid.NewGuid(),
                    StudentId = student.Id,
                    Name = student.FirstName,
                    Student_Id = student.StudentId,
                    Date = studentAttendanceRequestDtos.Date,
                    InTime = DateTime.Now,
                    OutTime = DateTime.Now,
                    Status = AttendanceStatus.Present,
                };
                await _studentAttendanceRepo.AddAttendanceForStudmt(studentAttendance).ConfigureAwait(false);
            }
            else
            {

                studentAttendance.OutTime = DateTime.Now;
                studentAttendance.Status = AttendanceStatus.Present;

                await _studentAttendanceRepo.UpdateStuAttendance(studentAttendance).ConfigureAwait(false);
            }

            var response = new StudentAttendanceResponseDtos
            {
                Id = studentAttendance.Id,
                StudentId = studentAttendance.StudentId,
                Student_Id = studentAttendance.Student_Id,
                Name = studentAttendance.Name,   
                Date = studentAttendance.Date.ToString("yyyy-MM-dd") ?? default,
                InTime = studentAttendance.InTime.ToString() ?? "",
                OutTime = studentAttendance.OutTime.ToString() ?? "",
                Status = studentAttendance.Status.ToString(),
            };

            return response;


        }

   
        public async  Task<StudentAttendanceResponseDtos> GetStudentAttendanceByStuIdAndDate(Guid stuID, DateTime date)
        {
            var data = await _studentAttendanceRepo.GetStudentAttendanceByStuIdAndDate(stuID, date).ConfigureAwait(false);
            var responce = new StudentAttendanceResponseDtos
            {
                Id = data.Id,
                StudentId = data.StudentId,
                Student_Id = data.Student_Id,
                Name = data.Name,
                Date = data.Date.ToString("yyyy-MM-dd"),
                InTime = data.InTime.ToString() ??"",
                OutTime = data.OutTime?.ToString() ?? "",
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
                  Student_Id = x.Student_Id,
                  Name = x.Name,
                  Date = x.Date.ToString("yyyy-MM-dd"),
                  InTime = x.InTime.ToString() ?? "",
                  OutTime = x.OutTime.ToString() ?? "",
                    Status = x.Status.ToString()
                 }).ToList();

            var attendanceReport = new AttendanceReportWithStatusCount
            {
                AttendanceDetails = responce,
                StatusCount = statusCount
            };

            return attendanceReport;

        }



        public async Task<List<StudentAttendanceResponseDtos>> GetAllAttendanceByDate()
        {
            var students = await _studentRepo.GetAllStudents(1, 120);
            var studentAttendance = await _studentAttendanceRepo.GetAllAttendanceByDate();


            var response = students.Select(stu =>
            {
                var stuAttendance = studentAttendance.FirstOrDefault(a => a.StudentId == stu.Id);


                if (stuAttendance == null)
                {

                    return new StudentAttendanceResponseDtos
                    {
                        Id = Guid.NewGuid(),
                        StudentId = stu.Id,
                        Student_Id = stu.StudentId,
                        Name = stu.FirstName,
                        Date = DateTime.Now.ToString("yyyy-MM-dd"),
                        InTime = null,
                        OutTime = null,
                        Status = AttendanceStatus.absent.ToString()


                    };
                }


                return new StudentAttendanceResponseDtos
                {

                    Id = stuAttendance.Id,
                    StudentId = stuAttendance.StudentId,
                    Student_Id = stuAttendance.Student_Id,
                    Name = stuAttendance.Name,
                    Date = stuAttendance.Date.ToString("yyyy-MM-dd"),
                    InTime = stuAttendance.InTime?.ToString("yyyy-MM-dd HH:mm:ss"),
                    OutTime = stuAttendance.OutTime?.ToString("yyyy-MM-dd HH:mm:ss"),
                    Status = AttendanceStatus.Present.ToString()
                };

            }).ToList();

            return response;
       

        }
      

        public async Task<StudentAttendanceResponseDtos> UpdateStuAttendance(Guid studentId, DateTime date, StudentAttendanceRequestDtos studentAttendanceRequestDtos)
        {
           
            var student = await _studentAttendanceRepo.GetStudentAttendanceByStuIdAndDate(studentId, date).ConfigureAwait(false);

            student.OutTime = studentAttendanceRequestDtos.OutTime;
            student.Status = studentAttendanceRequestDtos.Status;

            var data = await _studentAttendanceRepo.UpdateStuAttendance(student).ConfigureAwait(false);
            var response = new StudentAttendanceResponseDtos
            {
                Id = data.Id,
                StudentId = data.StudentId,
                Student_Id = data.Student_Id,
                Name = data.Name,
                Date = data.Date.ToString("yyyy-MM-dd"),
                InTime = data.InTime.ToString() ?? "",
                OutTime = data.OutTime.ToString() ?? "",
                Status = data.Status.ToString(),
            };

            return response;
        }


    }
}
