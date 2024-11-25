using HRMS.DataBase;
using HRMS.Entities;
using HRMS.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Repository
{
    public class LeaveRequestRepository : ILeaveRequestrepo
    {
        private readonly HRMDBContext _context;

        public LeaveRequestRepository(HRMDBContext context)
        {
            _context = context;
        }

        public async Task<LeaveRequest> AddLeaveRequest(LeaveRequest leaveRequest)
        {
            var data = await _context.leaveRequest.AddAsync(leaveRequest);
            await _context.SaveChangesAsync();
            return leaveRequest;
        }

        public async Task<List<LeaveRequest>> GetAllLeaveRequest()
        {
            var data = await _context.leaveRequest.ToListAsync();
            return data;
        }

        public async Task<LeaveRequest> GetLeaveRequestById(Guid Id)
        {
            var data = await _context.leaveRequest.FirstOrDefaultAsync(x => x.Id == Id);
            return data;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestByUserId(Guid userId)
        {
            var data = await _context.leaveRequest.Where(x => x.usersId == userId).ToListAsync();
            return data;
        }

        public async Task<int> GetTotalUsedLeave(Guid userId, Guid leaveTypeId)
        {
           
            var leaveRequests = await _context.leaveRequest
                .Where(lr => lr.usersId == userId && lr.leaveTypeId == leaveTypeId)
                .ToListAsync();

       
            var totalUsedLeave = leaveRequests.Sum(lr => lr.leaveCount);

            return totalUsedLeave;
        }
        public async Task<LeaveRequest> UpdateLeaveRequest (LeaveRequest leaveRequest)
        {
            var data = await GetLeaveRequestById(leaveRequest.Id);
            if (data == null) return null; 
            data.status = leaveRequest.status;
            data.AproverId = leaveRequest.AproverId;
            data.Comments = leaveRequest.Comments;
          
            _context.leaveRequest.Update(data);
            await _context.SaveChangesAsync();
            return leaveRequest;
        }
        public async Task DeleteLeaveRequest(Guid Id)
        {
            var data = await GetLeaveRequestById(Id);
            if (data != null)
            {
                _context.leaveRequest.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
        
    }
}
