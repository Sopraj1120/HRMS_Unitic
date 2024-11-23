namespace HRMS.Entities
{
    public class LeaveBalance
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid LeaveTypeId { get; set; }
        public int CountPerYear { get; set; }
        public int Leavebalance {  get; set; }

        public Users User { get; set; }
        public ICollection<LeaveType> leaveTypes { get; set; }

    }
}
