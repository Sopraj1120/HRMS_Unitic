using HRMS.Entities;
using System.ComponentModel.DataAnnotations;

namespace HRMS.DTOs.RequestDtos
{
    public class StudentRequestDtos
    {
        public string StudentId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Nic { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public MerritalStatus MaritalStatus { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public string Image {  get; set; }  

      
    }
}
