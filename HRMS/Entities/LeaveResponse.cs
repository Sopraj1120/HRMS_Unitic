using HRMS.Entities;

public class LeaveResponse
{
    public Guid Id { get; set; }
    public status Status { get; set; } = status.pending;
    public Guid ApproverId { get; set; }
    public  Users Approver { get; set; }
    
    public string? Comments { get; set; }
    public Guid LeaveApplyId { get; set; }
    public ICollection<LeaveApply> LeaveApply { get; set; }
    public int LeaveDaysCount { get; set; }
    public ICollection<HollyDays> HollyDays { get; set; }
}

public enum status
{
    pending = 1,
    Accept = 2,
    Reject = 3,

}
