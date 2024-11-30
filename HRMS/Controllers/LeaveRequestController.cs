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

        [HttpGet]
        public async Task<IActionResult> GetAllLeaveRequest()
        {
            var data = await _leaveRequestService.GetAllLeaveRequest();
            return Ok(data);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetLeaveRequestById(Guid Id)
        {
            var data = await _leaveRequestService.GetLeaveRequestById(Id);
            return Ok(data);
        }

        [HttpGet("UserId")]
        public async Task<IActionResult> GetLeaveRequestByUserId(Guid userId)
        {
            var data = await _leaveRequestService.GetLeaveRequestByUserId(userId);
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLeaveRequest(Guid Id, LeaveRequestUpdateDtos leaveRequest)
        {
            var data = await _leaveRequestService.UpdateLeaveRequest(Id, leaveRequest);
            return Ok(data);
        }

        [HttpGet("Leave_count")]
        public async  Task<IActionResult> GetTotalUsedLeave(Guid userId, Guid leaveTypeId)
        {
            var data = await _leaveRequestService.GetTotalUsedLeave(userId, leaveTypeId);
            return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteLeaveRequest(Guid Id)
        {
            await _leaveRequestService.DeleteLeaveRequest(Id);
            return NoContent();
        }

    }
}
