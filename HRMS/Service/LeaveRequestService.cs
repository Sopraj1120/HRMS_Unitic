using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Entities;
using HRMS.IRepository;
using HRMS.Iservice;
using HRMS.Repository;
using System.Runtime.InteropServices;

namespace HRMS.Service
{
    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly ILeaveRequestrepo _leaveRequestrepo;
        private readonly IHollyDayRepo _hollyDayRepo;
        private readonly IUserRepo _userRepo;
        private readonly ILeaveTypeRepo _leaveTypeRepo;
        private readonly IWorkingDaysRepo _workingDaysRepo;
       

        public LeaveRequestService(ILeaveRequestrepo leaveRequestrepo, IHollyDayRepo hollyDayRepo, IUserRepo userRepo, ILeaveTypeRepo leaveTypeRepo, IWorkingDaysRepo workingDaysRepo)
        {
            _leaveRequestrepo = leaveRequestrepo;
            _hollyDayRepo = hollyDayRepo;
            _userRepo = userRepo;
            _leaveTypeRepo = leaveTypeRepo;
            _workingDaysRepo = workingDaysRepo;
        }


        private async Task<int> CalculateLeaveDays(Guid UserId, DateTime leaveDate, DateTime returnDate)
        {
            var holidays = await _hollyDayRepo.GatAllHollyDays();
            var workingdays = await _workingDaysRepo.GetWorkingDaysByUserId(UserId);

          
            var allDates = Enumerable
                .Range(0, (returnDate - leaveDate).Days ) 
                .Select(d => leaveDate.AddDays(d))
                .ToList();

            var validLeaveDays = allDates
                .Where(date =>
                    !holidays.Any(h => h.Date.Date == date.Date) && 
                    IsWorkingDay(workingdays, date.DayOfWeek))    
                .ToList();

           
            return validLeaveDays.Count;
        }

        
        private bool IsWorkingDay(WorkingDays workingDays, DayOfWeek dayOfWeek)
        {
            return dayOfWeek switch
            {
                DayOfWeek.Monday => workingDays.WeekDays.FirstOrDefault()?.Monday ?? false,
                DayOfWeek.Tuesday => workingDays.WeekDays.FirstOrDefault()?.Tuesday ?? false,
                DayOfWeek.Wednesday => workingDays.WeekDays.FirstOrDefault()?.Wednesday ?? false,
                DayOfWeek.Thursday => workingDays.WeekDays.FirstOrDefault()?.Thursday ?? false,
                DayOfWeek.Friday => workingDays.WeekDays.FirstOrDefault()?.Friday ?? false,
                DayOfWeek.Saturday => workingDays.WeekDays.FirstOrDefault()?.Saturday ?? false,
                DayOfWeek.Sunday => workingDays.WeekDays.FirstOrDefault()?.Sunday ?? false,
                _ => false
            };
        }



        public async Task<LeaveReqResponseDto> AddLeaveRequest(Guid UserId, Guid LeaveTypeId, LeaveReqestDtos leaveReqestDtos)
        {
           
            if (leaveReqestDtos == null)
                throw new ArgumentNullException(nameof(leaveReqestDtos), "Leave request DTO cannot be null.");

            if (leaveReqestDtos.ReJoinDate == default || leaveReqestDtos.LeaveDate == default)
                throw new ArgumentException("LeaveDate and ReJoinDate must be valid dates.");

            var leaves = await CalculateLeaveDays(UserId,leaveReqestDtos.LeaveDate, leaveReqestDtos.ReJoinDate);

            var totalUsedLeave = await _leaveRequestrepo.GetTotalUsedLeave(UserId, LeaveTypeId);
          
            var leavetype = await _leaveTypeRepo.GetLeaveTypeById(LeaveTypeId);
            if (leavetype == null)
                throw new KeyNotFoundException($"Leave type with ID {LeaveTypeId} not found.");

            var user = await _userRepo.GetUserById(UserId);
            if (user == null)
                throw new KeyNotFoundException($"User with ID {UserId} not found.");

        
            var availableleaves = leavetype.CountPerYear - totalUsedLeave;
            if (availableleaves < 0)
                availableleaves = 0;

            var remainingLeave = availableleaves - leaves;
           

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
                AproverId = null,
                usersId = UserId,
                User_Id = user.UsersId,
                UserName = user.FirstName,
                UserRole = user.Role,
                leaveTypeId = LeaveTypeId,
                LeaveTypeName = leavetype.Name
               

            };

      
            var data = await _leaveRequestrepo.AddLeaveRequest(leave);

          
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
                usersId = data.usersId,
                User_Id = data.User_Id,
                UserName = data.UserName,
                UserRole = data.UserRole.ToString(),
                leaveTypeId = data.leaveTypeId,
                LeaveTypeName= data.LeaveTypeName,

               
                
            };
        }

        public async Task<List<LeaveReqResponseDto>> GetAllLeaveRequest()
        {
            var data = await _leaveRequestrepo.GetAllLeaveRequest();
            var users = await _userRepo.GetAllUsers();
            var response = new List<LeaveReqResponseDto>();
            foreach (var x in data)
            {
                var user = users.FirstOrDefault(u => u.Id == x.usersId);
                var leaveResponse = new LeaveReqResponseDto
                {
                    Id = x.Id,
                    ApplyDate = x.ApplyDate.ToString("yyyy-MM-dd"),
                    Reason = x.Reason,
                    LeaveDate = x.LeaveDate.ToString("yyyy-MM-dd"),
                    ReJoinDate = x.ReJoinDate.ToString("yyyy-MM-dd"),
                    leaveCount = x.leaveCount,
                    AvailableLeaves = x.AvailableLeaves,
                    Comments = x.Comments,
                    status = x.status.ToString(),
                    AproverId = x.AproverId,
                    usersId = x.usersId,
                    User_Id = x.User_Id,
                    UserName = x.UserName,
                    UserRole = x.UserRole.ToString(),
                    leaveTypeId = x.leaveTypeId,
                    LeaveTypeName = x.LeaveTypeName

                   
                };
                response.Add(leaveResponse);
            }
            return response;

            
        
        }

        public async Task<LeaveReqResponseDto> GetLeaveRequestById(Guid Id)
        {
            
            var data = await _leaveRequestrepo.GetLeaveRequestById(Id);
            if (data == null)
                throw new KeyNotFoundException($"Leave request with ID {Id} not found.");

            var user = await _userRepo.GetUserById(data.usersId);
            if (user == null)
                throw new KeyNotFoundException($"User with ID {data.usersId} not found.");

           
            var resleave = new LeaveReqResponseDto
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
                usersId = data.usersId,
                User_Id = data.User_Id,
                UserName = data.UserName,
                UserRole = data.UserRole.ToString(),
                leaveTypeId = data.leaveTypeId,
                LeaveTypeName = data.LeaveTypeName,

            };

            return resleave;
        }


        public async Task<List<LeaveReqResponseDto>> GetLeaveRequestByUserId(Guid userId)
        {
            var data = await _leaveRequestrepo.GetLeaveRequestByUserId(userId);
            var user = await _userRepo.GetUserById(userId);

            var response = data.Select(x => new LeaveReqResponseDto
            {
                Id = x.Id,
                ApplyDate = x.ApplyDate.ToString("yyyy-MM-dd"),
                Reason = x.Reason,
                LeaveDate = x.LeaveDate.ToString("yyyy-MM-dd"),
                ReJoinDate = x.ReJoinDate.ToString("yyyy-MM-dd"),
                leaveCount = x.leaveCount,
                AvailableLeaves = x.AvailableLeaves,
                Comments = x.Comments,
                status = x.status.ToString(),
                AproverId = x.AproverId,
                usersId = x.usersId,
                User_Id = x.User_Id,
                UserName = x.UserName,
                UserRole = x.UserRole.ToString(),
                leaveTypeId = x.leaveTypeId,
                LeaveTypeName = x.LeaveTypeName

            }).ToList();

            return response;
        }

        public async Task<LeaveReqResponseDto> UpdateLeaveRequest(Guid Id, LeaveRequestUpdateDtos leaveRequest)
        {
            var data = await _leaveRequestrepo.GetLeaveRequestById(Id);
            if (data == null)
                throw new KeyNotFoundException($"Leave request with ID {Id} not found.");

         
            data.AproverId = leaveRequest.AproverId;
            data.status = leaveRequest.status;
            data.Comments = leaveRequest.Comments;

            var userResponse = await _userRepo.GetUserById(data.usersId);
            if (userResponse == null)
                throw new KeyNotFoundException($"User with ID {data.usersId} not found.");

           
            if (leaveRequest.status == status.Accept || leaveRequest.status == status.pending)
            {
                var leaveType = await _leaveTypeRepo.GetLeaveTypeById(data.leaveTypeId);
                if (leaveType == null)
                    throw new KeyNotFoundException($"Leave type with ID {data.leaveTypeId} not found.");

                var totalUsedLeave = await _leaveRequestrepo.GetTotalUsedLeave(data.usersId, data.leaveTypeId);
                var availableLeaves = leaveType.CountPerYear - totalUsedLeave;
                if (availableLeaves < data.leaveCount)
                    throw new InvalidOperationException("Insufficient leave balance for approval.");

              
                data.AvailableLeaves -= data.leaveCount;
            }
            else if (leaveRequest.status == status.Reject)
            {
              
               
                data.Comments = string.IsNullOrWhiteSpace(data.Comments) ? "Leave request rejected" : data.Comments;
                data.AvailableLeaves += data.leaveCount;
            }

            
            var updatedData = await _leaveRequestrepo.UpdateLeaveRequest(data);

           
            var response = new LeaveReqResponseDto
            {
                Id = updatedData.Id,
                ApplyDate = updatedData.ApplyDate.ToString("yyyy-MM-dd"),
                Reason = updatedData.Reason,
                LeaveDate = updatedData.LeaveDate.ToString("yyyy-MM-dd"),
                ReJoinDate = updatedData.ReJoinDate.ToString("yyyy-MM-dd"),
                leaveCount = updatedData.leaveCount,
                AvailableLeaves = updatedData.AvailableLeaves,
                Comments = updatedData.Comments,
                status = updatedData.status.ToString(),
                AproverId = updatedData.AproverId,
               usersId = updatedData.usersId,
               User_Id = updatedData.User_Id,
               UserName = updatedData.UserName,
               UserRole = updatedData.UserRole.ToString(),
               leaveTypeId = updatedData.leaveTypeId,
               LeaveTypeName = updatedData.LeaveTypeName,
            };

            return response;
        }


        public async Task<int> GetTotalUsedLeave(Guid userId, Guid leaveTypeId)
        {
            
            var leaveRequests = await _leaveRequestrepo.GetLeaveRequestByUserId(userId);

            
            var filteredLeaveRequests = leaveRequests
                .Where(lr => lr.leaveTypeId == leaveTypeId)
                .ToList();

         
            int totalLeave = 0;

            
            foreach (var leaveRequest in filteredLeaveRequests)
            {
              
                if (leaveRequest.status != status.Reject)
                {
                    if (leaveRequest.status == status.Accept || leaveRequest.status == status.pending)
                    {
                      
                        totalLeave += leaveRequest.leaveCount;
                    }
                }
                else
                {
                   
                    totalLeave += leaveRequest.AvailableLeaves;
                }
            }

       
            return totalLeave;
        }


        public async Task DeleteLeaveRequest(Guid Id)
        {
            await _leaveRequestrepo.DeleteLeaveRequest(Id);

        }
    }
}
