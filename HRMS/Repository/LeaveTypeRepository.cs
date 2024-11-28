using HRMS.DataBase;
using HRMS.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Repository
{
    public class LeaveTypeRepository : ILeaveTypeRepo
    {
        private readonly HRMDBContext _dbcontext;

        public LeaveTypeRepository(HRMDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<LeaveType> AddLeaveType (LeaveType leaveType)
        {
            var data = await _dbcontext.leaveType.AddAsync (leaveType);
            await _dbcontext.SaveChangesAsync();
            return leaveType;
        }

        public async Task<List<LeaveType>> GetAllLeaveTypes ()
        {
            var data = await _dbcontext.leaveType.Where(a =>a.IsActive).ToListAsync ();
            return data;
        }

        public async Task<LeaveType> GetLeaveTypeById(Guid Id)
        {
            var data = await _dbcontext.leaveType.Where(a => a.IsActive).FirstOrDefaultAsync (e => e.Id == Id);
            return data;
        }

        public async Task<LeaveType> UpdateLeaveType(LeaveType leaveType)
        {
            var data = await GetLeaveTypeById(leaveType.Id);
            if (data == null) return null;

            data.Name = leaveType.Name;
            data.CountPerYear = leaveType.CountPerYear;
            await _dbcontext.SaveChangesAsync();
            return leaveType;
        }

        public async Task DeleteLeaveType(Guid leaveTypeId)
        {
            var dependentRequests = await _dbcontext.leaveRequest
                .Where(lr => lr.leaveTypeId == leaveTypeId)
                .ToListAsync();

            if (dependentRequests.Any())
            {
            
                throw new InvalidOperationException("Cannot delete leave type with existing requests.");
            }

            var leaveType = await _dbcontext.leaveType.FindAsync(leaveTypeId);
            if (leaveType != null)
            {
                _dbcontext.leaveType.Remove(leaveType);
                await _dbcontext.SaveChangesAsync();
            }
        }

        public async Task<LeaveType> GetLeaveTypeByName(string leaveName)
        {
            return await _dbcontext.leaveType.FirstOrDefaultAsync(lt => lt.Name == leaveName);
        }

    }
}
