using HRMS.Entities;

namespace HRMS.DTOs.RequestDtos
{
    public class LeaveReqestDtos
    {
        public DateTime ApplyDate { get; set; }
        public string Reason { get; set; }
        public DateTime LeaveDate { get; set; }
        public DateTime ReJoinDate { get; set; }
        public string? AproverId { get; set; }
        public int leaveCount { get; set; }
        public int AvailableLeaves { get; set; }
        public string? Comments { get; set; }
       

    }
}
