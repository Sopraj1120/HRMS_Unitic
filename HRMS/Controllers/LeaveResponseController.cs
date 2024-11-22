using HRMS.DTOs.RequestDtos;
using HRMS.Iservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveResponseController : ControllerBase
    {
        private readonly ILeaveResponseService _leaveResponse;

        public LeaveResponseController(ILeaveResponseService leaveResponse)
        {
            _leaveResponse = leaveResponse;
        }


        [HttpPost]
        public async Task<IActionResult> AddLeaveResponce(Guid approverId, Guid leaveapplyId, LeaveResponseRequestDtos leaveResponseRequestDtos)
        {
            var data = await _leaveResponse.AddLeaveResponse(approverId, leaveapplyId, leaveResponseRequestDtos);
            return Ok(data);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetGetAllLeaveresponse()
        {
            var data = await _leaveResponse.GetAllLeaveresponse();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetleaveResponseById(Guid id)
        {
            var data = await _leaveResponse.GetleaveResponseById(id);
            return Ok(data);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetLeaveResponseByUserId(Guid userId)
        {
            var data = await _leaveResponse.GetLeaveResponseByUserId(userId);
            return Ok(data);
        }
    }
}
