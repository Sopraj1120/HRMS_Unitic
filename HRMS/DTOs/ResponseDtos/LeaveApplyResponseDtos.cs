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
     
        public LeavetypeinleaveResponceDto LeaveType { get; set; }
        public UserLeaveResponseDtos User { get; set; }
      
    }
}
