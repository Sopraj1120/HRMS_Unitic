using HRMS.DataBase;
using HRMS.Entities;
using HRMS.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Repository
{
    public class AddressRepository : IAddressRepo
    {
        private readonly HRMDBContext _dbContext;

        public AddressRepository(HRMDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Address> AddAddress(Address address)
        {
            var data = await _dbContext.Address.AddAsync(address);
            await _dbContext.SaveChangesAsync();
            return address;
        }

        public async Task<List<Address>> GetAddressByStudentId (Guid studentId)
        {
            var data = await _dbContext.Address.Where(x => x.StudentId == studentId).ToListAsync();
            return data;
        }

        public async Task DeleteAddress (Guid Id)
        {
            var data = await _dbContext.Address.FindAsync(Id);

            if(data != null)
            {
                 _dbContext.Address.Remove(data);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
