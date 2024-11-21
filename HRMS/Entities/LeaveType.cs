namespace HRMS.Entities
{
    public class LeaveType
    {
        public Guid Id { get; set; }
        public Guid? LeaveApplyId { get; set; }
        public string Name { get; set; }
        public int CountPerYear { get; set; }

        public ICollection<LeaveApply>? LeaveApplies { get; set; } = new List<LeaveApply>();
       

    }
}
