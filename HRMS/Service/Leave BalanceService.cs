using HRMS.DTOs.ResponseDtos;
using HRMS.IRepository;
using HRMS.Iservice;
using Microsoft.Identity.Client;

namespace HRMS.Service
{
    public class Leave_BalanceService : ILeaveBalanceService
    {
        private readonly ILeaveBalanceRepo _leaveBalanceRepo;
   

        public Leave_BalanceService(ILeaveBalanceRepo leaveBalanceRepo)
        {
            _leaveBalanceRepo = leaveBalanceRepo;
           
        }

       

        public async Task<LeaveBalanceResponseDtos> GetLeaveBalanceByUserId(Guid userId, Guid leaveTypeId)
        {
            // Get the leave balance data from the repository
            var data = await _leaveBalanceRepo.GetLeaveBalanceByUserId(userId, leaveTypeId);

            // If data is null, return an empty response with 0 balance and empty leaveType list
            if (data == null)
            {
                return new LeaveBalanceResponseDtos
                {
                    UserId = userId,
                    Leavebalance = 0,
                    LeaveType = new List<LeaveTypeResponseDtos>()
                };
            }

          

            // Map the leave types to the response DTO
            var resLeaveType = new LeaveBalanceResponseDtos
            {
                Id = data.Id,
                UserId = userId,
                Leavebalance = 0,
                LeaveType = data.leaveTypes?.Select(lt => new LeaveTypeResponseDtos
                {
                    Id = lt.Id,
                    Name = lt.Name,
                    CountPerYear = lt.CountPerYear
                }).ToList() ?? new List<LeaveTypeResponseDtos>(), // Ensure empty list if no leaveTypes are present
            };

            return resLeaveType;
        }
    }
}
