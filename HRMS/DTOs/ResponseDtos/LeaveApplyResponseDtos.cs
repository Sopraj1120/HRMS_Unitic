using HRMS.Entities;

namespace HRMS.DTOs.ResponseDtos
{
    public class LeaveApplyResponseDtos
    {
        public Guid Id { get; set; }
        public DateTime ApplyDate { get; set; }
        public string Reason { get; set; }
        public DateTime LeaveDate { get; set; }
        public DateTime EndDate { get; set; }
     
        public LeaveTypeResponseDtos LeaveType { get; set; }
        public UserLeaveResponseDtos User { get; set; }
        public Role Role { get; set; }
        public bool IsApproved { get; set; }=false;
        public LeaveStatus LeaveStatus { get; set; } = LeaveStatus.Pending;
        public DateTime? ApprovedDate { get; set; }
    }
}
