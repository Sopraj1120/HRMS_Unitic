namespace HRMS.DTOs
{
    public class SuperADto
    {
        public required string Username { get; set; }
        public required string Email { get; set; }
        public string? Image {  get; set; }
        public required string Password { get; set; }
    }
}
