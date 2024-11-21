using HRMS.Entities;

namespace HRMS.IRepository
{
    public interface IUserOlevelRepo
    {
        Task<UserOLevel> AddOlevel(UserOLevel userOLevel);
        Task<List<UserOLevel>> GetOlevelByUserId(Guid userId);
        Task DeleteOlevel(Guid Id);
    }
}
