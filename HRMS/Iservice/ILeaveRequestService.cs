using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;

namespace HRMS.Iservice
{
    public interface ILeaveRequestService
    {
        Task<LeaveReqResponseDto> AddLeaveRequest(Guid UserId, Guid LeaveTypeId, LeaveReqestDtos leaveReqestDtos);
        Task<List<LeaveReqResponseDto>> GetAllLeaveRequest();
        Task<LeaveReqResponseDto> GetLeaveRequestById(Guid Id);
        Task<List<LeaveReqResponseDto>> GetLeaveRequestByUserId(Guid userId);
        Task<LeaveReqResponseDto> UpdateLeaveRequest(Guid Id, LeaveRequestUpdateDtos leaveRequest);
        Task DeleteLeaveRequest(Guid Id);
    }
}
