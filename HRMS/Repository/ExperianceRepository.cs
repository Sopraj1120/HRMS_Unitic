using HRMS.DataBase;
using HRMS.Entities;
using HRMS.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Repository
{
    public class ExperianceRepository : IExperianceRepo
    {
        private readonly HRMDBContext _context;

        public ExperianceRepository(HRMDBContext context)
        {
            _context = context;
        }

        public async Task<Experiance> AddExperiance (Experiance experiance)
        {
            var data = await _context.experiances.AddAsync (experiance);
            await _context.SaveChangesAsync();
            return experiance;
        }

        public async Task<List<Experiance>> GetExperianceByStudentId(Guid studentId)
        {
            var data = await _context.experiances.Where(a => a.StudentId == studentId).ToListAsync();
            return data;
        }

        public async Task DeleteExperiance(Guid Id)
        {
            var data = await _context.experiances.FindAsync(Id);
            if (data != null)
            {
                _context.experiances.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
    }
}
