using HRMS.DataBase;
using HRMS.Entities;
using HRMS.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Repository
{
    public class LeaveApplyRepo : ILeaveApplyRepo
    {
        private readonly HRMDBContext _context;

        public LeaveApplyRepo(HRMDBContext context)
        {
            _context = context;
        }

        public async Task<LeaveApply> AddLeaveApply(LeaveApply leaveApply)
        {
            var data = await _context.leaveApply.AddAsync(leaveApply);
            await _context.SaveChangesAsync();
            return data.Entity;
        }

        public async Task<List<LeaveApply>> GetAllLeaveApplies()
        {
            return await _context.leaveApply.Include(l => l.LeaveType).Include(l => l.User).ToListAsync();
        }

        public async Task<LeaveApply> GetLeaveApplyById(Guid id)
        {
            return await _context.leaveApply
                .Include(l => l.LeaveType)
                .Include(l => l.User)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<LeaveApply> UpdateLeaveApply(LeaveApply leaveApply)
        {
            var data = _context.leaveApply.Update(leaveApply);
            await _context.SaveChangesAsync();
            return data.Entity;
        }

        public async Task DeleteLeaveApply(Guid id)
        {
            var leaveApply = await GetLeaveApplyById(id);
            if (leaveApply != null)
            {
                _context.leaveApply.Remove(leaveApply);
                await _context.SaveChangesAsync();
            }
        }

       
    }
}
