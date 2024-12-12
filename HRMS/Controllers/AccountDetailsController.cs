using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Iservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Runtime.CompilerServices;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountDetailsController : ControllerBase
    {
        private readonly IAccountDetailService _accountDetailService;

        public AccountDetailsController(IAccountDetailService accountDetailService)
        {
            _accountDetailService = accountDetailService;
        }


        [HttpPost("Add_Account")]
        public async Task<IActionResult> AddAccount (Guid UserId, AccountDetailsRequestDtos accountDetailsRequestDtos)
        {
            var data = await _accountDetailService.AddAccount(UserId, accountDetailsRequestDtos);
            return Ok(data);
        }

        [HttpGet("get_all_acc_details")]
        public async Task<IActionResult> GetAllAccountDetails()
        {
            var data = await _accountDetailService.GetAllAccountDetails();
            return Ok(data);
        }

        [HttpGet("Get_Account_By_userId")]
        public async Task<IActionResult> GetAccountByUserId(Guid userId)
        {
            var  data = await _accountDetailService.GetAccountByUserId(userId);
            return Ok(data);
        }

        [HttpGet("Get_Account_By-Id")]
        public async Task<IActionResult> GetAccountById(Guid id)
        {
            var data = await _accountDetailService.GetAccountById(id);
            return Ok(data);
        }

        [HttpPut("Update_Accound")]
        public async Task<IActionResult> UpdateAccountDetailsByUserId(Guid UserId, AccountDetailsRequestDtos accountDetailsRequestDtos)
        {
            var data = await _accountDetailService.UpdateAccountDetailsByUserId(UserId, accountDetailsRequestDtos);
            return Ok(data);
        }
        [HttpDelete("Delete_AccountDetails")]
        public async Task<IActionResult> DeleteAccount(Guid id)
        {
            await _accountDetailService.DeleteAccountById(id);
            return Ok("Account deleted successfully.");
        }



    }
}
