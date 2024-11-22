using HRMS.Entities;

namespace HRMS.DTOs.ResponseDtos
{
    public class LeaveResponseResponseDtos
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LeaveTypeResponseDtos LeaveType { get; set; }
        public DateTime ApplyDate { get; set; }
        public DateTime ResponseDate { get; set; }
        public bool Status { get; set; }
        public string Comments { get; set; }
        public Role Role { get; set; }
        public UserLeaveResponseDtos User { get; set; } 
        public LeaveApplyResponseDtos LeaveApply { get; set; }

    }
}
