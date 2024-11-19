using HRMS.DTOs.RequestDtos;
using HRMS.Iservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperianceController : ControllerBase
    {
        private readonly IExperianceService _experianceservice;

        public ExperianceController(IExperianceService experianceservice)
        {
            _experianceservice = experianceservice;
        }


        [HttpPost]
        public async Task<IActionResult> AddExperiance(Guid studentId, ExperianceRequestDtos experianceRequest)
        {
            var data = await _experianceservice.AddExperiance(studentId, experianceRequest);
            return Ok(data);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetExperianceByStudentId(Guid Id)
        {
            var data = await _experianceservice.GetExperianceByStudentId(Id);
            return Ok(data);
        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteExperiance(Guid Id)
        {
            await _experianceservice.DeleteExperiance(Id);
            return NoContent();
        }
    }
}
