using HRMS.Entities;

namespace HRMS.DTOs.ResponseDtos
{
    public class WorkingDaysResponseDtos
    {
        public Guid Id { get; set; }

        public List<string> Weekdays { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
    }
}
