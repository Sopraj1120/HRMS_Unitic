using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;

namespace HRMS.Iservice
{
    public interface IUserExperianceSevice
    {
        Task<UserExperianceResponseDtos> AddExperiance(Guid userId, UserExperianceRequestdtos userExperianceRequestdtos);
        Task<List<UserExperianceResponseDtos>> GetexperianceByUserId(Guid UderId);
        Task DeleteExperiance(Guid Id);
    }
}
