using HRMS.DTOs.RequestDtos;
using HRMS.Entities;
using HRMS.Iservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingDaysController : ControllerBase
    {
        readonly IWorkingDaysService _workingDaysService;

        public WorkingDaysController(IWorkingDaysService workingDaysService)
        {
            _workingDaysService = workingDaysService;
        }

        [HttpPost("Add_workingDays")]

        public async Task<IActionResult> AddWorkingDays(Guid UserId, WorkingDaysRequestDtos requestDtos)
        {
            var data = await _workingDaysService.AddWorkingDays(UserId, requestDtos);
            return Ok(data);
        }
        [HttpGet("Get_All_workingDays")]
        public async Task<IActionResult> GetAllWorkingDays()
        {
            var data = await _workingDaysService.GetAllWorkingDays();
            return Ok(data);
        }

        [HttpGet("Get_WorkingDays_By_ UserId")]
        public async Task<IActionResult>  GetWorkingDaysByUserId(Guid UserId)
        {
            var data = await _workingDaysService.GetWorkingDaysByUserId(UserId);
            return Ok(data);
        }

        [HttpPut("Update_wokingDays")]
        public async Task<IActionResult> UpdateWorkingdays(Guid userId, WorkingDaysRequestDtos workingDaysRequest)
        {
            var data = await _workingDaysService.UpdateWorkingDays(userId, workingDaysRequest);
            return Ok(data);
        }


        [HttpDelete("Delete_WorkingDays")]
        public async Task<IActionResult>  deleteWorkingDays(Guid Id)
        {
            await _workingDaysService.DeleteWorkingDays(Id);
            return NoContent();
        }

    }
}
