using HRMS.Entities;

namespace HRMS.IRepository
{
    public interface IUserLoginRepository
    {
        Task<Users> LoginUser(string Email);
    }
}
