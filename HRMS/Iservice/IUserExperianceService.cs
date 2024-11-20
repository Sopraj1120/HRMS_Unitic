using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;

namespace HRMS.Iservice
{
    public interface IUserExperianceService
    {
        Task<UserExperianceResponceDtos> AddExperiance(Guid userId, UserExperianceRequestDtos requestDtos);
        Task<List<UserExperianceResponceDtos>> GetExperianceByUserId(Guid Id);
        Task DeleteExperiance(Guid Id);
    }
}
