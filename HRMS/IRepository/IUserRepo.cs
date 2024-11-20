using HRMS.Entities;

namespace HRMS.IRepository
{
    public interface IUserRepo
    {
        Task<Users> AddUser(Users users);
        Task<List<Users>> GetAllUsers();
        Task<Users> GetUserById(Guid Id);
        Task<Users> UpdateUser(Users users);
        Task DeleteUser(Guid Id);
    }
}
