using HRMS.Entities;

namespace HRMS.IRepository
{
    public interface IUserRepo
    {
        Task<Users> AddAdmin(Users users);
        Task<Users> AddStaff(Users users);
        Task<Users> AddEmployee(Users users);
        Task<Users> AddLecturer(Users users);
        Task<List<Users>> GetAllUsers();
        Task<List<Users>> GetAdminUsers();
        Task<List<Users>> GetStaffUsers();
        Task<List<Users>> GetEmployeeUsers();
        Task<List<Users>> GetLecturersUsers();
        Task<Users> GetUserById(Guid Id);
        Task<Users> UpdateUser(Users users);
        Task DeleteUser(Guid Id);
    }
}
