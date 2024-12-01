using HRMS.Entities;

namespace HRMS.DTOs.ResponseDtos
{
    public class UserAttendanceResponseDtos
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Role {  get; set; }   
        public string Date { get; set; } 
        public string InTime { get; set; }
        public string? OutTime { get; set; }
        public string Status { get; set; }

  
    }
}
