using HRMS.Entities.HRMS.Entities;
using System.Data;

namespace HRMS.Entities
{
    public class LeaveApply
    {
        public Guid Id { get; set; }
        public DateTime ApplyDate { get; set; } = DateTime.Now;
        public string Reason { get; set; }
        public DateTime LeaveDate { get; set; }
        public DateTime EndDate { get; set; }

        
        public Guid LeaveTypeId { get; set; }
        public LeaveType LeaveType { get; set; }

        public Guid UserId { get; set; }
        public Users User { get; set; }

        public Role Role { get; set; }

    
        public bool IsApproved { get; set; } = false; 
        public DateTime? ApprovedDate { get; set; }
        public LeaveStatus LeaveStatus { get; set; } = LeaveStatus.Pending;

        public Guid LeaveResponseId { get; set; }   
        public LeaveResponse LeaveResponse { get; set; }
    }



    public enum LeaveStatus
    {
        Pending = 1,
        Approved = 2,
        Rejected = 3,
        Cancelled = 4
    }
}
