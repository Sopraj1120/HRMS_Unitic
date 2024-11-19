namespace HRMS.DTOs.RequestDtos
{
    public class ExperianceRequestDtos
    {
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Description { get; set; }

    }
}
