using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;

namespace HRMS.Iservice
{
    public interface IStudentService
    {
        Task<StudentResponseDtos> AddSudent(StudentRequestDtos studentRequestDtos);
        Task<List<StudentResponseDtos>> GetAllStudents();
        Task<StudentResponseDtos> GetStudentById(Guid Id);
        Task<StudentResponseDtos> UpdateStudent(Guid Id, StudentRequestDtos studentRequestDtos);
        Task DeleteStudent(Guid Id);
    }
}
