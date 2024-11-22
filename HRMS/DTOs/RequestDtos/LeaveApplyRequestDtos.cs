using HRMS.Entities;

namespace HRMS.DTOs.RequestDtos
{
    public class LeaveApplyRequestDtos
    {
        public string Reason { get; set; }
        public DateTime LeaveDate { get; set; }
        public DateTime EndDate { get; set; }
        public Role Role { get; set; }
    }
}
