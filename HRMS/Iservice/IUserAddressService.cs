using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;

namespace HRMS.Iservice
{
    public interface IUserAddressService
    {
        Task<UserAddressResponceDtos> AddUserAddress(Guid userId, UserAddressRequestDtos userAddressRequestDtos);
        Task<List<UserAddressResponceDtos>> GetUserAddressByUserId(Guid userId);
        Task DeleteUserAddress(Guid Id);
    }
}
