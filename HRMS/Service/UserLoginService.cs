using HRMS.DTOs;
using HRMS.DTOs.RequestDtos;
using HRMS.IRepository;
using HRMS.Iservice;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
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

            return CreateToken();
            }

        private TokenModal CreateToken()
        {
            var key = _configuration["Jwt:Key"];
            var secKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));

            var crediatial = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
              issuer: _configuration["Jwt:Issuer"],
              audience: _configuration["Jwt:Audience"],
              expires: DateTime.UtcNow.AddDays(1),
              signingCredentials: crediatial);

            var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);

            var res = new TokenModal();

            res.Token = tokenStr;

            return res;
        }
    }
}
