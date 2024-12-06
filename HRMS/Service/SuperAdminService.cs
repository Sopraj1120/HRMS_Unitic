using HRMS.DTOs;
using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Entities;
using HRMS.IRepository;
using HRMS.Iservice;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HRMS.Service
{
    public class SuperAdminService : ISuperAdminService
    {
        private readonly ISuperAdminRepo _superAdmin;
        private readonly IConfiguration _configuration;

        public SuperAdminService(ISuperAdminRepo superAdmin, IConfiguration configuration)
        {
            _superAdmin = superAdmin;
            _configuration = configuration;
        }

        public async Task<SuperAdminResponceDto> RegisterSuperAdmin (SuperAdminRequestDto admin)
        {
            var superAdmin = new SuperAdmin
            {
                Id = Guid.NewGuid(),
                Name = admin.Name,
                Email = admin.Email,
                Image = admin.Image,
                Password = BCrypt.Net.BCrypt.HashPassword(admin.Password),

            };

            var data = await _superAdmin.RegisterSuperAdmin(superAdmin);

            var Responce = new SuperAdminResponceDto
            {
                Id = data.Id,
                Name = data.Name,
                Email = data.Email,
                Image = data.Image,
                Password = data.Password,
            };
            return Responce;
        }

        public async Task<TokenModal> LoginSuperAdmin(UserLoginDTo admin)
        {
            var supadmin = await _superAdmin.LoginSuperAdmin(admin.Email);
            if(supadmin == null || !BCrypt.Net.BCrypt.Verify(admin.Password, supadmin.Password))
            {
                return null;
            }

            return CreateToken(supadmin);
        }





        private TokenModal CreateToken(SuperAdmin superAdmin)
        {
            var claimList = new List<Claim>();
            claimList.Add(new Claim("Id", superAdmin.Id.ToString()));
            claimList.Add(new Claim("name",superAdmin.Name.ToString()));
            claimList.Add(new Claim("Email", superAdmin.Email.ToString()));


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
