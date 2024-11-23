namespace HRMS.Entities
{
    public class AccountDetail
    {
        public Guid Id { get; set; }    
        public string FullName { get; set; }
        public string NIC_No { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int AccountNumber { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }

        public Guid UserId { get; set; }
        public Users Users { get; set; }
    }
}
