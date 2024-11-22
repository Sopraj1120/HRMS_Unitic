using HRMS.Entities;

namespace HRMS.IRepository
{
    public interface ILeaveResponceRepo
    {

        Task<LeaveResponse> AddLeaveResponce(LeaveResponse leaveResponse);
        Task<List<LeaveResponse>> GetAllLeaveResponce();
        Task<LeaveResponse> GetleaveResponseById(Guid Id);
        Task<List<LeaveResponse>> GetLeaveResponseByUserId(Guid userId);
        Task<int> GetTotalLeavesForUser(Guid userId);
    }
}
