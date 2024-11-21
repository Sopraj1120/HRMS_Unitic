using HRMS.Entities;

namespace HRMS.DTOs.ResponseDtos
{
    public class UserResponseDtos
    {
        public Guid Id { get; set; }
        public string UsersId { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string Nic { get; set; }
        public string Email { get; set; }
        public string MerritalStatus { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Role Role { get; set; }
        public bool IsDeleted { get; set; } = false;

        public List<UserAddressResponceDtos> Useraddress { get; set; }
        public List<UserOlevelResponseDtos> Olevel { get; set; }
        public List<UserAlevelResponseDtos> UserAlevel { get; set; }
        public List<UserExperianceResponceDtos> UserExperiances { get; set; }
        public List<UserHigherStudiesResponseDtos> UserHStudy { get; set; }
    }
}
