using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Entities;
using HRMS.IRepository;
using HRMS.Iservice;

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

        public async Task<List<StudentAttendanceResponseDtos>> GetStudentAttendanceByStuId(Guid stuID)
        {
            var data = await _studentAttendanceRepo.GetStudentAttendanceByStuId(stuID);

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

        public async Task<List<StudentAttendanceResponseDtos>> GenerateAttendanceReport(DateTime startDate, DateTime endDate)
        {
           
                
                var attendanceData = await _studentAttendanceRepo.GenerateAttendanceReport(startDate, endDate);

               
                var attendanceReport = attendanceData.Select(data => new StudentAttendanceResponseDtos
                {
                    Id = data.Id,
                    StudentId = data.StudentId,
                    Name = data.Name,
                    Date = data.Date.ToString("yyyy-MM-dd"),
                    Status = data.Status.ToString()
                }).ToList();

                return attendanceReport;
           
        }

        public async Task<StudentAttendanceResponseDtos> UpdateStuAttendance(Guid studentId, DateTime date, StudentAttendanceRequestDtos studentAttendanceRequestDtos)
        {
           
            var existingAttendance = await _studentAttendanceRepo.GetStudentAttendanceByStuId(studentId);

     
            var attendanceToUpdate = existingAttendance.FirstOrDefault(x => x.Date.Date == date.Date);

            if (attendanceToUpdate == null)
            {
               
                return null;
            }

           
            attendanceToUpdate.Status = studentAttendanceRequestDtos.Status;

          
            var updatedAttendance = await _studentAttendanceRepo.UpdateStuAttendance(attendanceToUpdate);

          
            var response = new StudentAttendanceResponseDtos
            {
                Id = updatedAttendance.Id,
                StudentId = updatedAttendance.StudentId,
                Name = updatedAttendance.Name,
                Date = updatedAttendance.Date.ToString("yyyy-MM-dd"),
                Status = updatedAttendance.Status.ToString()
            };

            return response;
        }


    }
}
