using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;

namespace HRMS.Iservice
{
    public interface IOlevelService
    {
        Task<OLResponseDtos> AddOlevel(Guid studentId, OLevalRequestDtos oLevalRequestDtos);
        Task<List<OLResponseDtos>> GetOlByStudentId(Guid studentId);
        Task DeleteOl(Guid Id);
    }
}
