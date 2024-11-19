using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;

namespace HRMS.Iservice
{
    public interface IExperianceService
    {
        Task<ExperianceResponseDtos> AddExperiance(Guid studentId, ExperianceRequestDtos requestDtos);
        Task<List<ExperianceResponseDtos>> GetExperianceByStudentId(Guid studentId);
        Task DeleteExperiance(Guid Id);
    }
}
