using System.ComponentModel.DataAnnotations;

namespace HRMS.Entities
{
    public class Students
    {
        public Guid Id { get; set; }

        public string StudentId {  get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Nic { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public MerritalStatus MaritalStatus { get; set; }
        [Required]
        public string Mobile {  get; set; }
        public bool IsDeleted { get; set; } = false;
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public string Image {  get; set; }



        public ICollection<Parents> Parents { get; set; }
        public ICollection<Address> Address { get; set; }

        public ICollection<OLevel> OLs { get; set; }
        public ICollection<ALevel> ALs { get; set; }
        public ICollection<HigherStudies> HigherStudies { get; set; }
        public ICollection<Experiance> Experiances { get; set; }
        public ICollection<StudentAttendance> StudentAttendances { get;set; }

    }
}
