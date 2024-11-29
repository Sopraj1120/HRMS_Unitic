using Microsoft.AspNetCore.SignalR;

namespace HRMS.Entities
{
    public class WorkingDays
    {
        public Guid Id { get; set; }

        public string Sunday { get; set; }
        public string Monday { get; set; }
        public  string Tuesday {  get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }
        public string Saturday { get; set; }
        public Guid UserId { get; set; }
        public Users Users { get; set; }

    }
}
