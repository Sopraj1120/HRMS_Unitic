namespace HRMS.Entities
{
    public class Students
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nic { get; set; }
        public string Email { get; set; }
        public string MaritalStatus { get; set; }
        public string Mobile {  get; set; }
        public bool IsDeleted { get; set; } = false;
        public Gender Gender { get; set; }
        public string Image {  get; set; }



        public ICollection<Parents> Parents { get; set; }
        public ICollection<Address> Address { get; set; }

        public ICollection<OLevel> OLs { get; set; }
        public ICollection<ALevel> ALs { get; set; }
        public ICollection<HigherStudies> HigherStudies { get; set; }
        public ICollection<Experiance> Experiances { get; set; }

    }
}
