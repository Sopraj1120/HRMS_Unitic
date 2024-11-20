using HRMS.DataBase;
using HRMS.Entities;
using HRMS.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Repository
{
   
    public class UserExperianceRepository : IUserExperianceRepo
    {
        private readonly HRMDBContext _context;

        public UserExperianceRepository(HRMDBContext context)
        {
            _context = context;
        }

        public async Task<UserExperiance> AddExperiance(UserExperiance userExperiance)
        {
            var data = await _context.userExperiances.AddAsync(userExperiance);
            await _context.SaveChangesAsync();
            return userExperiance;
        }

        public async Task<List<UserExperiance>> GetExperianceByUserId( Guid userId)
        {
            var data = await _context.userExperiances.Where(e => e.UserId == userId).ToListAsync();
            return data;
        }

        public async Task DeleteExperiance(Guid Id)
        {
            var data = await _context.userExperiances.FindAsync(Id);
            if (data != null)
            {
                _context.userExperiances.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
    }
}
