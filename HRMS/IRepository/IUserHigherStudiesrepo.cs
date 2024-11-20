using HRMS.Entities;

namespace HRMS.IRepository
{
    public interface IUserHigherStudiesrepo
    {
        Task<UserHigherStudies> AddHStudy(UserHigherStudies userHigherStudies);
        Task<List<UserHigherStudies>> GetHStudyByUserId(Guid userId);
        Task DeleteHStudy(Guid Id);
    }
}
