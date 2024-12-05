using HRMS.DataBase;
using HRMS.DTOs.RequestDtos;
using HRMS.Entities;
using HRMS.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Repository
{
    public class UserloginRepo : IUserLoginRepository
    {
        private readonly HRMDBContext _context;

        public UserloginRepo(HRMDBContext context)
        {
            _context = context;
        }

        public async Task<Users> LoginUser(string Email)
        {
            var data = await _context.users.FirstOrDefaultAsync(x => x.Email == Email);
            if (data == null)
            {
                throw new Exception("User Not Found!");
            }
            return data;
        }
    }
}
