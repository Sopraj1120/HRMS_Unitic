using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Iservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAttendanceController : ControllerBase
    {
        private readonly IUserAttendanceService _userAttendanceService;

        public UserAttendanceController(IUserAttendanceService userAttendanceService)
        {
            _userAttendanceService = userAttendanceService;
        }

        [HttpPost("Add_User_Attendance")]
        public async Task<IActionResult> AddAttendanceForUser(Guid UserId, UserAttendanceRequestDtos userAttendanceRequestDtos)
        {
            var data = await _userAttendanceService.AddAttendanceForUser(UserId, userAttendanceRequestDtos).ConfigureAwait(false);
            return Ok(data);
        }

        [HttpGet("Get_User_Attendance")]
        public async Task<IActionResult> GetUserAttendanceByUserIdAndDate(Guid userId, DateTime date)
        {
            var data = await _userAttendanceService.GetUserAttendanceByUserIdAndDate(userId, date).ConfigureAwait(false);
            return Ok(data);
        }

        [HttpGet("Genarete_Report")]
        public async Task<IActionResult> GenerateUserAttendanceReportByUser(Guid userId, DateTime startDate, DateTime endDate)
        {
            var data = await _userAttendanceService.GenerateUserAttendanceReportByUser(userId, startDate, endDate).ConfigureAwait(false);
            return Ok(data);
        }

        [HttpGet("Get_All_User_Attendance")]
        public async Task<IActionResult> GetAllAttendanceByDate(DateTime date)
        {
            var data = await _userAttendanceService.GetAllAttendanceByDate(date).ConfigureAwait(false);
            return Ok(data);
        }

        [HttpPut("Update_User_Attendance")]
        public async Task<IActionResult> UpdateUserAttendance(Guid UserId, DateTime date, UserAttendanceRequestDtos userAttendanceRequestDtos)
        {
            var data = await _userAttendanceService.UpdateUserAttendance(UserId,date,userAttendanceRequestDtos).ConfigureAwait (false);
            return Ok(data);
        }
    }
}
