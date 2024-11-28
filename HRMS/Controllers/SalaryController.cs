using HRMS.DTOs.RequestDtos;
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

        [HttpPost]
        public async Task<IActionResult> AddSalary(Guid UserId, SalaryRequestDtos salaryRequestDtos)
        {
            var data = await _service.AddSalary(UserId, salaryRequestDtos);
            return Ok(data);
        }
    }
}
