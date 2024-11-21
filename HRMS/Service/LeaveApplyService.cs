using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Entities;
using HRMS.IRepository;
using HRMS.Iservice;

namespace HRMS.Service
{
    public class LeaveApplyService : ILeaveApplyService
    {
        private readonly ILeaveApplyRepo _leaveApplyRepo;

        public LeaveApplyService(ILeaveApplyRepo leaveApplyRepo)
        {
            _leaveApplyRepo = leaveApplyRepo;
        }

        public async Task<LeaveApplyResponseDtos> AddLeaveApply(LeaveApplyRequestDtos request)
        {
            var leaveApply = new LeaveApply
            {
                Id = Guid.NewGuid(),
                ApplyDate = DateTime.Now,
                Reason = request.Reason,
                LeaveDate = request.LeaveDate,
                EndDate = request.EndDate,
                LeaveTypeId = request.LeaveTypeId,
                UserId = request.UserId,
                Role = request.Role,
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
                EndDate = data.EndDate,
                Role = data.Role,
                IsApproved = data.IsApproved,
                LeaveType = new LeaveTypeResponseDtos { Id = data.LeaveType.Id, Name = data.LeaveType.Name },
                User = new UserLeaveResponseDtos { Id = data.User.Id, FirstName = data.User.FirstName },
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
                EndDate = l.EndDate,
                Role = l.Role,
                IsApproved = l.IsApproved,
                LeaveType = new LeaveTypeResponseDtos { Id = l.LeaveType.Id, Name = l.LeaveType.Name },
                User = new UserLeaveResponseDtos { Id = l.User.Id, FirstName = l.User.FirstName },
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
                EndDate = data.EndDate,
                Role = data.Role,
                IsApproved = data.IsApproved,
                LeaveType = new LeaveTypeResponseDtos { Id = data.LeaveType.Id, Name = data.LeaveType.Name },
                User = new UserLeaveResponseDtos { Id = data.User.Id, FirstName = data.User.FirstName },
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
