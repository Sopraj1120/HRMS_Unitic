using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Iservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private readonly ISalaryService _service;

        public SalaryController(ISalaryService service)
        {
            _service = service;
        }

        [HttpPost("Add_Salary")]
        public async Task<IActionResult> AddSalary(Guid UserId, SalaryRequestDtos salaryRequestDtos)
        {
            var data = await _service.AddSalary(UserId, salaryRequestDtos);
            return Ok(data);
        }

        [HttpGet("Count")]

        public async Task<IActionResult> GetWorkingDaysForMonth(Guid userId, int year, int month)
        {
            var data = await _service.GetWorkingDaysForMonth(userId, year, month);
            return Ok(data);
        }

        [HttpGet("All_Salaries")]
        public async Task<IActionResult> GetAllsalaries()
        {
            var data = await _service.GetAllsalaries();
            return Ok(data);
        }


        [HttpGet("Get_Salary_By_Id")]
        public async Task<IActionResult> GetSalaryById(Guid Id)
        {
            var data = await _service.GetSalaryById(Id);
            return Ok(data);
        }
        [HttpGet("Get_salary_By_UserId")]
        public async Task<IActionResult> GetSalaryByUserId(Guid UserId)
        {
            var data = await _service.GetSalaryByUserId(UserId);
            return Ok(data);
        }
        [HttpPut("Update_salary")]
        public async Task<IActionResult> UpdateSalary(Guid userId, SalaryRequestDtos salaryRequestDtos)
        {
            var data  = await _service.UpdateSalary(userId, salaryRequestDtos);
            return Ok(data);
        }
    }
}
