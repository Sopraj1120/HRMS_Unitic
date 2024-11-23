namespace HRMS.DTOs.ResponseDtos
{
    public class AccountDetailsResponceDtos
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string NIC_No { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int AccountNumbe { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
    }
}
