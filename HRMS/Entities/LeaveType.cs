namespace HRMS.Entities
{
    namespace HRMS.Entities
    {
        public class LeaveType
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public int CountPerYear { get; set; }

            public bool IsActive { get; set; } = true;

            public ICollection<LeaveApply> leaveApplies { get; set; }
        }
    }

}
