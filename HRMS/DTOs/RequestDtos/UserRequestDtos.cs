using HRMS.Entities;

namespace HRMS.DTOs.RequestDtos
{
    public class UserRequestDtos
    {
        public string UsersId { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string Nic { get; set; }
        public string Email { get; set; }
        public string MerritalStatus { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Role Role { get; set; }
    }
}
