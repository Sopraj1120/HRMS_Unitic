using HRMS.Entities.HRMS.Entities;

namespace HRMS.Entities
{
    public class LeaveBalance
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid LeaveTypeId { get; set; }

        public Users User { get; set; }
        //public ICollection<LeaveType> leaveTypes { get; set; }

    }
}
