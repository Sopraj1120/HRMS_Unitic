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

      

        public async Task<Users> AddAdmin(Users users)
        {
            users.Role = Role.Admin;
            var data = await _context.users.AddAsync(users);
            await _context.SaveChangesAsync();
            return users;
        }
        public async Task<Users> AddStaff(Users users)
        {
            users.Role = Role.Staff;
            var data = await _context.users.AddAsync(users);
            await _context.SaveChangesAsync();
            return users;
        } 
        public async Task<Users> AddEmployee(Users users)
        {
            users.Role = Role.Employee;
            var data = await _context.users.AddAsync(users);
            await _context.SaveChangesAsync();
            return users;
        }

        public async Task<Users> AddLecturer(Users users)
        {
            users.Role = Role.Lecturers;
            var data = await _context.users.AddAsync(users);
            await _context.SaveChangesAsync();
            return users;
        }
        public async Task<List<Users>> GetAllUsers()
        {
            var data = await _context.users.Where(a => !a.IsDeleted).Include(a => a.userAddresses).Include(o => o.userOLevels).Include(a => a.userALevels).Include(e => e.userExperiances).Include(e => e.userHigherStudies).ToListAsync();
            return data;
        }
        public async Task<List<Users>> GetAdminUsers()
        {
            var data = await _context.users.Where(a =>a.Role == Role.Admin && !a.IsDeleted).Include(a => a.userAddresses).Include(o =>o.userOLevels).Include(a => a.userALevels).Include(e => e.userExperiances).Include(e => e.userHigherStudies).ToListAsync();
            return data;
        }
        public async Task<List<Users>> GetStaffUsers()
        {
            var data = await _context.users.Where(a => a.Role == Role.Staff && !a.IsDeleted).Include(a => a.userAddresses).Include(o => o.userOLevels).Include(a => a.userALevels).Include(e => e.userExperiances).Include(e => e.userHigherStudies).ToListAsync();
            return data;
        }
        public async Task<List<Users>> GetEmployeeUsers()
        {
            var data = await _context.users.Where(a => a.Role == Role.Employee && !a.IsDeleted).Include(a => a.userAddresses).Include(o => o.userOLevels).Include(a => a.userALevels).Include(e => e.userExperiances).Include(e => e.userHigherStudies).ToListAsync();
            return data;
        }
        public async Task<List<Users>> GetLecturersUsers()
        {
            var data = await _context.users.Where(a => a.Role == Role.Lecturers && !a.IsDeleted).Include(a => a.userAddresses).Include(o => o.userOLevels).Include(a => a.userALevels).Include(e => e.userExperiances).Include(e => e.userHigherStudies).ToListAsync();
            return data;
        }
        public async Task<Users> GetUserById(Guid Id)
        {
            var data = await _context.users.Include(A =>A.userAddresses).Include(o => o.userOLevels).Include(a => a.userALevels).Include(e => e.userExperiances).Include(e => e.userHigherStudies).FirstOrDefaultAsync(x =>x.Id == Id && !x.IsDeleted);
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
