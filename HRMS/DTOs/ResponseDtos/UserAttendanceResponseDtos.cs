using HRMS.Entities;

namespace HRMS.DTOs.ResponseDtos
{
    public class UserAttendanceResponseDtos
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string User_Id { get; set; }
        public string Name { get; set; }
        public string Role {  get; set; }   
        public string Date { get; set; } 
        public string? InTime { get; set; }
        public string? OutTime { get; set; }
        public string Status { get; set; }

        public string startDate { get; set; }
        public string endDate { get; set; }

  
    }
}
