namespace HRMS.DTOs.RequestDtos
{
    public class LeaveResponseRequestDtos
    {
        public Guid LeaveApplyId { get; set; }
        public bool Status { get; set; } 
        public string Comments { get; set; } 
        public Guid ApproverId { get; set; }
    }
}
