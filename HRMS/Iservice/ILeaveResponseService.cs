using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;

namespace HRMS.Iservice
{
    public interface ILeaveResponseService
    {

        Task<LeaveResponseResponseDtos> AddLeaveResponse(Guid approverId, Guid leaveapplyId, LeaveResponseRequestDtos leaveResponseRequestDtos);
        Task<List<LeaveResponseResponseDtos>> GetAllLeaveresponse();
        Task<LeaveResponseResponseDtos> GetleaveResponseById(Guid id);
        Task<List<LeaveResponseResponseDtos>> GetLeaveResponseByUserId(Guid userId);
    }
}
