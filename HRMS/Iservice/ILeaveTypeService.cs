using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;

namespace HRMS.Iservice
{
    public interface ILeaveTypeService
    {
        Task<LeaveTypeResponseDtos> AddLeaveType(LeaveTypeRequestDtos leaveTypeRequestDtos);
        Task<List<LeaveTypeResponseDtos>> GetAllLeaveTypes();
        Task<LeaveTypeResponseDtos> GetLeaveTypeById(Guid Id);
        Task<LeaveTypeResponseDtos> UpdateleaveType(Guid Id, LeaveTypeRequestDtos leaveTypeRequestDtos);
        Task DeleteLeaveType(Guid Id);
    }
}
