using HRMS.DTOs.RequestDtos;
using HRMS.Iservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserHigherStudiesController : ControllerBase
    {
        private readonly UserHigherStudiesSevice _userexpservice;

        public UserHigherStudiesController(UserHigherStudiesSevice userexpservice)
        {
            _userexpservice = userexpservice;
        }

        [HttpPost]
        public async Task<IActionResult> AddHStudy (Guid Id, UserHigherStudiesRequestdtos userHigherStudies)
        {
            var data = await _userexpservice.AddHStudy(Id, userHigherStudies);
            return Ok(data);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetHStudyByUserId(Guid Id)
        {
            var data = await _userexpservice.GetHStudyByUserId (Id);
            return Ok(data);
        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteHStudy (Guid Id)
        {
           await _userexpservice.DeleteHStudy(Id);
            return NoContent();
        }
    }
}
