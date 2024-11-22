using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Entities;

namespace HRMS.Iservice
{
    public interface ILeaveApplyService
    {
        Task<LeaveApplyResponseDtos> AddLeaveApply(Guid userId, Guid leavetypeId, LeaveApplyRequestDtos request);
        Task<List<LeaveApplyResponseDtos>> GetAllLeaveApplies();
        Task<LeaveApplyResponseDtos> GetLeaveApplyById(Guid id);
        Task UpdateLeaveStatus(Guid id, LeaveStatus status, bool isApproved, DateTime? approvedDate);
        Task DeleteLeaveApplyById(Guid id);
    }
}
