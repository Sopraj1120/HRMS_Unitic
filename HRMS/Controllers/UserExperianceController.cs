using HRMS.DTOs.RequestDtos;
using HRMS.Iservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserExperianceController : ControllerBase
    {
        private readonly IUserExperianceService _userservice;

        public UserExperianceController(IUserExperianceService userservice)
        {
            _userservice = userservice;
        }

        [HttpPost]
        public async Task<IActionResult> AddExperiance(Guid id, UserExperianceRequestDtos userExperianceRequestDtos)
        {
            var data = await _userservice.AddExperiance(id, userExperianceRequestDtos);
            return Ok(data);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetExperianceBYUserId(Guid Id)
        {
            var data = await _userservice.GetExperianceByUserId(Id);
            return Ok(data);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteExperiance(Guid Id)
        {
            await _userservice.DeleteExperiance(Id);
            return NoContent();
        }
     }
}
