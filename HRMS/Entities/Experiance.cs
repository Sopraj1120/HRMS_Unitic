namespace HRMS.Entities
{
    public class Experiance
    {
        public Guid Id { get; set; }

        public Guid StudentId { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Description { get; set; }

        public Students Student { get; set; }

    }
}
