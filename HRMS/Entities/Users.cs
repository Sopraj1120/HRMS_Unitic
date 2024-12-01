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
        public bool IsDeleted { get; set; } = false;
        public Gender Gender { get; set; }

      
        public ICollection<UserAddress> userAddresses { get; set; }
        public ICollection<UserOLevel> userOLevels { get; set; }
        public ICollection<UserALevel>  userALevels { get; set; }
        public ICollection<UserExperiance> userExperiances { get; set; }
        public ICollection<UserHigherStudies> userHigherStudies { get;set; }




        public ICollection<LeaveRequest> LeaveRequests { get; set; }
        public AccountDetail accountDetail { get; set; }
        public WorkingDays workingDays { get; set; }
        public UserAttendance UserAttendance { get; set; }
    }

    public enum Gender
    {
        Male = 1,
        Female = 2,
        Other = 3,
    }

}

