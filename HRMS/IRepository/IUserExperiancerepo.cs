using HRMS.Entities;

namespace HRMS.IRepository
{
    public interface IUserExperiancerepo
    {
        Task<UserExperiance> AddExperiance(UserExperiance userExperiance);
        Task<List<UserExperiance>> GetExperianceByUserId(Guid userId);
        Task DeleteExperiance(Guid Id);
    }
}
