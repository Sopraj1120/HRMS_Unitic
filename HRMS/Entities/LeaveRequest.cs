using Microsoft.Identity.Client;

namespace HRMS.Entities
{
    public class LeaveRequest
    {
        public Guid Id { get; set; }
        public DateTime ApplyDate { get; set; }
        public string Reason { get; set; }
        public DateTime LeaveDate { get; set; }
        public DateTime ReJoinDate { get; set; }    
        public string? AproverId { get; set; }
        public int leaveCount {  get; set; }
        public int AvailableLeaves {  get; set; }
        public string? Comments {  get; set; }
        public status status { get; set; } = status.pending;

        public Guid usersId { get; set; }
        public Users? users { get; set; }
        public Guid leaveTypeId {  get; set; }  
        public LeaveType? leaveType { get; set; }
        public ICollection<HollyDays>? HollyDays { get; set; }

        
    }


    public enum status
    {
        pending = 1,
        Accept = 2,
        Reject = 3,

    }
}
