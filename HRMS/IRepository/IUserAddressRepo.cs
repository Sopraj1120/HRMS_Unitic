using HRMS.Entities;

namespace HRMS.IRepository
{
    public interface IUserAddressRepo
    {
        Task<UserAddress> AddUserAddress(UserAddress userAddress);
        Task<List<UserAddress>> GetAddressByUserId(Guid userId);
        Task deleteUserAddress(Guid Id);
    }
}
