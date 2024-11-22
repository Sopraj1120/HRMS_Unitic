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

<<<<<<< HEAD
            public Guid LeaveBalanceId { get; set; }

            public LeaveBalance LeaveBalance { get; set; }
=======
            public ICollection<LeaveApply> leaveApplies { get; set; }
>>>>>>> 40170f2af8a3055066ff1e7a4ee7e295845c470b
        }
    }

}
