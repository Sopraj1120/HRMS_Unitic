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
        private readonly IUserExperianceSevice _userexpservice;

        public UserExperianceController(IUserExperianceSevice userexpservice)
        {
            _userexpservice = userexpservice;
        }

        [HttpPost]
        public async Task<IActionResult> AddExperiance (Guid Id, UserExperianceRequestdtos userExperianceRequestdtos)
        {
            var data = await _userexpservice.AddExperiance(Id, userExperianceRequestdtos);
            return Ok(data);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetExperianceByUserId(Guid Id)
        {
            var data = await _userexpservice.GetexperianceByUserId (Id);
            return Ok(data);
        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteExperiance (Guid Id)
        {
           await _userexpservice.DeleteExperiance(Id);
            return NoContent();
        }
    }
}
