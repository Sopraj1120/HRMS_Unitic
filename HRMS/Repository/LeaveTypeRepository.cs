using HRMS.DataBase;
using HRMS.Entities.HRMS.Entities;
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

        public async Task DeleteLeaveType(Guid Id)
        {
            var data = await GetLeaveTypeById (Id);

            if (data == null) return;
            data.IsActive = false;
            _dbcontext.leaveType.Update (data);
            await _dbcontext.SaveChangesAsync();
        }
           
    }
}
