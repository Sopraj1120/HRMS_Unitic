using HRMS.DataBase;
using HRMS.Entities;
using HRMS.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Repository
{
    public class UserRepository : IUserRepo
    {
        private readonly HRMDBContext _context;

        public UserRepository(HRMDBContext context)
        {
            _context = context;
        }

        public async Task<Users> AddUser(Users users)
        {
            var data = await _context.users.AddAsync(users);
            await _context.SaveChangesAsync();
            return users;
        }

        public async Task<List<Users>> GetAllUsers()
        {
            var data = await _context.users.Where(a => !a.IsDeleted).Include(a => a.userAddresses).ToListAsync();
            return data;
        }

        public async Task<Users> GetUserById(Guid Id)
        {
            var data = await _context.users.Include(A =>A.userAddresses).FirstOrDefaultAsync(x =>x.Id == Id && !x.IsDeleted);
            return data;
        }

        public async Task<Users> UpdateUser(Users user)
        {
        
            var existingUser = await GetUserById(user.Id);

          
            if (existingUser == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

          
            existingUser.UsersId = user.UsersId;
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Nic = user.Nic;
            existingUser.Email = user.Email;
            existingUser.MerritalStatus = user.MerritalStatus;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.DateOfBirth = user.DateOfBirth;

       
            await _context.SaveChangesAsync();

            return existingUser; 
        }



        public async Task DeleteUser (Guid Id)
        {
            var data = await GetUserById(Id);

            if (data != null)
            {
                data.IsDeleted = true;
                _context.users.Update(data);
                await _context.SaveChangesAsync();
            }

        }
    }
}
