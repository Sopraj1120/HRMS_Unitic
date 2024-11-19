using HRMS.DataBase;
using HRMS.Entities;
using HRMS.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Repository
{
    public class ParentsRepository : IParentrepo
    {
        private readonly HRMDBContext _context;

        public ParentsRepository(HRMDBContext context)
        {
            _context = context;
        }

        public async Task<Parents> AddParents(Parents parents)
        {
            var data = await _context.Parents.AddAsync(parents);   
            await _context.SaveChangesAsync();
            return parents;
        }
        public async Task<List<Parents>> GetParentsByStudentId(Guid studentId)
        {
            var data = await _context.Parents.Where(p => p.StudentId == studentId).ToListAsync();
            return data;
        }

        public async Task DeleteParents(Guid Id)
        {
            var data = await _context.Parents.FindAsync(Id);
            if (data != null)
            {
                _context.Parents.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
    }
}
