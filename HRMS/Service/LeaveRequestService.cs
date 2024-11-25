using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Entities;
using HRMS.IRepository;
using HRMS.Iservice;
using HRMS.Repository;

namespace HRMS.Service
{
    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly ILeaveRequestrepo _leaveRequestrepo;
        private readonly IHollyDayRepo _hollyDayRepo;
        private readonly IUserRepo _userRepo;
        private readonly ILeaveTypeRepo _leaveTypeRepo;
       

        public LeaveRequestService(ILeaveRequestrepo leaveRequestrepo, IHollyDayRepo hollyDayRepo, IUserRepo userRepo, ILeaveTypeRepo leaveTypeRepo)
        {
            _leaveRequestrepo = leaveRequestrepo;
            _hollyDayRepo = hollyDayRepo;
            _userRepo = userRepo;
            _leaveTypeRepo = leaveTypeRepo;
        }


        private async Task<int> CalculateLeaveDays(DateTime leaveDate, DateTime returnDate)
        {
            var holidays = await _hollyDayRepo.GatAllHollyDays();
          
            
            var allDates = Enumerable
                .Range(0, (returnDate - leaveDate).Days )
                .Select(d => leaveDate.AddDays(d))
                .ToList();

            
            var validLeaveDays = allDates
                .Where(date => !holidays.Any(holidays=> holidays.Date.Date == date.Date) &&
                               date.DayOfWeek != DayOfWeek.Saturday &&
                               date.DayOfWeek != DayOfWeek.Sunday)
                .ToList();

            return validLeaveDays.Count;
        }


        public async Task<LeaveReqResponseDto> AddLeaveRequest(Guid UserId, Guid LeaveTypeId, LeaveReqestDtos leaveReqestDtos)
        {
            // Null check for leaveReqestDtos
            if (leaveReqestDtos == null)
                throw new ArgumentNullException(nameof(leaveReqestDtos), "Leave request DTO cannot be null.");

            if (leaveReqestDtos.ReJoinDate == default || leaveReqestDtos.LeaveDate == default)
                throw new ArgumentException("LeaveDate and ReJoinDate must be valid dates.");

            // Calculate leaves
            var leaves = await CalculateLeaveDays(leaveReqestDtos.LeaveDate, leaveReqestDtos.ReJoinDate);

            var totalUsedLeave = await _leaveRequestrepo.GetTotalUsedLeave(UserId, LeaveTypeId);
            // Repository calls with null checks
            var leavetype = await _leaveTypeRepo.GetLeaveTypeById(LeaveTypeId);
            if (leavetype == null)
                throw new KeyNotFoundException($"Leave type with ID {LeaveTypeId} not found.");

            var user = await _userRepo.GetUserById(UserId);
            if (user == null)
                throw new KeyNotFoundException($"User with ID {UserId} not found.");

            // Ensure available leaves calculation is correct
            var availableleaves = leavetype.CountPerYear - totalUsedLeave;
            if (availableleaves < 0)
                availableleaves = 0;

            var remainingLeave = availableleaves - leaves;
            // Create LeaveRequest object
            var leave = new LeaveRequest
            {
                Id = Guid.NewGuid(),
                ApplyDate = leaveReqestDtos.ApplyDate,
                Reason = leaveReqestDtos.Reason,
                LeaveDate = leaveReqestDtos.LeaveDate,
                ReJoinDate = leaveReqestDtos.ReJoinDate,
                leaveCount = leaves,
                AvailableLeaves = remainingLeave,
                Comments = leaveReqestDtos.Comments,
                AproverId = leaveReqestDtos.AproverId,
                usersId = UserId,
                leaveTypeId = LeaveTypeId,
               

            };

            // Save to repository
            var data = await _leaveRequestrepo.AddLeaveRequest(leave);

            // Return response
            return new LeaveReqResponseDto
            {
                Id = data.Id,
                ApplyDate = data.ApplyDate.ToString("yyyy-MM-dd"),
                Reason = data.Reason,
                LeaveDate = data.LeaveDate.ToString("yyyy-MM-dd"),
                ReJoinDate = data.ReJoinDate.ToString("yyyy-MM-dd"),
                leaveCount = data.leaveCount,
                AvailableLeaves = data.AvailableLeaves,
                Comments = data.Comments,
                status = data.status.ToString(),
                AproverId = data.AproverId,
                Users = new UserLeaveResponseDtos
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    PhoneNumber = user.PhoneNumber,
                    Role = user.Role.ToString()
                }
                
            };
        }



    }
}
