using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;

namespace HRMS.Iservice
{
    public interface IUserOlevelService
    {
        Task<UserOlevelResponseDtos> AddOlevels(Guid UserId, UserOlevelRequestDtos userOlevelRequestDtos);
        Task<List<UserOlevelResponseDtos>> GetOlevelByUserId(Guid userId);
        Task DeleteOlevel(Guid Id);
    }
}
