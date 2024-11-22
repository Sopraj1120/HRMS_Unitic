using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.IRepository;
using HRMS.Iservice;

namespace HRMS.Service
{
    public class LeaveTypeService : ILeaveTypeService
    {
        private readonly ILeaveTypeRepo _leaveTypeRepo;

        public LeaveTypeService(ILeaveTypeRepo leaveTypeRepo)
        {
            _leaveTypeRepo = leaveTypeRepo;
        }


        public async Task<LeaveTypeResponseDtos> AddLeaveType(LeaveTypeRequestDtos leaveTypeRequestDtos)
        {
            var leave = new LeaveType
            {
                Id = Guid.NewGuid(),
                Name = leaveTypeRequestDtos.Name,
                CountPerYear = leaveTypeRequestDtos.CountPerYear,

            };

            var data = await _leaveTypeRepo.AddLeaveType(leave);

            var resleavetype = new LeaveTypeResponseDtos
            {
                Id = data.Id,
                Name = data.Name,
                CountPerYear = data.CountPerYear,
                IsActive = data.IsActive,
            };
            return resleavetype;


        }

        public async Task<List<LeaveTypeResponseDtos>> GetAllLeaveTypes()
        {
            var data = await _leaveTypeRepo.GetAllLeaveTypes();
            var resleave = data.Select(l => new LeaveTypeResponseDtos
            {
                Id = l.Id,
                Name = l.Name,
                CountPerYear = l.CountPerYear,
                IsActive = l.IsActive,
            }).ToList();

            return resleave;
        }

        public async Task<LeaveTypeResponseDtos> GetLeaveTypeById(Guid Id)
        {
            var data = await _leaveTypeRepo.GetLeaveTypeById(Id);

            var resleave = new LeaveTypeResponseDtos
            {
                Id = data.Id,
                Name = data.Name,
                CountPerYear = data.CountPerYear,
                IsActive = data.IsActive,
            };
            return resleave;
        }

        public async Task<LeaveTypeResponseDtos> UpdateleaveType(Guid Id, LeaveTypeRequestDtos leaveTypeRequestDtos)
        {
            
            var leavetype = await _leaveTypeRepo.GetLeaveTypeById(Id);
            if (leavetype == null)
                throw new KeyNotFoundException("LeaveType not found.");

            leavetype.Name = leaveTypeRequestDtos.Name;
            leavetype.CountPerYear = leaveTypeRequestDtos.CountPerYear;

           
            var updatedLeaveType = await _leaveTypeRepo.UpdateLeaveType(leavetype);

         
            var response = new LeaveTypeResponseDtos
            {
                Id = updatedLeaveType.Id,
                Name = updatedLeaveType.Name,
                CountPerYear = updatedLeaveType.CountPerYear,
                IsActive = updatedLeaveType.IsActive,
              
            };

            return response;
        }

        public async Task DeleteLeaveType(Guid Id)
        {
            await _leaveTypeRepo.DeleteLeaveType(Id);
        }

    }
}
