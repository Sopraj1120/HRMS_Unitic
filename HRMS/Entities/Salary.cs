using System.ComponentModel.DataAnnotations;

namespace HRMS.Entities
{
    public class Salary
    {
        [Key]
        public Guid id { get; set; }
        public Guid UserId { get; set; }
        public decimal BasicSalary {  get; set; }
        public decimal Detection {  get; set; }
        public decimal Bonas {  get; set; }
        public decimal EPF {  get; set; }
        public decimal NetSalary { get; set; }
        public decimal Etf { get; set; }
        public decimal Allowenss {  get; set; }
        public int WorkingDasy { get; set; }

        public Role Role { get; set; }

    }
}
