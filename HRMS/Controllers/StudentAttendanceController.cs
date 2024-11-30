using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Entities;
using HRMS.Iservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAttendanceController : ControllerBase
    {
        private readonly IStudentAttendanceService  _studentAttendanceService;


        public StudentAttendanceController(IStudentAttendanceService studentAttendanceService)
        {
            _studentAttendanceService = studentAttendanceService;
        }

        [HttpPost("Add_Student_Attendance")]
        public async Task<IActionResult> AddStudentAttendance(Guid StudenId, StudentAttendanceRequestDtos studentAttendanceRequestDtos)
        {
            var data = await _studentAttendanceService.AddStudentAttendance(StudenId, studentAttendanceRequestDtos);
            return Ok(data);
        }

        [HttpGet("Get_Student_Attendance")]
        public async Task<IActionResult> GetStudentAttendanceByStuId(Guid stuID)
        {
            var data = await _studentAttendanceService.GetStudentAttendanceByStuId(stuID);
            return Ok(data);
        }

        [HttpGet("Get_Att_Report")]
        public async Task<IActionResult> GenerateAttendanceReport(DateTime startDate, DateTime endDate)
        {
            var data = await _studentAttendanceService.GenerateAttendanceReport(startDate, endDate);
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStuAttendance(Guid studentId, DateTime date, StudentAttendanceRequestDtos studentAttendanceRequestDtos)
        {
            var data = await _studentAttendanceService.UpdateStuAttendance(studentId,date, studentAttendanceRequestDtos);
            return Ok(data);
        }
    }

}
