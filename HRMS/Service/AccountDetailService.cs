using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Entities;
using HRMS.IRepository;
using HRMS.Iservice;


namespace HRMS.Service
{
    public class AccountDetailService : IAccountDetailService
    {
        private readonly IAccountDetailRepo _accountDetailRepo;
        private readonly IUserRepo _userRepo;

        public AccountDetailService(IAccountDetailRepo accountDetailRepo, IUserRepo userRepo)
        {
            _accountDetailRepo = accountDetailRepo;
            _userRepo = userRepo;
        }

        public async Task<AccountDetailsResponceDtos> AddAccount (Guid UserId , AccountDetailsRequestDtos accountDetailsRequestDtos)
        {
            var user = await _userRepo.GetUserById(UserId);
            var account = new AccountDetail
            {
                Id = Guid.NewGuid(),
                UsersId = UserId,
                Users_Id = user.UsersId,
                Role = user.Role,
                UsersName = user.FirstName,
                UsersEmail = user.Email,
                UsersNIC_No = user.Nic,
                BankName = accountDetailsRequestDtos.BankName,
                AccountNumber = accountDetailsRequestDtos.AccountNumber,
                BranchName = accountDetailsRequestDtos.BranchName,
              

            };

            var data = await _accountDetailRepo.AddAccountDetails(account);

            var responce = new AccountDetailsResponceDtos
            {
                Id = data.Id,
                UsersId = data.UsersId,
                Users_Id = data.Users_Id,
                Role = data.Role.ToString(),
                UsersName = data.UsersName,
                UsersEmail = data.UsersEmail,
                UsersNIC_No = data.UsersNIC_No,
                AccountNumber = data.AccountNumber,
                BankName = data.BankName,
                BranchName = data.BranchName,

            };
            return responce;
        }

        public async Task<List<AccountDetailsResponceDtos>> GetAllAccountDetails()
        {
            var users = await _userRepo.GetAllUsers();
            var data = await _accountDetailRepo.GetAllAccountDetails();



            var response = users.Select(user =>
            {
                var userAccount = data.FirstOrDefault(a => a.UsersId == user.Id);

                if (userAccount == null)
                {

                    return new AccountDetailsResponceDtos
                    {
                      Id = Guid.NewGuid(),
                        UsersId = user.Id,
                        Users_Id = user.UsersId,
                        Role = user.Role.ToString(),
                        UsersName = user.FirstName,
                        UsersEmail = user.Email,
                        UsersNIC_No = user.Nic,
                        BankName = null,
                        AccountNumber = null,
                        BranchName = null,
                    };
                }

                return new AccountDetailsResponceDtos
                {
                    Id = userAccount.Id,
                    UsersId = userAccount.UsersId,
                    Users_Id = userAccount.Users_Id,
                    Role = userAccount.Role.ToString(),
                    UsersName = userAccount.UsersName,
                    UsersEmail = userAccount.UsersEmail,
                    UsersNIC_No = userAccount.UsersNIC_No,
                    BankName = userAccount.BankName,
                    AccountNumber = userAccount.AccountNumber,
                    BranchName = userAccount.BranchName
                };
            }).ToList();
            return response;
        }


        public async Task<AccountDetailsResponceDtos> GetAccountByUserId(Guid userId)
        {
      

            var data = await _accountDetailRepo.GetAccountByUserId(userId);

            var responce = new AccountDetailsResponceDtos
            {

                Id = data.Id,
                UsersId = data.UsersId,
                Users_Id = data.Users_Id,
                Role = data.Role.ToString(),
                UsersName = data.UsersName,
                UsersEmail = data.UsersEmail,
                UsersNIC_No = data.UsersNIC_No,
                AccountNumber = data.AccountNumber,
                BankName = data.BankName,
                BranchName = data.BranchName,
            };
            return responce;

        }

        public async Task<AccountDetailsResponceDtos> GetAccountById(Guid id)
        {
            var data = await _accountDetailRepo.GetAccountById(id);


            var responce = new AccountDetailsResponceDtos
            {
                Id = data.Id,
                UsersId = data.UsersId,
                Users_Id = data.Users_Id,
                Role = data.Role.ToString(),
                UsersName = data.UsersName,
                UsersEmail = data.UsersEmail,
                UsersNIC_No = data.UsersNIC_No,
                AccountNumber = data.AccountNumber,
                BankName = data.BankName,
                BranchName = data.BranchName,
            };
            return responce;

        }

        public async Task<AccountDetailsResponceDtos> UpdateAccountDetailsByUserId(Guid UserId, AccountDetailsRequestDtos accountDetailsRequestDtos)
        {
          

            var account = await _accountDetailRepo.GetAccountByUserId(UserId);

            account.AccountNumber = accountDetailsRequestDtos.AccountNumber;
            account.BranchName = accountDetailsRequestDtos.BranchName;
            account.BankName = accountDetailsRequestDtos.BankName;
           
            var data = await _accountDetailRepo.UpdateAccountDetailsByUserId(account);

            var responce = new AccountDetailsResponceDtos
            {
                Id = data.Id,
                UsersId = data.UsersId,
                Users_Id = data.Users_Id,
                Role = data.Role.ToString(),
                UsersName = data.UsersName,
                UsersEmail = data.UsersEmail,
                UsersNIC_No = data.UsersNIC_No,
                AccountNumber = data.AccountNumber,
                BankName = data.BankName,
                BranchName = data.BranchName,
            };
            return responce;

        }

        public async Task DeleteAccountById(Guid Id)
        {
            await _accountDetailRepo.DeleteAccountById(Id);
        }
    }
}
