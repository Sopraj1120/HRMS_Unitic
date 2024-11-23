using HRMS.Entities;

namespace HRMS.IRepository
{
    public interface ILeaveBalanceRepo
    {
        Task<LeaveBalance> GetLeaveBalanceByUserId(Guid Id, Guid LeaveTypeId);
    }
}
