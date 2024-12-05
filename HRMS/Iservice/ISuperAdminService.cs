using HRMS.DTOs;
using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;

namespace HRMS.Iservice
{
    public interface ISuperAdminService
    {
        Task<SuperAdminResponceDto> RegisterSuperAdmin(SuperAdminRequestDto admin);
        Task<TokenModal> LoginSuperAdmin(SuperAdminRequestDto admin);
    }
}
