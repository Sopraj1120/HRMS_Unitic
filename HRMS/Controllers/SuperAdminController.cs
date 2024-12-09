using HRMS.DTOs.RequestDtos;
using HRMS.Iservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperAdminController : ControllerBase
    {
        private readonly ISuperAdminService _superAdminService;

        public SuperAdminController(ISuperAdminService superAdminService)
        {
            _superAdminService = superAdminService;
        }

        [HttpPost("Add_Super_Admin")]
        public async Task<IActionResult> RegisterSuperAdmin (SuperAdminRequestDto admin)
        {
            var data = await _superAdminService.RegisterSuperAdmin (admin);
            return Ok(data);
        }

        [HttpPost("LogIn_Sup_Admin")]
        public async Task<IActionResult> loginSuperAdmin (UserLoginDTo admin)
        {
            var data = await _superAdminService.LoginSuperAdmin (admin);
            return Ok(data);
        }
    }
}
