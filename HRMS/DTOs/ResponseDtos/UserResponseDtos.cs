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
        public bool IsDeleted { get; set; } = false;

        public List<UserAddressResponceDtos> Useraddress { get; set; }
        public List<UserExperianceResponseDtos> UserExperiance { get; set; }
    }
}
