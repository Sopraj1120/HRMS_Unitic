using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
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
        private readonly IUserAddressService _userAddressService;
        private readonly IUserOlevelService _userOlevelService;
        private readonly IUserAlevelService _userAlevelService;
        private readonly IUserHigherStudiesSevice _userHigherStudiesSevice;
        private readonly IUserExperianceService _userExperianceService;

        public UserController(IUserServices userServices, IUserAddressService userAddressService, IUserOlevelService userOlevelService,
            IUserAlevelService userAlevelService, IUserHigherStudiesSevice userHigherStudiesSevice, IUserExperianceService userExperianceService)
        {
            _userServices = userServices;
            _userAddressService = userAddressService;
            _userOlevelService = userOlevelService;
            _userAlevelService = userAlevelService;
            _userHigherStudiesSevice = userHigherStudiesSevice;
            _userExperianceService = userExperianceService;
        }
      

        [HttpPost("Add-Admin")]
        public async Task<IActionResult> AddAdmin(UserRequestDtos userRequestDtos)
        {
            var data = await _userServices.AddAdmin(userRequestDtos);
            return Ok(data);
        }
        [HttpPost("Add-Staff")]
        public async Task<IActionResult> AddStaff(UserRequestDtos userRequestDtos)
        {
            var data = await _userServices.AddStaff(userRequestDtos);
            return Ok(data);
        }
        [HttpPost("Add-Employee")]
        public async Task<IActionResult> AddEmployee(UserRequestDtos userRequestDtos)
        {
            var data = await _userServices.AddEmployee(userRequestDtos);
            return Ok(data);
        }
        [HttpPost("Add- Lecturers")]
        public async Task<IActionResult> AddLecturers(UserRequestDtos userRequestDtos)
        {
            var data = await _userServices.AddLecturer(userRequestDtos);
            return Ok(data);
        }
        [HttpGet]
        [Route("Get_All_User")]
        public async Task<IActionResult> GetAllUser()
        {
            var data = await _userServices.GetAllUser();
            return Ok(data);
        }
        [HttpGet]
        [Route("Get_Admin_User")]
        public async Task<IActionResult> GetAdminUser()
        {
            var data = await _userServices.GetAdminUser();
            return Ok(data);
        }
        [HttpGet]
        [Route("Get_Staff_User")]
        public async Task<IActionResult> GetStaffUser()
        {
            var data = await _userServices.GetStaffUser();
            return Ok(data);
        }
        [HttpGet]
        [Route("Get_Employee_User")]
        public async Task<IActionResult> GetEmployeeUser()
        {
            var data = await _userServices.GeteEmployeeUser();
            return Ok(data);
        }
        [HttpGet]
        [Route("Get_Lecturer_User")]
        public async Task<IActionResult> GetLecturesUser()
        {
            var data = await _userServices.GetLecturesUsers();
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
              
                var updatedUser = await _userServices.UpadteUser(Id, userRequestDtos);

                
                return Ok(updatedUser);
            }
            catch (KeyNotFoundException ex)
            {
            
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
              
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> deleteuser(Guid Id)
        {
            await _userServices.DeleteUser(Id);
            return NoContent();
        }

        // user Address ____________________________________________________________________________________________________________________________________________________________________________________
        [HttpPost]
        [Route("Add_User_Address")]

        public async Task<IActionResult> AddUserAddress(Guid UserId, UserAddressRequestDtos userAddressRequestDtos)
        {
            var data = await _userAddressService.AddUserAddress(UserId, userAddressRequestDtos);
            return Ok(data);
        }

        [HttpGet("Get_User_Address")]


        public async Task<IActionResult> GetAddressByUserId(Guid Id)
        {
            var data = await _userAddressService.GetUserAddressByUserId(Id);
            return Ok(data);
        }

        [HttpDelete("Delete_User_Address")]

        public async Task<IActionResult> DeleteUserAddress(Guid Id)
        {
            await _userAddressService.DeleteUserAddress(Id);
            return Ok();
        }

        // User Olevel ____________________________________________________________________________________________________________________________________________________________________________________________
        [HttpPost("Add_User_Olevel")]
        public async Task<IActionResult> AddOlevel(Guid Id, UserOlevelRequestDtos userOlevelRequestDtos)
        {
            var data = await _userOlevelService.AddOlevels(Id, userOlevelRequestDtos);
            return Ok(data);
        }

        [HttpGet("Get_User_Olevel")]
        public async Task<IActionResult> GetOlevelByUserId(Guid Id)
        {
            var data = await _userOlevelService.GetOlevelByUserId(Id);

            return Ok(data);
        }

        [HttpDelete("Delete_User_Olevel")]
        public async Task<IActionResult> DeleteOlevelS(Guid Id)
        {
            await _userOlevelService.DeleteOlevel(Id);
            return NoContent();
        }

        //User Alevel _____________________________________________________________________________________________________________________________________________________________________________________________

        [HttpPost("Add_User_Alevel")]
        public async Task<IActionResult> AddAlevel(Guid Id, UserAlevelRequestDtos userAlevelRequestDtos)
        {
            var data = await _userAlevelService.AddAlevel(Id, userAlevelRequestDtos);
            return Ok(data);
        }

        [HttpGet("Get_User_Alevel")]
        public async Task<IActionResult> GetAlevelByUserId(Guid Id)
        {
            var data = await _userAlevelService.GetAlByUserId(Id);
            return Ok(data);
        }

        [HttpDelete("Delete_User_Alevel")]
        public async Task<IActionResult> DeleteAlevels(Guid Id)
        {
            await _userAlevelService.DeleteAls(Id);
            return NoContent();
        }

        // User HigherStudies ____________________________________________________________________________________________________________________________________________________________________________________

        [HttpPost("Add_User_HigherStudies")]
        public async Task<IActionResult> AddHStudy(Guid Id, UserHigherStudiesRequestdtos userHigherStudies)
        {
            var data = await _userHigherStudiesSevice.AddHStudy(Id, userHigherStudies);
            return Ok(data);
        }

        [HttpGet("Get_User_HigherStudies")]
        public async Task<IActionResult> GetHStudyByUserId(Guid Id)
        {
            var data = await _userHigherStudiesSevice.GetHStudyByUserId(Id);
            return Ok(data);
        }


        [HttpDelete("Delete_User_HigherStudies")]
        public async Task<IActionResult> DeleteHStudy(Guid Id)
        {
            await _userHigherStudiesSevice.DeleteHStudy(Id);
            return NoContent();
        }

        // User Experiance ___________________________________________________________________________________________________________________________________________________________________________________
        [HttpPost("Add_User_Experiance")]
        public async Task<IActionResult> AddExperiance(Guid id, UserExperianceRequestDtos userExperianceRequestDtos)
        {
            var data = await _userExperianceService.AddExperiance(id, userExperianceRequestDtos);
            return Ok(data);
        }

        [HttpGet("Get_User_Experiance")]
        public async Task<IActionResult> GetExperianceBYUserId(Guid Id)
        {
            var data = await _userExperianceService.GetExperianceByUserId(Id);
            return Ok(data);
        }

        [HttpDelete("Delete_user_Experiance")]
        public async Task<IActionResult> DeleteExperiance(Guid Id)
        {
            await _userExperianceService.DeleteExperiance(Id);
            return NoContent();
        }
    }
}

