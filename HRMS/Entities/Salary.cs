using Azure.Identity;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Entities
{
    public class Salary
    {

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string User_Id { get; set; }
        public string UserName { get; set; }
        public Role Role { get; set; }
        public decimal? BasicSalary { get; set; }
        public decimal? Deduction { get; set; }
        public decimal? Bonus { get; set; }
        public decimal? EPF { get; set; }
        public decimal? Etf { get; set; }
        public decimal? Allowances { get; set; }
        public int? WorkingDays { get; set; }
        public decimal? NetSalary { get; set; }

        public salarystatus? SalaryStatus { get; set; }

        public Users User { get; set; }
        public LeaveType? LeaveType { get; set; }



    }

    public enum salarystatus
    {
        pending = 1,
        Get = 2,
    }
}
