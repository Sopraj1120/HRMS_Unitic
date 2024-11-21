using HRMS.DTOs.RequestDtos;
using HRMS.Iservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAlevelController : ControllerBase
    {
        private readonly IUserAlevelService _userAlevel;

        public UserAlevelController(IUserAlevelService userAlevel)
        {
            _userAlevel = userAlevel;
        }


        [HttpPost]
        public async Task<IActionResult> AddAlevel(Guid Id, UserAlevelRequestDtos userAlevelRequestDtos)
        {
            var data = await _userAlevel.AddAlevel(Id, userAlevelRequestDtos);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAlevelByUserId(Guid Id)
        {
            var data = await _userAlevel.GetAlByUserId(Id);
            return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAlevels(Guid Id)
        {
            await _userAlevel.DeleteAls(Id);
            return NoContent();
        }
    }
}
