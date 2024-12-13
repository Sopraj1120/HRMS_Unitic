using HRMS.Entities;

namespace HRMS.DTOs.ResponseDtos
{
    public class SalaryResponceDtos
    {

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string User_Id { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public decimal? BasicSalary { get; set; }
        public decimal? Deduction { get; set; }
        public decimal? Bonus { get; set; }
        public decimal? EPF { get; set; }
        public decimal? Etf { get; set; }
        public decimal? Allowances { get; set; }
        public int? WorkingDays { get; set; }
        public decimal? NetSalary { get; set; }

        public string SalaryStatus { get; set; }


    }
}
