using HRMS.DTOs;
using HRMS.DTOs.RequestDtos;
using HRMS.Entities;
using HRMS.IRepository;
using HRMS.Iservice;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HRMS.Service
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IUserLoginRepository _userLogin;
        private readonly IConfiguration _configuration;

        public UserLoginService(IUserLoginRepository userLogin, IConfiguration configuration)
        {
            _userLogin = userLogin;
            _configuration = configuration;
        }

        public async Task<TokenModal> LoginUser(UserLoginDTo userLoginDTo)
        {
            var user = await _userLogin.LoginUser(userLoginDTo.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(userLoginDTo.Password, user.PassWord)) 
                {
                    return null;
                }

            return CreateToken(user);
            }

        private TokenModal CreateToken(Users user)
        {
            var claimList = new List<Claim>();
            claimList.Add(new Claim("Id",user.Id.ToString()));
            claimList.Add(new Claim("UserName",user.FirstName));
            claimList.Add(new Claim("Email",user.Email));
            claimList.Add(new Claim("Role", user.Role.ToString()));
            claimList.Add(new Claim("Image", user.Image.ToString()));

            var key = _configuration["Jwt:Key"];
            var secKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));

            var crediatial = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
              issuer: _configuration["Jwt:Issuer"],
              audience: _configuration["Jwt:Audience"],
            claims: claimList,
           
              expires: DateTime.UtcNow.AddDays(1),
              signingCredentials: crediatial);

            var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);

            var res = new TokenModal();

            res.Token = tokenStr;

            return res;
        }
    }
}
