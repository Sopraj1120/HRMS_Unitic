namespace HRMS.Entities
{
    public class Parents
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Job {  get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public Guid StudentId { get; set; }

        public Students Student {  get; set; } 
    }
}
