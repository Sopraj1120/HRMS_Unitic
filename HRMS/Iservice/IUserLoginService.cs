using HRMS.DTOs.RequestDtos;
using HRMS.DTOs;

namespace HRMS.Iservice
{
    public interface IUserLoginService
    {
        Task<TokenModal> LoginUser(UserLoginDTo userLoginDTo);
    }
}
