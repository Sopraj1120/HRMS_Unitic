using HRMS.DataBase;
using HRMS.Entities;
using HRMS.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Repository
{
    public class UserAlevelRepository : IUserAlevelRepo
    {
        private readonly HRMDBContext _context;

        public UserAlevelRepository(HRMDBContext context)
        {
            _context = context;
        }

        public async Task<UserALevel> AddAlevel(UserALevel userALevel)
        {
            var data = await _context.userALevels.AddAsync(userALevel);
            await _context.SaveChangesAsync();
            return userALevel;
        }

        public async Task<List<UserALevel>> GetAlevelByUserId(Guid userId)
        {
            var data = await _context.userALevels.Where(a => a.userId == userId).ToListAsync();
            return data;
        }

        public async Task DeleteAlevel(Guid Id)
        {
            var data = await _context.userALevels.FindAsync(Id);
            if (data != null)
            {
               _context.userALevels.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
    }
}
