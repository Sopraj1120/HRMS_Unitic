using HRMS.DTOs.RequestDtos;
using HRMS.Iservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOlevelController : ControllerBase
    {
        private readonly IUserOlevelService _userservice;

        public UserOlevelController(IUserOlevelService userservice)
        {
            _userservice = userservice;
        }

        [HttpPost]
        public async Task<IActionResult> AddOlevel(Guid Id, UserOlevelRequestDtos userOlevelRequestDtos)
        {
            var data = await _userservice.AddOlevels(Id, userOlevelRequestDtos);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetOlevelByUserId(Guid Id)
        {
            var data = await _userservice.GetOlevelByUserId(Id);

            return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOlevelS(Guid Id)
        {
            await _userservice.DeleteOlevel(Id);
            return NoContent();
        }
    }
}
