namespace HRMS.DTOs.RequestDtos
{
    public class LeaveResponseRequestDtos
    {
       
        public bool Status { get; set; } 
        public string? Comments { get; set; } 
        public Guid ApproverId { get; set; }
    }
}
