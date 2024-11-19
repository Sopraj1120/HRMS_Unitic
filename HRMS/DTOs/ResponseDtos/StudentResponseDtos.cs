using HRMS.Entities;

namespace HRMS.DTOs.ResponseDtos
{
    public class StudentResponseDtos
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nic { get; set; }
        public string Email { get; set; }
        public string MaritalStatus { get; set; }
        public string Mobile { get; set; }
        public bool IsDeleted { get; set; } = false;

        public List<ParentsResponseDtos> Parents { get; set; }
        public List<AddresResponseDto> Address { get; set; }

        public List<OLResponseDtos> Olevels { get; set; }
        public List<ALevelResponseDtos> ALevels { get; set; }
        public List<HStudeiesResponseDtos> HStudeies { get; set; }
        public List<ExperianceResponseDtos> Experiance { get; set; }

     
    }
}
