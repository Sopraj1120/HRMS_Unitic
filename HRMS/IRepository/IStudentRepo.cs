using HRMS.Entities;

namespace HRMS.IRepository
{
    public interface IStudentRepo
    {
        Task<Students> AddStudent(Students student);
        Task<List<Students>> GetAllStudents();
        Task<Students> GetStudentById(Guid Id);
        Task<Students> UpdateStudent(Students student);
        Task DeleteStudent(Guid Id);
    }
}
