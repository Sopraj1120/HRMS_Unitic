using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Entities;
using HRMS.IRepository;
using HRMS.Iservice;

namespace HRMS.Service
{
    public class UserService : IUserServices
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<UserResponseDtos> AddUser(UserRequestDtos userRequestDtos)
        {
            var user = new Users
            {
                Id = Guid.NewGuid(),
                UsersId = userRequestDtos.UsersId,
                FirstName = userRequestDtos.FirstName,
                LastName = userRequestDtos.LastName,
                Nic = userRequestDtos.Nic,
                Email = userRequestDtos.Email,
                MerritalStatus = userRequestDtos.MerritalStatus,
                PhoneNumber = userRequestDtos.PhoneNumber,
                DateOfBirth = userRequestDtos.DateOfBirth,
            };

            var data = await _userRepo.AddUser(user);

            var resuser = new UserResponseDtos
            {
                Id = data.Id,
                UsersId = data.UsersId,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Nic = data.Nic,
                Email = data.Email,
                MerritalStatus = data.MerritalStatus,
                PhoneNumber = data.PhoneNumber,
                DateOfBirth = data.DateOfBirth,
                IsDeleted = data.IsDeleted
            };
            return resuser;
        }

        public async Task<List<UserResponseDtos>> GetAllUsers()
        {
            var data = await _userRepo.GetAllUsers();

            var resUser = data.Select(a => new UserResponseDtos
            {
                Id = a.Id,
                UsersId = a.UsersId,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Nic = a.Nic,
                Email = a.Email,
                MerritalStatus = a.MerritalStatus,
                PhoneNumber = a.PhoneNumber,
                DateOfBirth = a.DateOfBirth,
                IsDeleted = a.IsDeleted,
                Useraddress = a.userAddresses?.Select(s => new UserAddressResponceDtos
                {
                    Id = s.Id,
                    HouseNumber = s.HouseNumber,
                    Street = s.Street,
                    City = s.City,
                    State = s.State,
                    PostalCode = s.PostalCode,
                    Country = s.Country
                }).ToList(),
                UserExperiances = a.userExperiances?.Select(e => new UserExperianceResponceDtos
                {
                    Id = e.Id,
                    CompanyName = e.CompanyName,
                    Position = e.Position,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    Description = e.Description
                }).ToList(),
                UserHStudy = a.userHigherStudies?.Select(e => new UserHigherStudiesResponseDtos
                {
                    Id = e.Id,
                    Type = e.Type,
                    Stream = e.Stream,
                    Year = e.Year,
                    Duration = e.Duration,
                    Description = e.Description,
                    Institute = e.Institute,
                    Grade = e.Grade
                }).ToList(),


            }).ToList();
            return resUser;

        }

        public async Task<UserResponseDtos> GetUserById(Guid Id)
        {
            var data =await _userRepo.GetUserById(Id);

            if(data == null) return null;

            var reqUser = new UserResponseDtos
            {
                Id = data.Id,
                UsersId = data.UsersId,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Nic = data.Nic,
                Email = data.Email,
                MerritalStatus = data.MerritalStatus,
                PhoneNumber = data.PhoneNumber,
                DateOfBirth = data.DateOfBirth,
                IsDeleted = data.IsDeleted,
                Useraddress = data.userAddresses?.Select(s => new UserAddressResponceDtos
                {
                    Id = s.Id,
                    HouseNumber = s.HouseNumber,
                    Street = s.Street,
                    City = s.City,
                    State = s.State,
                    PostalCode = s.PostalCode,
                    Country = s.Country
                }).ToList(),
                UserExperiances = data.userExperiances?.Select(e => new UserExperianceResponceDtos
                {
                    Id = e.Id,
                    CompanyName = e.CompanyName,
                    Position = e.Position,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    Description = e.Description
                }).ToList(),
                UserHStudy = data.userHigherStudies?.Select(e => new UserHigherStudiesResponseDtos
                {
                    Id = e.Id,
                    Type = e.Type,
                    Stream = e.Stream,
                    Year = e.Year,
                    Duration = e.Duration,
                    Description = e.Description,
                    Institute = e.Institute,
                    Grade = e.Grade
                }).ToList(),

            };
            return reqUser;
        }

        public async Task<UserResponseDtos> UpadteUser(Guid Id, UserRequestDtos userRequestDtos)
        {
            
            var user = await _userRepo.GetUserById(Id);

            
            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

         
            user.UsersId = userRequestDtos.UsersId;
            user.FirstName = userRequestDtos.FirstName;
            user.LastName = userRequestDtos.LastName;
            user.Nic = userRequestDtos.Nic;
            user.Email = userRequestDtos.Email;
            user.MerritalStatus = userRequestDtos.MerritalStatus;
            user.PhoneNumber = userRequestDtos.PhoneNumber;
            user.DateOfBirth = userRequestDtos.DateOfBirth;

           
            var updatedUser = await _userRepo.UpdateUser(user);

         
            var resUsers = new UserResponseDtos
            {
                Id = updatedUser.Id,
                UsersId = updatedUser.UsersId,
                FirstName = updatedUser.FirstName,
                LastName = updatedUser.LastName,
                Nic = updatedUser.Nic,
                Email = updatedUser.Email,
                MerritalStatus = updatedUser.MerritalStatus,
                PhoneNumber = updatedUser.PhoneNumber,
                DateOfBirth = updatedUser.DateOfBirth,
                IsDeleted = updatedUser.IsDeleted
            };

            return resUsers;
        }

        public async Task DeleteUser(Guid Id)
        {
            await _userRepo.DeleteUser( Id );
        }
    }
}
