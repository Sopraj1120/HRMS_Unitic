using HRMS.Entities;

namespace HRMS.DTOs.ResponseDtos
{
    public class UserLeaveResponseDtos
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Role { get; set; }
        public string PhoneNumber { get; set; }
    
    }
}
