using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;

namespace HRMS.Iservice
{
    public interface ILeaveRequestService
    {
        Task<LeaveReqResponseDto> AddLeaveRequest(Guid UserId, Guid LeaveTypeId, LeaveReqestDtos leaveReqestDtos);
    }
}
