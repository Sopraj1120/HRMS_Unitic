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
            return leaveApply;
        }

        public async Task<List<LeaveApply>> GetAllLeaveApplies()
        {
            var data = await _context.leaveApply.Include(lt => lt.LeaveType).Include(u => u.User).ToListAsync();
            return data;

            
        }

        public async Task<LeaveApply> GetLeaveApplyById(Guid id)
        {
            var data= await _context.leaveApply.Include(l => l.LeaveType).Include(l => l.User).FirstOrDefaultAsync(l => l.Id == id);
            if (data == null)
            {
                throw new KeyNotFoundException($"Leave application with ID {id} not found.");
            }
            return data;
        }

        public async Task<LeaveApply> UpdateLeaveApply(LeaveApply leaveApply)
        {
            var leave = await GetLeaveApplyById(leaveApply.Id);
            if (leave == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            _context.Entry(leave).CurrentValues.SetValues(leaveApply);

            await _context.SaveChangesAsync();
            return leaveApply;
        }
            

        public async Task DeleteLeaveApply(Guid id)
        {
            var leaveApply = await GetLeaveApplyById(id);
            if (leaveApply == null)
            {
                throw new KeyNotFoundException("Leave apply not found.");
            }
            _context.leaveApply.Remove(leaveApply);
            await _context.SaveChangesAsync();
        }

    }
}
