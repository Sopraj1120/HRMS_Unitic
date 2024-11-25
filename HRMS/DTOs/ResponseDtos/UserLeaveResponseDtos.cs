using HRMS.Entities;

namespace HRMS.DTOs.ResponseDtos
{
    public class UserLeaveResponseDtos
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public Role Role { get; set; }
        public string PhoneNumber { get; set; }
        public int AvailableLeaveDays { get; set; }
    }
}
