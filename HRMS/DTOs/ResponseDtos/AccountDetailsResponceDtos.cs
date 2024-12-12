namespace HRMS.DTOs.ResponseDtos
{
    public class AccountDetailsResponceDtos
    {
        public Guid Id { get; set; }
        public string? UsersName { get; set; }
        public string Users_Id {  get; set; }
        public string Role { get; set; }
        public string UsersNIC_No { get; set; }
        public string? UsersEmail { get; set; }
        public string UsersPhoneNumber { get; set; }
        public int? AccountNumber { get; set; }
        public string? BankName { get; set; }
        public string? BranchName { get; set; }

        public Guid UsersId { get; set; }
    }
}
