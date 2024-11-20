using HRMS.DataBase;
using HRMS.Entities;
using HRMS.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Repository
{
    public class UserOlevelRepository : IUserOlevelRepository
    {

        private readonly HRMDBContext _hRMDBContext;

        public UserOlevelRepository(HRMDBContext hRMDBContext)
        {
            _hRMDBContext = hRMDBContext;
        }

        public async Task<UserOLevel> AddUserOlevel(UserOLevel userOLevel)
        {
            var data  = await _hRMDBContext.userOLevels.AddAsync(userOLevel);
            await _hRMDBContext.SaveChangesAsync();
            return userOLevel;
        }

        public async Task<List<UserOLevel>> GetUserOlevelByUserId(Guid userId)
        {
            var data = await _hRMDBContext.userOLevels.Where(a => a.UserId == userId).ToListAsync();
            return data;
        }

        public async Task DeleteUserOlevel(Guid Id)
        {
            var data = await _hRMDBContext.userOLevels.FindAsync(Id);
            if (data != null)
            {
                _hRMDBContext.userOLevels.Remove(data);
                await _hRMDBContext.SaveChangesAsync();
            }
        }
    }
}
