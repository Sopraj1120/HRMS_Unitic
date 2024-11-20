using HRMS.DataBase;
using HRMS.Entities;
using HRMS.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Repository
{
    public class UserAddressRepo : IUserAddressRepo
    {
        private readonly HRMDBContext _hRMDBContext;

        public UserAddressRepo(HRMDBContext hRMDBContext)
        {
            _hRMDBContext = hRMDBContext;
        }

       public async Task<UserAddress> AddUserAddress(UserAddress userAddress)
        {
            var data = await _hRMDBContext.userAddresses.AddAsync(userAddress);
            await _hRMDBContext.SaveChangesAsync();
            return userAddress;
        }
        public async Task<List<UserAddress>> GetAddressByUserId(Guid userId)
        {
            var data = await _hRMDBContext.userAddresses.Where(u => u.UserId == userId).ToListAsync();
            return data;
        }

        public async Task deleteUserAddress(Guid Id)
        {
            var data =await _hRMDBContext.userAddresses.FindAsync(Id);
            if(data != null)
            {
                _hRMDBContext.userAddresses.Remove(data);
                await _hRMDBContext.SaveChangesAsync(); 
            }
        }
    }
}
