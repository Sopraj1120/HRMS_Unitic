using HRMS.Entities;

namespace HRMS.IRepository
{
    public interface IUserOlevelRepository
    {
        Task<UserOLevel> AddUserOlevel(UserOLevel userOLevel);
        Task<List<UserOLevel>> GetUserOlevelByUserId(Guid userId);
        Task DeleteUserOlevel(Guid Id);
    }
}
