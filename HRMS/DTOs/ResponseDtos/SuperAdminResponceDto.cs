using HRMS.Entities;

namespace HRMS.DTOs.ResponseDtos
{
    public class SuperAdminResponceDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
