using HRMS.DTOs.RequestDtos;
using HRMS.Iservice;
using HRMS.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        [HttpPost]
        [Route("AddUser")]

        public async Task<IActionResult> AddUser(UserRequestDtos userRequestDtos)
        {
            var data = await _userServices.AddUser(userRequestDtos);
            return Ok(data);
        }

        [HttpGet]
        [Route("GetAllUser")]
        public async Task<IActionResult> GetAllUser()
        {
            var data = await _userServices.GetAllUsers();
            return Ok(data);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetUserById(Guid Id)
        {
            var data = await _userServices.GetUserById(Id);
            return Ok(data);
        }

        [HttpPut]
        [Route("Update_User/{Id}")]
        public async Task<IActionResult> UpdateUser(Guid Id, UserRequestDtos userRequestDtos)
        {
            try
            {
                // Call the service to update the user
                var updatedUser = await _userServices.UpadteUser(Id, userRequestDtos);

                // Return the updated user data
                return Ok(updatedUser);
            }
            catch (KeyNotFoundException ex)
            {
                // If the user is not found, return a 404 Not Found response
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                // Handle any other errors and return a 500 Internal Server Error
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> deleteuser(Guid Id)
        {
            await _userServices.DeleteUser(Id);
            return NoContent();
        }

    }
}
