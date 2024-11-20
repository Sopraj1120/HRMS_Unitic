using HRMS.DTOs.RequestDtos;
using HRMS.Iservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAddressController : ControllerBase
    {
        private readonly IUserAddressService _userAddressService;

        public UserAddressController(IUserAddressService userAddressService)
        {
            _userAddressService = userAddressService;
        }
        [HttpPost]
        [Route("Add_User_Address")]

        public async Task<IActionResult> AddUserAddress(Guid UserId, UserAddressRequestDtos userAddressRequestDtos)
        {
            var data = await _userAddressService.AddUserAddress(UserId, userAddressRequestDtos);
            return Ok(data);
        }

        [HttpGet("{Id}")]


        public async Task<IActionResult> GetAddressByUserId(Guid Id)
        {
            var data = await _userAddressService.GetUserAddressByUserId(Id);
            return Ok(data);
        }

        [HttpDelete("{Id}")]

        public async Task<IActionResult> DeleteUserAddress(Guid Id)
        {
            await _userAddressService.DeleteUserAddress(Id);
            return Ok();
        }
    }
}
