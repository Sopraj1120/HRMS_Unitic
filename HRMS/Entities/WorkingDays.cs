using Microsoft.AspNetCore.SignalR;
using System.Net.Http.Headers;

namespace HRMS.Entities
{
    public class WorkingDays
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string User_Id {  get; set; }    
        public string UserName { get; set; }
        public Role Role { get; set; }
        public Users User { get; set; }

        public ICollection<WeekDays> WeekDays { get; set; }


    }


  
}
