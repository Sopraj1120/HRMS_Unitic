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
        public string Password { get; set; }
        public MerritalStatus MerritalStatus { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Role Role { get; set; } = Role.Admin;
        public int AvailableLeaveDays { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Gender Gender { get; set; }
        public string Image { get; set; }

      


    }
}
