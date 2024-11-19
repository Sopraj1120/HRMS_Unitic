using HRMS.DTOs.RequestDtos;
using HRMS.Iservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlevelController : ControllerBase
    {
        private readonly IAlevelService _alevelservice;

        public AlevelController(IAlevelService alevelservice)
        {
            _alevelservice = alevelservice;
        }


        [HttpPost]
        public async Task<IActionResult> AddAlevel(Guid StudentId, ALevelRequestDtos aLevelRequestDtos)
        {
            var data = await _alevelservice.AddAlevels(StudentId, aLevelRequestDtos);
            return Ok(data);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAlevelByStudent(Guid Id)
        {
            var data = await _alevelservice.GetAlevelByStudentId(Id);
            return Ok(data);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAlevel(Guid Id)
        {
            await _alevelservice.DeleteAlevel(Id);
            return NoContent();
        }
    }
}
