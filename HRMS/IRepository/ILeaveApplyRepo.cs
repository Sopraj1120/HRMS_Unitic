using HRMS.Entities;

namespace HRMS.IRepository
{
    public interface ILeaveApplyRepo
    {
        Task<LeaveApply> AddLeaveApply(LeaveApply leaveApply);
        Task<List<LeaveApply>> GetAllLeaveApplies();
        Task<LeaveApply> GetLeaveApplyById(Guid id);
        Task<LeaveApply> UpdateLeaveApply(LeaveApply leaveApply);
        Task DeleteLeaveApply(Guid id);
        
    }
}
