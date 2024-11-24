using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Entities;
using HRMS.IRepository;
using HRMS.Iservice;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Service
{
    public class LeaveResponseService : ILeaveResponseService
    {
        private readonly ILeaveResponceRepo _leaveResponceRepo;
        private readonly ILeaveApplyRepo _leaveApplyRepo;
        private readonly IUserRepo _userRepo;
        private readonly IHollyDayRepo _hollyDayRepo;

        public LeaveResponseService(ILeaveResponceRepo leaveResponceRepo, ILeaveApplyRepo leaveApplyRepo, IUserRepo userRepo, IHollyDayRepo hollyDayRepo)
        {
            _leaveResponceRepo = leaveResponceRepo;
            _leaveApplyRepo = leaveApplyRepo;
            _userRepo = userRepo;
            _hollyDayRepo = hollyDayRepo;
        }

        private async Task<int> CalculateLeaveDays(DateTime leaveDate, DateTime endDate)
        {
            var holidays = await _hollyDayRepo.GatAllHollyDays();

            var allDates = Enumerable
                .Range(0, (endDate - leaveDate).Days)
                .Select(d => leaveDate.AddDays(d))
                .ToList();

            var validLeaveDays = allDates
                .Where(date => !holidays.Any(holiday => holiday.Date.Date == date.Date) &&
                               date.DayOfWeek != DayOfWeek.Saturday &&
                               date.DayOfWeek != DayOfWeek.Sunday)
                .ToList();

            return validLeaveDays.Count;
        }

        private LeaveApplyResponseDtos MapLeaveApplyToResponseDtos(LeaveApply leave)
        {
            if (leave.User == null)
            {
                throw new InvalidOperationException($"User information is missing for LeaveApply with ID: {leave.Id}");
            }

            if (leave.LeaveType == null)
            {
                throw new InvalidOperationException($"LeaveType information is missing for LeaveApply with ID: {leave.Id}");
            }

            return new LeaveApplyResponseDtos
            {
                Id = leave.Id,
                ApplyDate = leave.ApplyDate,
                LeaveDate = leave.LeaveDate,
                LeaveReturnDate = leave.LeaveReturnDate,
                Reason = leave.Reason,
                LeaveType = new LeavetypeinleaveResponceDto
                {
                    Id = leave.LeaveType.Id,
                    Name = leave.LeaveType.Name,
                    CountPerYear = leave.LeaveType.CountPerYear,
                },
                User = new UserLeaveResponseDtos
                {
                    Id = leave.User.Id,
                    FirstName = leave.User.FirstName,
                    Role = leave.User.Role,
                    PhoneNumber = leave.User.PhoneNumber
                },
            };
        }

        public async Task<LeaveResponseResponseDtos> AddLeaveResponse(Guid approverId, Guid leaveapplyId, LeaveResponseRequestDtos leaveResponseRequestDtos)
        {
            // Fetch leave application
            var leave = await _leaveApplyRepo.GetLeaveApplyById(leaveapplyId);
            if (leave == null)
            {
                throw new KeyNotFoundException($"Leave application with ID {leaveapplyId} not found.");
            }

            // Fetch user information
            var user = await _userRepo.GetUserById(leave.UserId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {leave.UserId} not found.");
            }

            // Calculate the number of leave days (assuming this is correct)
            int leaveDays = await CalculateLeaveDays(leave.LeaveDate, leave.LeaveReturnDate);

            // Calculate the remaining balance after leave days are deducted
            int remainingBalance = leave.LeaveType.CountPerYear - leaveDays;

            // Check if the leave can be approved based on available leave balance
            if (leaveResponseRequestDtos.Status == status.Accept)
            {
                if (remainingBalance < 0)
                {
                    throw new InvalidOperationException($"User does not have enough leave balance. Required: {leaveDays}, Available: {leave.LeaveType.CountPerYear}");
                }

                // Update the user's available leave balance if leave is approved
                user.AvailableLeaveDays = remainingBalance;
                await _userRepo.UpdateUser(user);
            }

            // Create the LeaveResponse entity
            var leaveResponse = new LeaveResponse
            {
                Id = Guid.NewGuid(),
                LeaveApplyId = leaveapplyId,
                ApproverId = approverId,
                Status = leaveResponseRequestDtos.Status,
                Comments = leaveResponseRequestDtos.Comments,
                LeaveDaysCount = leaveDays,
                UserLeaveBalance = remainingBalance, // Use the calculated remaining balance
            };

            // Add the leave response
            var addedResponse = await _leaveResponceRepo.AddLeaveResponce(leaveResponse);

            // Map the leave application details to the response DTO
            var responseDto = new LeaveResponseResponseDtos
            {
                Id = addedResponse.Id,
                Status = addedResponse.Status.ToString(),
                Comments = addedResponse.Comments,
                LeaveDaysCount = leaveDays,
                ApproverId = approverId,
                LeaveApply = MapLeaveApplyToResponseDtos(leave), // Ensure this method works properly
                UserLeaveBalance = remainingBalance // Return the correct remaining balance
            };

            return responseDto;
        }





        public async Task<List<LeaveResponseResponseDtos>> GetAllLeaveresponse()
        {
            var leaveResponses = await _leaveResponceRepo.GetAllLeaveResponce();

            var responseDtos = new List<LeaveResponseResponseDtos>();

            foreach (var leaveResponse in leaveResponses)
            {
                var leaveApplication = await _leaveApplyRepo.GetLeaveApplyById(leaveResponse.LeaveApplyId);
                if (leaveApplication == null)
                {
                    throw new KeyNotFoundException($"Leave application with ID {leaveResponse.LeaveApplyId} not found.");
                }

                int leaveDays =await CalculateLeaveDays(leaveApplication.LeaveDate, leaveApplication.LeaveReturnDate);

                var responseDto = new LeaveResponseResponseDtos
                {
                    Id = leaveResponse.Id,
                    Status = leaveResponse.Status.ToString(),
                    Comments = leaveResponse.Comments,
                    ApproverId = leaveResponse.ApproverId,
                    LeaveDaysCount = leaveDays,
                   
                    LeaveApply = MapLeaveApplyToResponseDtos(leaveApplication)
                };

                responseDtos.Add(responseDto);
            }

            return responseDtos;
        }

     
        public async Task<LeaveResponseResponseDtos> GetleaveResponseById(Guid id)
        {
            var data = await _leaveResponceRepo.GetleaveResponseById(id);
            if (data == null)
            {
                throw new KeyNotFoundException($"Leave response with ID {id} not found.");
            }

            var leave = await _leaveApplyRepo.GetLeaveApplyById(data.LeaveApplyId);
            if (leave == null)
            {
                throw new KeyNotFoundException($"Leave application with ID {data.LeaveApplyId} not found.");
            }

            int leaveDays = await CalculateLeaveDays(leave.LeaveDate, leave.LeaveReturnDate);

            var responseDto = new LeaveResponseResponseDtos
            {
                Id = data.Id,
                Status = data.Status.ToString(),
                Comments = data.Comments,
                ApproverId = data.ApproverId,
                LeaveDaysCount = leaveDays,
               
                LeaveApply = MapLeaveApplyToResponseDtos(leave)
            };

            return responseDto;
        }

      
        public async Task<List<LeaveResponseResponseDtos>> GetLeaveResponseByUserId(Guid userId)
        {
            var data = await _leaveResponceRepo.GetLeaveResponseByUserId(userId);

            if (data == null || !data.Any())
            {
                throw new KeyNotFoundException($"No leave responses found for user ID {userId}.");
            }

            var responseDtos = new List<LeaveResponseResponseDtos>();

            foreach (var leaveResponse in data)
            {
                var leaveApplication = await _leaveApplyRepo.GetLeaveApplyById(leaveResponse.LeaveApplyId);
                if (leaveApplication == null)
                {
                    throw new KeyNotFoundException($"Leave application with ID {leaveResponse.LeaveApplyId} not found.");
                }

                int leaveDays = await CalculateLeaveDays(leaveApplication.LeaveDate, leaveApplication.LeaveReturnDate);

                var responseDto = new LeaveResponseResponseDtos
                {
                    Id = leaveResponse.Id,
                    Status = leaveResponse.Status.ToString(),
                    Comments = leaveResponse.Comments,
                    ApproverId = leaveResponse.ApproverId,
                    LeaveDaysCount = leaveDays,
                  
                    LeaveApply = MapLeaveApplyToResponseDtos(leaveApplication)
                };

                responseDtos.Add(responseDto);
            }

            return responseDtos;
        }
    }
}
