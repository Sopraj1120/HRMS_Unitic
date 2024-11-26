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
                BankName = accountDetailsRequestDtos.BankName,
                AccountNumber = accountDetailsRequestDtos.AccountNumber,
                BranchName = accountDetailsRequestDtos.BranchName,
              

            };

            var data = await _accountDetailRepo.AddAccountDetails(account);

            var responce = new AccountDetailsResponceDtos
            {
                Id = data.Id,
                UsersId = data.UsersId,
                UsersName = user.FirstName,
                UsersEmail = user.Email,
                UsersPhoneNumber = user.PhoneNumber,
                UsersNIC_No = user.Nic,
                AccountNumber = data.AccountNumber,
                BankName = data.BankName,
                BranchName = data.BranchName,

            };
            return responce;
        }

        public async Task<List<AccountDetailsResponceDtos>> GetAllAccountDetails()
        {
            var data = await _accountDetailRepo.GetAllAccountDetails();

            var responce = new List<AccountDetailsResponceDtos>();

            foreach (var account in data)
            {
                var user = await _userRepo.GetUserById(account.UsersId);

                var resacc = new AccountDetailsResponceDtos
                {
                    Id = account.Id,
                    UsersId = account.UsersId,
                    UsersName = user.FirstName,
                    UsersEmail = user.Email,
                    UsersPhoneNumber = user.PhoneNumber,
                    UsersNIC_No = user.Nic,
                    AccountNumber = account.AccountNumber,
                    BankName = account.BankName,
                    BranchName = account.BranchName,
                };
                responce.Add(resacc);

            };
            return responce;
        }


        public async Task<AccountDetailsResponceDtos> GetAccountByUserId(Guid userId)
        {
            var user = await _userRepo.GetUserById(userId);

            var data = await _accountDetailRepo.GetAccountByUserId(userId);

            var responce = new AccountDetailsResponceDtos
            {
                Id = data.Id,
                UsersId = userId,
                UsersName = user.FirstName,
                UsersEmail = user.Email,
                UsersPhoneNumber = user.PhoneNumber,
                UsersNIC_No = user.Nic,
                AccountNumber = data.AccountNumber,
                BankName = data.BankName,
                BranchName = data.BranchName,
            };
            return responce;

        }

        public async Task<AccountDetailsResponceDtos> GetAccountById(Guid id)
        {
            var data = await _accountDetailRepo.GetAccountById(id);

            var user = await _userRepo.GetUserById(data.UsersId);

            var responce = new AccountDetailsResponceDtos
            {
                Id = data.Id,
                UsersId = user.Id,
                UsersName = user.FirstName,
                UsersEmail = user.Email,
                UsersPhoneNumber = user.PhoneNumber,
                UsersNIC_No = user.Nic,
                AccountNumber = data.AccountNumber,
                BankName = data.BankName,
                BranchName = data.BranchName,
            };
            return responce;

        }

        public async Task<AccountDetailsResponceDtos> UpdateAccountDetailsByUserId(Guid UserId, AccountDetailsRequestDtos accountDetailsRequestDtos)
        {
            var user = await _userRepo.GetUserById(UserId);

            var account = await _accountDetailRepo.GetAccountByUserId(UserId);

            account.AccountNumber = accountDetailsRequestDtos.AccountNumber;
            account.BranchName = accountDetailsRequestDtos.BranchName;
            account.BankName = accountDetailsRequestDtos.BankName;
           
            var data = await _accountDetailRepo.UpdateAccountDetailsByUserId(account);

            var responce = new AccountDetailsResponceDtos
            {
                Id = data.Id,
                UsersId = UserId,
                UsersName = user.FirstName,
                UsersEmail = user.Email,
                UsersPhoneNumber = user.PhoneNumber,
                UsersNIC_No = user.Nic,
                AccountNumber = data.AccountNumber,
                BankName = data.BankName,
                BranchName = data.BranchName,
            };
            return responce;

        }
    }
}
