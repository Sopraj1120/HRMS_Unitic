using HRMS.Entities;

namespace HRMS.IRepository
{
    public interface ILeaveRequestrepo
    {
        Task<LeaveRequest> AddLeaveRequest(LeaveRequest leaveRequest);
        Task<List<LeaveRequest>> GetAllLeaveRequest();
        Task<LeaveRequest> GetLeaveRequestById(Guid Id);
        //Task<List<LeaveRequest>> GetLeaveRequestByUserId(Guid userId);
        Task<LeaveRequest> UpdateLeaveRequest(LeaveRequest leaveRequest);
        Task DeleteLeaveRequest(Guid Id);
        Task<int> GetTotalUsedLeave(Guid userId, Guid leaveTypeId);
    }
}
