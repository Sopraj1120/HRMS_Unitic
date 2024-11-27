using HRMS.Entities;

namespace HRMS.DTOs.RequestDtos
{
    public class SalaryRequestDtos
    {
     
       
        public decimal BasicSalary { get; set; }
        public decimal Detection { get; set; }
        public decimal Bonas { get; set; }
        public decimal EPF { get; set; }
        public decimal NetSalary { get; set; }
        public decimal Etf { get; set; }
        public decimal Allowenss { get; set; }
        public int WorkingDasy { get; set; }

    }
}
