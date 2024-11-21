using HRMS.DataBase;
using HRMS.Entities;
using HRMS.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Repository
{
    public class UserOlevelRepository : IUserOlevelRepo
    {

        private readonly HRMDBContext _context;

        public UserOlevelRepository(HRMDBContext context)
        {
            _context = context;
        }

        public async Task<UserOLevel> AddOlevel(UserOLevel userOLevel)
        {
            var data = await _context.userOLevels.AddAsync(userOLevel);
            await _context.SaveChangesAsync();
            return userOLevel;
        }

        public async Task<List<UserOLevel>> GetOlevelByUserId(Guid userId)
        {
            var data = await _context.userOLevels.Where(o => o.UserId == userId).ToListAsync();
            return data;
        }

        public async Task DeleteOlevel(Guid Id)
        {
            var data = await _context.userOLevels.FindAsync(Id);
            if (data != null)
            {
                _context.userOLevels.Remove(data);
                await _context.SaveChangesAsync();

            }
        }
    }
}
