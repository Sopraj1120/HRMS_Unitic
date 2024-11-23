using HRMS.DataBase;
using HRMS.DTOs.ResponseDtos;
using HRMS.Entities;
using HRMS.IRepository;

using Microsoft.EntityFrameworkCore;

namespace HRMS.Repository
{
    public class LeaveResponceRepo : ILeaveResponceRepo
    {
        private readonly HRMDBContext _context;

        public LeaveResponceRepo(HRMDBContext context)
        {
            _context = context;
        }

        public async Task<LeaveResponse> AddLeaveResponce(LeaveResponse leaveResponse)
        {
                var data = await _context.leaveResponse.AddAsync(leaveResponse);
            await _context.SaveChangesAsync();
            return leaveResponse;

        }

        public async Task<List<LeaveResponse>> GetAllLeaveResponce()
        {
            var data = await _context.leaveResponse.Include(la => la.LeaveApply).ToListAsync();
            return data;
        }

        public async Task<LeaveResponse> GetleaveResponseById(Guid Id)
        {
            var data = await _context.leaveResponse.Include(la => la.LeaveApply).FirstOrDefaultAsync(a => a.Id == Id);
            if (data == null)
            {
                throw new Exception("Not responce data here!");
            }
            return data;
        }


        public async Task<List<LeaveResponse>> GetLeaveResponseByUserId(Guid userId)
        {
            var data = await _context.leaveResponse.Include(la => la.LeaveApply).ToListAsync();

            if (data == null)
            {
                throw new Exception("User Not apply Leave");
            }
            return data;
        }
        public async Task<int> GetTotalLeavesForUser(Guid userId)
        {
            return await _context.leaveResponse
               
                .SumAsync(lr => lr.LeaveDaysCount);
        }

    }
}
