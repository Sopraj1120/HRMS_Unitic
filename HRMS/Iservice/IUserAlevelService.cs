using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;

namespace HRMS.Iservice
{
    public interface IUserAlevelService
    {
        Task<UserAlevelResponseDtos> AddAlevel(Guid userId, UserAlevelRequestDtos requestDtos);
        Task<List<UserAlevelResponseDtos>> GetAlByUserId(Guid Id);
        Task DeleteAls(Guid Id);
    }
}
