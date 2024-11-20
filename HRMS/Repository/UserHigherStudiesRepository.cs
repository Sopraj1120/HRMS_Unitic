using HRMS.DataBase;
using HRMS.Entities;
using HRMS.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Repository
{
    public class UserHigherStudiesRepository : IUserHigherStudiesrepo
    {
        private readonly HRMDBContext _context;

        public UserHigherStudiesRepository(HRMDBContext context)
        {
            _context = context;
        }

        public async Task<UserHigherStudies> AddHStudy (UserHigherStudies userHigherStudies)
        {
            var data = await _context.userHigherStudies.AddAsync (userHigherStudies);
            await _context.SaveChangesAsync();
            return userHigherStudies;
        }

        public async Task<List<UserHigherStudies>> GetHStudyByUserId( Guid userId)
        {
            var data  = await _context.userHigherStudies.Where(e => e. UserId == userId).ToListAsync();
            return data;
           
        }

        public async Task DeleteHStudy(Guid Id)
        {
            var data = await _context.userHigherStudies.FindAsync(Id);
            if (data != null)
            {
                _context.userHigherStudies.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
    }
}
