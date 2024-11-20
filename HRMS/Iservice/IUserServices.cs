using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;

namespace HRMS.Iservice
{
    public interface IUserServices 
    {
        Task DeleteUser(Guid Id);
        Task<UserResponseDtos> UpadteUser(Guid Id, UserRequestDtos userRequestDtos);
        Task<UserResponseDtos> GetUserById(Guid Id);
        Task<List<UserResponseDtos>> GetAllUsers();
        Task<UserResponseDtos> AddUser(UserRequestDtos userRequestDtos);
    }
}
