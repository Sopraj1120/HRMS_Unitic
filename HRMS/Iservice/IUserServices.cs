using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;

namespace HRMS.Iservice
{
    public interface IUserServices 
    {
        Task DeleteUser(Guid Id);
        Task<UserResponseDtos> UpadteUser(Guid Id, UserRequestDtos userRequestDtos);
        Task<UserResponseDtos> GetUserById(Guid Id);
        Task<List<UserResponseDtos>> GetAllUser();
        Task<List<UserResponseDtos>> GetAdminUser();
        Task<List<UserResponseDtos>> GetStaffUser();
        Task<List<UserResponseDtos>> GeteEmployeeUser();
        Task<List<UserResponseDtos>> GetLecturesUsers();
        Task<UserResponseDtos> AddAdmin(UserRequestDtos userRequestDtos);
        Task<UserResponseDtos> AddStaff(UserRequestDtos userRequestDtos);
        Task<UserResponseDtos> AddEmployee(UserRequestDtos userRequestDtos);
        Task<UserResponseDtos> AddLecturer(UserRequestDtos userRequestDtos);
    }
}
