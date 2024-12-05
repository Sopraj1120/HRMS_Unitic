using HRMS.DTOs.RequestDtos;
using HRMS.Iservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userLogInController : ControllerBase
    {
        private readonly IUserLoginService _userLoginService;

        public userLogInController(IUserLoginService userLoginService)
        {
            _userLoginService = userLoginService;
        }

        [HttpPost("LogIn_User")]
        public async Task<IActionResult> userLogin(UserLoginDTo userLoginDTo)
        {
            var data = await _userLoginService.LoginUser(userLoginDTo);
            return Ok(data);
        }
    }
}
