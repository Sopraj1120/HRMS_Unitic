using HRMS.Entities;

namespace HRMS.IRepository
{
    public interface IUserExperianceRepo
    {
        Task<UserExperiance> AddExperiance(UserExperiance userExperiance);
        Task<List<UserExperiance>> GetExperianceByUserId(Guid userId);
        Task DeleteExperiance(Guid Id);
    }
}
