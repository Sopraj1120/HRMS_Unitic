using HRMS.Entities;

namespace HRMS.DTOs.RequestDtos
{
    public class SalaryRequestDtos
    {

        //public Guid LeaveTypeId { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal Dedection { get; set; }
        public decimal Bonus { get; set; }
        public decimal EPF { get; set; }
        public decimal Etf { get; set; }
        public decimal Allowenss { get; set; }
        public int WorkingDays { get; set; }
        public decimal NetSalary { get; set; }

        public salarystatus SalaryStatus { get; set; } = salarystatus.pending;


    }
}
