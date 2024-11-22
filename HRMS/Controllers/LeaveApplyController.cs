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
<<<<<<< HEAD
        public async Task<IActionResult> AddLeaveApply([FromBody] LeaveApplyRequestDtos request)
=======
        public async Task<IActionResult> AddLeaveApply(Guid userId, Guid leaveId, LeaveApplyRequestDtos request)
>>>>>>> 40170f2af8a3055066ff1e7a4ee7e295845c470b
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
<<<<<<< HEAD
        
=======
       
>>>>>>> 40170f2af8a3055066ff1e7a4ee7e295845c470b
        public async Task<IActionResult> GetLeaveApplyById(Guid id)
        {
            var result = await _leaveApplyService.GetLeaveApplyById(id);
            return Ok(result);
        }


<<<<<<< HEAD
        [HttpPut("{id}")]
=======
        [HttpPut]
>>>>>>> 40170f2af8a3055066ff1e7a4ee7e295845c470b
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
