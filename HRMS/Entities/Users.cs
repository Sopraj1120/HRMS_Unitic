using System.Collections;
using System.Data;
using System.Reflection.Emit;

namespace HRMS.Entities
{
    public class Users
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
        public Role Role { get; set; } = Role.Admin;
        public int AvailableLeaveDays { get; set; }
        public bool IsDeleted { get; set; } = false;

        public ICollection<UserAddress> userAddresses { get; set; }
        public ICollection<UserOLevel> userOLevels { get; set; }
        public ICollection<UserALevel>  userALevels { get; set; }
        public ICollection<UserExperiance> userExperiances { get; set; }
        public ICollection<UserHigherStudies> userHigherStudies { get;set; }
      
    }
}
