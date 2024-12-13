using HRMS.DataBase;
using HRMS.DTOs;
using HRMS.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public static SuperAdminRegister superAdminRegister = new SuperAdminRegister();

        public AuthController(IConfiguration configuration)
        {
          _configuration = configuration;
        }

        [HttpPost("SuperAdminRegister")]

        public ActionResult<SuperAdminRegister> Register(SuperADto request)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            superAdminRegister.Username = request.Username;
            superAdminRegister.Image = request.Image;
            superAdminRegister.Email = request.Email;
            superAdminRegister.Password = passwordHash;

            return Ok(superAdminRegister);
        }

        [HttpPost("SuperAdminLogin")]

        public ActionResult<SuperAdminRegister> Login(SuperADto request)
        {
            if (superAdminRegister.Username != request.Username) 
            {
                return BadRequest("SuperAdmin Not Found.");
            }
            if (!BCrypt.Net.BCrypt.Verify(request.Password, superAdminRegister.Password))
            {
                return BadRequest("Wrong Password.");
            }
            string token = CreateToken(superAdminRegister);
                return Ok(token);
        }

        private string CreateToken(SuperAdminRegister superAdminRegister)
        {
            List<Claim> claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, superAdminRegister.Username,superAdminRegister.Image,
                  superAdminRegister.Email,superAdminRegister.Password)
    };

            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                        _configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                 claims: claims,
                 expires: DateTime.Now.AddDays(1),
                 signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }




    }
}
