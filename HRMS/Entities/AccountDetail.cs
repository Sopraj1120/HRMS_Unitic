﻿namespace HRMS.Entities
{
    public class AccountDetail
    {
        public Guid Id { get; set; }    
        public string? UsersName { get; set; }
        public string Users_Id {  get; set; }
        public Role Role { get; set; }
        public string? UsersNIC_No { get; set; }
        public string? UsersEmail { get; set; }
        public string? UsersPhoneNumber { get; set; }
        public int? AccountNumber { get; set; }
        public string? BankName { get; set; }
        public string? BranchName { get; set; }

        public Guid UsersId { get; set; }
        public Users Users { get; set; }
    }
}
