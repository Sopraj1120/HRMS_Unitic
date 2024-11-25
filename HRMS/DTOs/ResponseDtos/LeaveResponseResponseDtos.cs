using HRMS.Entities;

namespace HRMS.DTOs.ResponseDtos
{
    public class LeaveResponseResponseDtos
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        public int LeaveDaysCount { get; set; }
        public Guid ApproverId { get; set; }
    
        public LeaveApplyResponseDtos LeaveApply { get; set; }
      


    }
}
