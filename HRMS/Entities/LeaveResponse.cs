using System.Data;

namespace HRMS.Entities
{
    public class LeaveResponse
    {

        public Guid Id { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid LeaveTypeId { get; set; }
        public DateTime Applydate { get; set; }
        public Role Role { get; set; }
        public Guid UserId { get; set; }

        public Guid? AdminId { get; set; }
        public DateTime ResponceDate { get; set; }

        public bool Status { get; set; }

     
        public LeaveType? LeaveType { get; set; }
    }
}
