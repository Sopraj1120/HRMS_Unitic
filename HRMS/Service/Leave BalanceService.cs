using HRMS.DTOs.ResponseDtos;
using HRMS.IRepository;
using HRMS.Iservice;
using Microsoft.Identity.Client;

namespace HRMS.Service
{
    public class Leave_BalanceService : ILeaveBalanceService
    {
        private readonly ILeaveBalanceRepo _leaveBalanceRepo;
        private readonly ILeaveResponceRepo _leaveResponceRepo;

        public Leave_BalanceService(ILeaveBalanceRepo leaveBalanceRepo, ILeaveResponceRepo leaveResponceRepo)
        {
            _leaveBalanceRepo = leaveBalanceRepo;
            _leaveResponceRepo = leaveResponceRepo;
        }

        private async Task<int> CalculateLeaveBalance(Guid userId, Guid leaveTypeId)
        {
            // Get leave responses for the user
            var leaveResponses = await _leaveResponceRepo.GetLeaveResponseByUserId(userId);

            // Check if leaveResponses are null or empty
            if (leaveResponses == null || !leaveResponses.Any())
            {
                // If no leave responses, return available leave balance
                var leavebalance = await _leaveBalanceRepo.GetLeaveBalanceByUserId(userId, leaveTypeId);

                // If no leave balance, return 0 as fallback
                return leavebalance?.CountPerYear ?? 0;
            }

            // Check if leaveTypeId exists in the LeaveApply of each LeaveResponse
            var leaveTypeResponses = leaveResponses
                .Where(r => r.LeaveApply != null && r.LeaveApply.Any(l => l.LeaveTypeId == leaveTypeId))
                .Sum(r => r.LeaveDaysCount);

            // Get leave balance for the user and leave type
            var leaveBalance = await _leaveBalanceRepo.GetLeaveBalanceByUserId(userId, leaveTypeId);

            // If leave balance is null, return 0
            if (leaveBalance == null)
            {
                return 0;
            }

            // Calculate the available balance (ensure it doesn't go negative)
            int availableBalance = leaveBalance.CountPerYear - leaveTypeResponses;

            // Ensure the balance is not negative
            return availableBalance < 0 ? 0 : availableBalance;
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

            // Calculate leave balance based on responses and leave type
            int leaveBalance = await CalculateLeaveBalance(userId, leaveTypeId);

            // Map the leave types to the response DTO
            var resLeaveType = new LeaveBalanceResponseDtos
            {
                Id = data.Id,
                UserId = userId,
                Leavebalance = leaveBalance,
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
