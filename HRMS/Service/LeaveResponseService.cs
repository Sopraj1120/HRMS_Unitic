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

        public LeaveResponseService(ILeaveResponceRepo leaveResponceRepo, ILeaveApplyRepo leaveApplyRepo, IUserRepo userRepo)
        {
            _leaveResponceRepo = leaveResponceRepo;
            _leaveApplyRepo = leaveApplyRepo;
            _userRepo = userRepo;
        }

        
        private int CalculateLeaveDays(DateTime leaveDate, DateTime endDate)
        {
            return (endDate - leaveDate).Days;
        }


        private LeaveApplyResponseDtos MapLeaveApplyToResponseDtos(LeaveApply leave)
        {
            if (leave.User == null)
            {
                
                throw new InvalidOperationException("User information is missing for LeaveApply with ID: " + leave.Id);
            }

            if (leave.LeaveType == null)
            {
                throw new InvalidOperationException("LeaveType information is missing for LeaveApply with ID: " + leave.Id);
            }

            return new LeaveApplyResponseDtos
            {
                Id = leave.Id,
                ApplyDate = leave.ApplyDate,
                LeaveDate = leave.LeaveDate,
                EndDate = leave.EndDate,
                Reason = leave.Reason,
                LeaveType = new LeaveTypeResponseDtos
                {
                    Id = leave.LeaveType.Id,
                    Name = leave.LeaveType.Name,
                    CountPerYear = leave.LeaveType.CountPerYear,
                    IsActive = leave.LeaveType.IsActive
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
          
            var leave = await _leaveApplyRepo.GetLeaveApplyById(leaveapplyId);
            if (leave == null)
            {
                throw new KeyNotFoundException($"Leave application with ID {leaveapplyId} not found.");
            }

            int leaveDays = CalculateLeaveDays(leave.LeaveDate, leave.EndDate);

           
            var leaveResponse = new LeaveResponse
            {
                Id = Guid.NewGuid(),
                LeaveApplyId = leaveapplyId,
                LeaveTypeId= leave.LeaveTypeId??default,
                UserId= leave.User.Id,
                ApproverId = approverId,
                Status = leaveResponseRequestDtos.Status,
                Comments = leaveResponseRequestDtos.Comments,
                ResponceDate = DateTime.Now,




            };

       
            var addedResponse = await _leaveResponceRepo.AddLeaveResponce(leaveResponse);

          
            var responseDto = new LeaveResponseResponseDtos
            {
                Id = addedResponse.Id,
                Status = addedResponse.Status,
                Comments = addedResponse.Comments,
                ApproverId = addedResponse.ApproverId,
                LeaveDaysCount = leaveDays,
                LeaveType = new LeaveTypeResponseDtos
                {
                    Id = addedResponse.LeaveType?.Id ?? Guid.Empty,
                    Name = addedResponse.LeaveType?.Name,
                    CountPerYear = addedResponse.LeaveType?.CountPerYear ?? 0,
                    IsActive = addedResponse.LeaveType?.IsActive ?? false
                },
                LeaveApply = MapLeaveApplyToResponseDtos(leave)
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

                int leaveDays = CalculateLeaveDays(leaveApplication.LeaveDate, leaveApplication.EndDate);

                var responseDto = new LeaveResponseResponseDtos
                {
                    Id = leaveResponse.Id,
                    Status = leaveResponse.Status,
                    Comments = leaveResponse.Comments,
                    ApproverId = leaveResponse.ApproverId,
                    LeaveDaysCount = leaveDays,
                    LeaveType = new LeaveTypeResponseDtos
                    {
                        Id = leaveResponse.LeaveType?.Id ?? Guid.Empty,
                        Name = leaveResponse.LeaveType?.Name,
                        CountPerYear = leaveResponse.LeaveType?.CountPerYear ?? 0,
                        IsActive = leaveResponse.LeaveType?.IsActive ?? false
                    },
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

            int leaveDays = CalculateLeaveDays(leave.LeaveDate, leave.EndDate);

            var responseDto = new LeaveResponseResponseDtos
            {
                Id = data.Id,
                Status = data.Status,
                Comments = data.Comments,
                ApproverId = data.ApproverId,
                LeaveDaysCount = leaveDays,
                LeaveType = new LeaveTypeResponseDtos
                {
                    Id = data.LeaveType?.Id ?? Guid.Empty,
                    Name = data.LeaveType?.Name,
                    CountPerYear = data.LeaveType?.CountPerYear ?? 0,
                    IsActive = data.LeaveType?.IsActive ?? false
                },
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

                int leaveDays = CalculateLeaveDays(leaveApplication.LeaveDate, leaveApplication.EndDate);

                var responseDto = new LeaveResponseResponseDtos
                {
                    Id = leaveResponse.Id,
                    Status = leaveResponse.Status,
                    Comments = leaveResponse.Comments,
                    ApproverId = leaveResponse.ApproverId,
                    LeaveDaysCount = leaveDays,
                    LeaveType = new LeaveTypeResponseDtos
                    {
                        Id = leaveResponse.LeaveType?.Id ?? Guid.Empty,
                        Name = leaveResponse.LeaveType?.Name,
                        CountPerYear = leaveResponse.LeaveType?.CountPerYear ?? 0,
                        IsActive = leaveResponse.LeaveType?.IsActive ?? false
                    },
                    LeaveApply = MapLeaveApplyToResponseDtos(leaveApplication)
                };

                responseDtos.Add(responseDto);
            }

            return responseDtos;
        }
    }
}
