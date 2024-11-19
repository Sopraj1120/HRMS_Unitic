using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;

namespace HRMS.Iservice
{
    public interface IAlevelService
    {
        Task<ALevelResponseDtos> AddAlevels(Guid studentId, ALevelRequestDtos requestDtos);
        Task<List<ALevelResponseDtos>> GetAlevelByStudentId(Guid StudentId);
        Task DeleteAlevel(Guid Id);
    }
}
