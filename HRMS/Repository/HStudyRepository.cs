using HRMS.DataBase;
using HRMS.Entities;
using HRMS.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Repository
{
    public class HStudyRepository : IHStudyRepo
    {
        private readonly HRMDBContext _context;

        public HStudyRepository(HRMDBContext context)
        {
            _context = context;
        }

        public async Task<HigherStudies> AddHStudy(HigherStudies higherStudies)
        {
            var data = await _context.higherLevels.AddAsync(higherStudies);
            await _context.SaveChangesAsync();
            return higherStudies;
        }

        public async Task<List<HigherStudies>> GetHStudeyByStudentId (Guid studentId)
        {
            var data = await _context.higherLevels.Where(h => h.StudentId == studentId).ToListAsync();
            return data;
        }

        public async Task DeleteHStudy(Guid Id)
        {
            var data = await _context.higherLevels.FindAsync(Id);
            if (data != null)
            {
                _context.higherLevels.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
    }
}
