using System.ComponentModel.DataAnnotations;

namespace HRMS.Entities
{
    public class SuperAdminRegister
    {
        [Key]
        public Guid id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email {  get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
