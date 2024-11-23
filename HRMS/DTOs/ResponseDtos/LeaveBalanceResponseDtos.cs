namespace HRMS.DTOs.ResponseDtos
{
    public class LeaveBalanceResponseDtos
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int Leavebalance { get; set; }

        public List<LeaveTypeResponseDtos> LeaveType { get; set; }
        public UserLeaveResponseDtos UserLeave { get; set; }
    }
}
