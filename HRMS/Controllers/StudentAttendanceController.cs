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
        public async Task<IActionResult> GetStudentAttendanceByStuIdAndDate(Guid stuID, DateTime date)
        {
            var data = await _studentAttendanceService.GetStudentAttendanceByStuIdAndDate(stuID, date);
            return Ok(data);
        }

        [HttpGet("Get_AttEndance_Report")]
        public async Task<IActionResult> GenerateAttendanceReport(Guid StuId, DateTime startDate, DateTime endDate)
        {
            var data = await _studentAttendanceService.GenerateAttendanceReport(StuId,startDate, endDate);
            return Ok(data);
        }

        [HttpGet("Get_All_Attendance")]
        public async Task<IActionResult> GetAllAttendanceByDate()
        {
            var data = await _studentAttendanceService.GetAllAttendanceByDate();
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
