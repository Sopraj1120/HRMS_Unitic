using HRMS.Entities;

namespace HRMS.DTOs.RequestDtos
{
    public class SalaryRequestDtos
    {

        public decimal? BasicSalary { get; set; }
        public decimal? Deduction { get; set; }
        public decimal? Bonus { get; set; }

        public decimal? Allowances { get; set; }
      


        public salarystatus? SalaryStatus { get; set; } = salarystatus.pending;


    }
}
