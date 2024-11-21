using HRMS.Entities;

namespace HRMS.IRepository
{
    public interface IUserAlevelRepo
    {
        Task<UserALevel> AddAlevel(UserALevel userALevel);
        Task<List<UserALevel>> GetAlevelByUserId(Guid userId);
        Task DeleteAlevel(Guid Id);
    }
}
