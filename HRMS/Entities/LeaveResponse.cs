using HRMS.Entities;

public class LeaveResponse
{
    public Guid Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid LeaveTypeId { get; set; }
    public  LeaveType LeaveType { get; set; }
    public DateTime ApplyDate { get; set; }
    public DateTime ResponceDate { get; set; } = DateTime.Now;
    public bool Status { get; set; }
    public Guid ApproverId { get; set; }
    public  Users Approver { get; set; }
    public Guid UserId { get; set; }
    public  Users User { get; set; }
    public string? Comments { get; set; }
    public Guid LeaveApplyId { get; set; }
    public ICollection<LeaveApply> LeaveApply { get; set; }
    public int LeaveDaysCount { get; set; }
}
