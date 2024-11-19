using HRMS.Entities;

namespace HRMS.IRepository
{
    public interface IExperianceRepo
    {
        Task<Experiance> AddExperiance(Experiance experiance);
        Task<List<Experiance>> GetExperianceByStudentId(Guid studentId);
        Task DeleteExperiance(Guid Id);
    }
}
