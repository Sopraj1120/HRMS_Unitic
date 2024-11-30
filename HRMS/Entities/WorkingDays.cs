using Microsoft.AspNetCore.SignalR;

namespace HRMS.Entities
{
    public class WorkingDays
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public Role Role { get; set; }
        public Users User { get; set; }

     
        public ICollection<WeekWorkingDays> WeekWorkingDays { get; set; }

    }


    public enum weekdays
    {
        Sunday = 1,
        Monday = 2,
        Tuesday = 3,
        Wednesday = 4,
        Thursday = 5,
        Friday = 6,
        Saturday = 7
    }
}
