using HRMS.DTOs.RequestDtos;
using HRMS.Iservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HStudyController : ControllerBase
    {
        private readonly IHStudeyService _hstudyservice;

        public HStudyController(IHStudeyService hstudyservice)
        {
            _hstudyservice = hstudyservice;
        }

        [HttpPost]
        public async Task<IActionResult> AddHStudy(Guid studentId, HStudiesRequestDtos hStudiesRequestDtos)
        {
            var data = await _hstudyservice.AddHStudy(studentId, hStudiesRequestDtos);
            return Ok(data);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetHStudyByStudentId(Guid Id)
        {
            var data = await _hstudyservice.GetHStudyByStudentId(Id);
            return Ok(data);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteHStudy(Guid Id)
        {
            await _hstudyservice.DeleteHStudy(Id);
            return NoContent();
        }
    }
}
