namespace HRMS.Entities
{
    public class UserHigherStudies
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Stream { get; set; }
        public string Year { get; set; }
        public string Duration { get; set; }
        public string? Description { get; set; }
        public string Institute { get; set; }
        public string Grade { get; set; }
        public Guid UserId { get; set; }

        public Users Users { get; set; }
    }
}
