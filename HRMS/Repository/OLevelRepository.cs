using HRMS.DataBase;
using HRMS.Entities;
using HRMS.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace HRMS.Repository
{
    public class OLevelRepository : IOlevelRepo
    {
        private readonly HRMDBContext _context;

        public OLevelRepository(HRMDBContext context)
        {
            _context = context;
        }

        public async Task<OLevel> AddOlevel(OLevel olevel)
        {
            var data = await _context.oLevels.AddAsync(olevel);
            await _context.SaveChangesAsync();
            return olevel;
        }

        public async Task<List<OLevel>> GetOLevelByStudentId(Guid studentId)
        {
            var data = await _context.oLevels.Where(a => a.StudentId == studentId).ToListAsync();
            return data;

        }

        public async Task DeleteOlevels(Guid Id)
        {
            var data = await _context.oLevels.FindAsync(Id);
            if (data != null)
            {
                _context.oLevels.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
    }
}
