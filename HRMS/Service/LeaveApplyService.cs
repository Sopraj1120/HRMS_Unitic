using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Entities;
using HRMS.IRepository;
using HRMS.Iservice;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Service
{
    public class LeaveApplyService : ILeaveApplyService
    {
        private readonly ILeaveApplyRepo _leaveApplyRepo;
        private readonly IUserRepo _userRepo;
        private readonly ILeaveTypeRepo _leaveTypeRepo;

     
        public LeaveApplyService(ILeaveApplyRepo leaveApplyRepo, IUserRepo userRepo, ILeaveTypeRepo leaveTypeRepo) 
        {
            _leaveApplyRepo = leaveApplyRepo;
            _userRepo = userRepo;
            _leaveTypeRepo = leaveTypeRepo;
        }

        public async Task<LeaveApplyResponseDtos> AddLeaveApply(Guid userId, Guid leavetypeId,LeaveApplyRequestDtos request)
        {
            var user = await _userRepo.GetUserById(userId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {userId} not found.");
            }

            var leaveType = await _leaveTypeRepo.GetLeaveTypeById(leavetypeId);
            if (leaveType == null)
            {
                throw new KeyNotFoundException($"LeaveType with ID {leavetypeId} not found.");
            }
            if (request.LeaveDate >= request.LeaveReturnDate)
            {
                throw new ArgumentException("End date must be later than the start date.");
            }

            var leaveApply = new LeaveApply
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                LeaveTypeId = leavetypeId,
                ApplyDate = DateTime.Now,
                Reason = request.Reason,
                LeaveDate = request.LeaveDate,
                LeaveReturnDate = request.LeaveReturnDate,
                IsApproved = false,
                LeaveStatus = LeaveStatus.Pending
            };

            var data = await _leaveApplyRepo.AddLeaveApply(leaveApply);

            return new LeaveApplyResponseDtos
            {
                Id = data.Id,
                ApplyDate = data.ApplyDate,
                Reason = data.Reason,
                LeaveDate = data.LeaveDate,
                LeaveReturnDate = data.LeaveReturnDate,

                LeaveType = new LeavetypeinleaveResponceDto
                {
                    Id = data.LeaveType.Id, 
                    Name = data.LeaveType.Name ,
                    CountPerYear = data.LeaveType.CountPerYear
                   
                },
                User = new UserLeaveResponseDtos
                {
                    Id = data.User.Id, 
                    FirstName = data.User.FirstName,
                    Role = data.User.Role,
                    PhoneNumber = data.User.PhoneNumber
                },
            };
        }

        public async Task<List<LeaveApplyResponseDtos>> GetAllLeaveApplies()
        {
            var data = await _leaveApplyRepo.GetAllLeaveApplies();
            return data.Select(l => new LeaveApplyResponseDtos
            {
                Id = l.Id,
                ApplyDate = l.ApplyDate,
                Reason = l.Reason,
                LeaveDate = l.LeaveDate,
                LeaveReturnDate = l.LeaveReturnDate,

                LeaveType = new LeavetypeinleaveResponceDto
                {
                    Id = l.LeaveType.Id,
                    Name = l.LeaveType.Name
                },
                User = new UserLeaveResponseDtos
                {
                    Id = l.User.Id,
                    FirstName = l.User.FirstName,
                    Role = l.User.Role,
                    PhoneNumber = l.User.PhoneNumber
                },
            }).ToList();
        }

        public async Task<LeaveApplyResponseDtos> GetLeaveApplyById(Guid id)
        {
            var data = await _leaveApplyRepo.GetLeaveApplyById(id);

            if (data == null)
                throw new KeyNotFoundException("Leave application not found.");

            return new LeaveApplyResponseDtos
            {
                Id = data.Id,
                ApplyDate = data.ApplyDate,
                Reason = data.Reason,
                LeaveDate = data.LeaveDate,
                LeaveReturnDate = data.LeaveReturnDate,

                LeaveType = new LeavetypeinleaveResponceDto
                { 
                    Id = data.LeaveType.Id, 
                    Name = data.LeaveType.Name 
                },
                User = new UserLeaveResponseDtos
                { 
                    Id = data.User.Id, 
                    FirstName = data.User.FirstName,
                    Role = data.User.Role,
                    PhoneNumber = data.User.PhoneNumber
                },
            };
        }

        public async Task UpdateLeaveStatus(Guid id, LeaveStatus status, bool isApproved, DateTime? approvedDate)
        {
            var leaveApply = await _leaveApplyRepo.GetLeaveApplyById(id);
            if (leaveApply == null)
                throw new KeyNotFoundException("Leave application not found.");

            leaveApply.LeaveStatus = status;
            leaveApply.IsApproved = isApproved;
            leaveApply.ApprovedDate = approvedDate;

            await _leaveApplyRepo.UpdateLeaveApply(leaveApply);
        }

        public async Task DeleteLeaveApplyById(Guid id)
        {
            var leaveApply = await _leaveApplyRepo.GetLeaveApplyById(id);
            if (leaveApply == null)
                throw new KeyNotFoundException("Leave application not found.");

            await _leaveApplyRepo.DeleteLeaveApply(id);
        }
    }
}
