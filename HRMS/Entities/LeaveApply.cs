using System.Data;

namespace HRMS.Entities
{
    public class LeaveApply
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public DateTime ApplyDate { get; set; }
        public Guid? LeaveTypeID { get; set; }
        public Role Role { get; set; }
        public string Reason { get; set; }
        public DateTime LeaveDate { get; set; }
        public DateTime EndDate { get; set; }

        
        public LeaveType? LeaveType { get; set; }
    }
}
