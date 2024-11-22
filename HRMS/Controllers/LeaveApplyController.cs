using HRMS.DTOs.RequestDtos;
using HRMS.Entities;
using HRMS.Iservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveApplyController : ControllerBase
    {
        private readonly ILeaveApplyService _leaveApplyService;

        public LeaveApplyController(ILeaveApplyService leaveApplyService)
        {
            _leaveApplyService = leaveApplyService;
        }

        [HttpPost]

        public async Task<IActionResult> AddLeaveApply(Guid userId, Guid leaveId, LeaveApplyRequestDtos request)
        {
            try
            {
                var result = await _leaveApplyService.AddLeaveApply(userId, leaveId, request);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetAllLeaveApplies()
        {
            var result = await _leaveApplyService.GetAllLeaveApplies();
            return Ok(result);
        }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetLeaveApplyById(Guid id)
        {
            var result = await _leaveApplyService.GetLeaveApplyById(id);
            return Ok(result);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLeaveStatus(Guid id, [FromBody] LeaveStatus status, [FromQuery] bool isApproved, [FromQuery] DateTime? approvedDate)
        {
            await _leaveApplyService.UpdateLeaveStatus(id, status, isApproved, approvedDate);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeaveApplyById(Guid id)
        {
            await _leaveApplyService.DeleteLeaveApplyById(id);
            return Ok(id);
        }
    }
}
