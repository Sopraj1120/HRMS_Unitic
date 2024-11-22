namespace HRMS.IRepository;

public interface ILeaveTypeRepo
{
    Task<LeaveType> AddLeaveType(LeaveType leaveType);
    Task<List<LeaveType>> GetAllLeaveTypes();
    Task<LeaveType> GetLeaveTypeById(Guid Id);
    Task<LeaveType> UpdateLeaveType(LeaveType leaveType);
    Task DeleteLeaveType(Guid Id);
}
