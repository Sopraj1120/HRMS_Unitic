using HRMS.DataBase;
using HRMS.Entities;
using HRMS.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Repository
{
    public class LeaveBalanceRepo : ILeaveBalanceRepo
    {
        private readonly HRMDBContext _context;

        public LeaveBalanceRepo(HRMDBContext context)
        {
            _context = context;
        }

        public async Task<LeaveBalance> GetLeaveBalanceByUserId (Guid Id, Guid LeaveTypeId)
        {
            var data = await _context.leaveBalance.FirstOrDefaultAsync(x => x.UserId == Id && x.LeaveTypeId == LeaveTypeId);
            return data;
        }
    }
}
