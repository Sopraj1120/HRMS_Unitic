using HRMS.Entities;

namespace HRMS.IRepository
{
    public interface IAccountDetailRepo
    {
        Task<AccountDetail> AddAccountDetails(AccountDetail accountDetail);
        Task<List<AccountDetail>> GetAllAccountDetails();
        Task<AccountDetail> GetAccountByUserId(Guid userId);
        Task<AccountDetail> GetAccountById(Guid id);
        Task<AccountDetail> UpdateAccountDetailsByUserId(AccountDetail accountDetail);
    }
}
