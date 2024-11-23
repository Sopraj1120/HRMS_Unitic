using HRMS.DTOs.ResponseDtos;

namespace HRMS.Iservice
{
    public interface ILeaveBalanceService
    {
        Task<LeaveBalanceResponseDtos> GetLeaveBalanceByUserId(Guid userId, Guid leaveTypeId);
    }
}
