using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Entities;
using HRMS.IRepository;
using HRMS.Iservice;

namespace HRMS.Service
{
    public class UserAddressService : IUserAddressService
    {
        private readonly IUserAddressRepo _userAddressRepo;

        public UserAddressService(IUserAddressRepo userAddressRepo)
        {
            _userAddressRepo = userAddressRepo;
        }

        public async Task<UserAddressResponceDtos> AddUserAddress(Guid userId, UserAddressRequestDtos userAddressRequestDtos)
        {
            var address = new UserAddress
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                HouseNumber = userAddressRequestDtos.HouseNumber,
                Street = userAddressRequestDtos.Street,
                City = userAddressRequestDtos.City,
                State = userAddressRequestDtos.State,
                PostalCode = userAddressRequestDtos.PostalCode,
                Country = userAddressRequestDtos.Country
            };
            var data =await _userAddressRepo.AddUserAddress(address);
            var requAddress = new UserAddressResponceDtos
            {
                Id = data.Id,
                HouseNumber = data.HouseNumber,
                Street = data.Street,
                City = data.City,
                State = data.State,
                PostalCode = data.PostalCode,
                Country = data.Country

            };
            return requAddress;
        }

        public async Task<List<UserAddressResponceDtos>> GetUserAddressByUserId(Guid userId)
        {
            var data = await _userAddressRepo.GetAddressByUserId(userId);

            var reqAddress = data.Select(a => new UserAddressResponceDtos
                {
                Id = a.Id,
                HouseNumber = a.HouseNumber,
                Street = a.Street,
                City = a.City,
                State = a.State,
                PostalCode = a.PostalCode,
                Country = a.Country
                }).ToList();

            return reqAddress;

        }

        public async Task DeleteUserAddress(Guid Id)
        {
            await _userAddressRepo.deleteUserAddress(Id);
           
        }
    }
}
