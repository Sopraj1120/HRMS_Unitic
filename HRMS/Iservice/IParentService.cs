using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;

namespace HRMS.Iservice
{
    public interface IParentService
    {
        Task<ParentsResponseDtos> AddParent(Guid studentId, ParentsRequestDtos parentsRequestDtos);
        Task<List<ParentsResponseDtos>> GetParentsByStudentId(Guid studentId);
        Task DeleteParents(Guid Id);
    }
}
