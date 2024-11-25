using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Iservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {
        private readonly ILeaveRequestService _leaveRequestService;

        public LeaveRequestController(ILeaveRequestService leaveRequestService)
        {
            _leaveRequestService = leaveRequestService;
        }

        [HttpPost]
        public async Task<IActionResult> AddLeaveRequest(Guid UserId, Guid LeaveTypeId, LeaveReqestDtos leaveReqestDtos)
        {
            var data = await _leaveRequestService.AddLeaveRequest(UserId, LeaveTypeId, leaveReqestDtos);
            return Ok(data);
        }

    }
}
