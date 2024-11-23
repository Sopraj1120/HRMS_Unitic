using HRMS.DTOs.ResponseDtos;
using HRMS.Iservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveBalanceController : ControllerBase
    {
        private readonly ILeaveBalanceService _leaveBalanceService;

        public LeaveBalanceController(ILeaveBalanceService leaveBalanceService)
        {
            _leaveBalanceService = leaveBalanceService;
        }

        [HttpGet]
       public async Task<IActionResult> GetLeaveBalanceByUserId(Guid userId, Guid leaveTypeId)
        {
            var data = await _leaveBalanceService.GetLeaveBalanceByUserId(userId, leaveTypeId);
            return Ok(data);
        }
    }
}
