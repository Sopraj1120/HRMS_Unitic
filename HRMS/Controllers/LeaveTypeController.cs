using HRMS.DTOs.RequestDtos;
using HRMS.Iservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController : ControllerBase
    {
        private readonly ILeaveTypeService _leaveType;

        public LeaveTypeController(ILeaveTypeService leaveType)
        {
            _leaveType = leaveType;
        }

        [HttpPost]
        public async Task<IActionResult> AddLeaveType(LeaveTypeRequestDtos leaveTypeRequestDtos)
        {
            var data = await _leaveType.AddLeaveType(leaveTypeRequestDtos);
            return Ok(data);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllLeaveTypes()
        {
            var data = await _leaveType.GetAllLeaveTypes();
            return Ok(data);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetLeaveTypeById(Guid Id)
        {
            var data = await _leaveType.GetLeaveTypeById(Id);
            return Ok(data);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateLeaveType(Guid Id, LeaveTypeRequestDtos leaveTypeRequestDtos)
        {
            var data = await _leaveType.UpdateleaveType(Id, leaveTypeRequestDtos);
            return Ok(data);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteleaveTypes(Guid Id)
        {
            await _leaveType.DeleteLeaveType(Id);
            return NoContent();
        }

    }
}
