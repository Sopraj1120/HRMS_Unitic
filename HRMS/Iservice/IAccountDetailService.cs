using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;

namespace HRMS.Iservice
{
    public interface IAccountDetailService
    {
        Task<AccountDetailsResponceDtos> AddAccount(Guid UserId, AccountDetailsRequestDtos accountDetailsRequestDtos);
        Task<List<AccountDetailsResponceDtos>> GetAllAccountDetails();
        Task<AccountDetailsResponceDtos> GetAccountByUserId(Guid userId);
        Task<AccountDetailsResponceDtos> GetAccountById(Guid id);
        Task<AccountDetailsResponceDtos> UpdateAccountDetailsByUserId(Guid UserId, AccountDetailsRequestDtos accountDetailsRequestDtos);
    }
}
