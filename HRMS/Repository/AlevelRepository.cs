using HRMS.DataBase;
using HRMS.Entities;
using HRMS.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Repository
{
    public class AlevelRepository : IAlevelRepo
    {
        private readonly HRMDBContext _context;

        public AlevelRepository(HRMDBContext context)
        {
            _context = context;
        }

        public async Task<ALevel> AddAlevel(ALevel alevel)
        {
            var data = await _context.AddAsync(alevel);
            await _context.SaveChangesAsync();
            return  alevel;
        }

        public async Task<List<ALevel>> GetAlByStudentId (Guid studentId)
        {
            var data = await _context.aLevels.Where(a => a.StudentId == studentId).ToListAsync();
            return data;
        }

        public async Task DeleteAls(Guid Id)
        {
            var data = await _context.aLevels.FindAsync(Id);
            if (data != null)
            {
                _context.aLevels.Remove(data);
                await _context.SaveChangesAsync();
            }
        }

    }
}
