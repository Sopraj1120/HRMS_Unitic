using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Entities;
using HRMS.IRepository;
using HRMS.Iservice;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace HRMS.Service
{
    public class UserService : IUserServices
    {
        private readonly IUserRepo _userRepo;
        private readonly IConfiguration _configuration;


        public UserService(IUserRepo userRepo, IConfiguration configuration)
        {
            _userRepo = userRepo;
            _configuration = configuration;
        }



        public async Task<UserResponseDtos> AddAdmin(UserRequestDtos userRequestDtos)
        {
            var user = new Users
            {
                Id = Guid.NewGuid(),
                UsersId = userRequestDtos.UsersId,
                FirstName = userRequestDtos.FirstName,
                LastName = userRequestDtos.LastName,
                Nic = userRequestDtos.Nic,
                Email = userRequestDtos.Email,
                PassWord = BCrypt.Net.BCrypt.HashPassword(userRequestDtos.Password),
                MerritalStatus = userRequestDtos.MerritalStatus,
                PhoneNumber = userRequestDtos.PhoneNumber,
                DateOfBirth = userRequestDtos.DateOfBirth,
                Gender = userRequestDtos.Gender,
                Image = userRequestDtos.Image

            };
            var data = await _userRepo.AddAdmin(user);

            var resuser = new UserResponseDtos
            {
                Id = data.Id,
                UsersId = data.UsersId,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Nic = data.Nic,
                Email = data.Email,
                Password = data.PassWord,
                MerritalStatus = data.MerritalStatus.ToString(),
                PhoneNumber = data.PhoneNumber,
                DateOfBirth = data.DateOfBirth.ToString("yyyy-MM-dd"),
                Role = data.Role.ToString(),
                IsDeleted = data.IsDeleted,
                Gender = data.Gender.ToString(),
                Image = data.Image

            };
            return resuser;
        }
        public async Task<UserResponseDtos> AddStaff(UserRequestDtos userRequestDtos)
        {
            var user = new Users
            {
                Id = Guid.NewGuid(),
                UsersId = userRequestDtos.UsersId,
                FirstName = userRequestDtos.FirstName,
                LastName = userRequestDtos.LastName,
                Nic = userRequestDtos.Nic,
                Email = userRequestDtos.Email,
                PassWord = BCrypt.Net.BCrypt.HashPassword(userRequestDtos.Password),
                MerritalStatus = userRequestDtos.MerritalStatus,
                PhoneNumber = userRequestDtos.PhoneNumber,
                DateOfBirth = userRequestDtos.DateOfBirth,
                Gender = userRequestDtos.Gender,
                Image = userRequestDtos.Image

            };
            var data = await _userRepo.AddStaff(user);

            var resuser = new UserResponseDtos
            {
                Id = data.Id,
                UsersId = data.UsersId,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Nic = data.Nic,
                Email = data.Email,
                Password = data.PassWord,
                MerritalStatus = data.MerritalStatus.ToString(),
                PhoneNumber = data.PhoneNumber,
                DateOfBirth = data.DateOfBirth.ToString("yyyy-MM-dd"),
                Role = data.Role.ToString(),
                IsDeleted = data.IsDeleted,
                Gender = data.Gender.ToString(),
                Image = data.Image

            };
            return resuser;
        }

        public async Task<UserResponseDtos> AddEmployee(UserRequestDtos userRequestDtos)
        {
            var user = new Users
            {
                Id = Guid.NewGuid(),
                UsersId = userRequestDtos.UsersId,
                FirstName = userRequestDtos.FirstName,
                LastName = userRequestDtos.LastName,
                Nic = userRequestDtos.Nic,
                Email = userRequestDtos.Email,
                PassWord = BCrypt.Net.BCrypt.HashPassword(userRequestDtos.Password),
                MerritalStatus = userRequestDtos.MerritalStatus,
                PhoneNumber = userRequestDtos.PhoneNumber,
                DateOfBirth = userRequestDtos.DateOfBirth,
                Gender = userRequestDtos.Gender,
                Image = userRequestDtos.Image

            };
            var data = await _userRepo.AddEmployee(user);

            var resuser = new UserResponseDtos
            {
                Id = data.Id,
                UsersId = data.UsersId,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Nic = data.Nic,
                Email = data.Email,
                Password = data.PassWord,
                MerritalStatus = data.MerritalStatus.ToString(),
                PhoneNumber = data.PhoneNumber,
                DateOfBirth = data.DateOfBirth.ToString("yyyy-MM-dd"),
                Role = data.Role.ToString(),
                IsDeleted = data.IsDeleted,
                Gender = data.Gender.ToString(),
                Image = data.Image

            };
            return resuser;
        }

        public async Task<UserResponseDtos> AddLecturer(UserRequestDtos userRequestDtos)
        {
            var user = new Users
            {
                Id = Guid.NewGuid(),
                UsersId = userRequestDtos.UsersId,
                FirstName = userRequestDtos.FirstName,
                LastName = userRequestDtos.LastName,
                Nic = userRequestDtos.Nic,
                Email = userRequestDtos.Email,
                PassWord = BCrypt.Net.BCrypt.HashPassword(userRequestDtos.Password),
                MerritalStatus = userRequestDtos.MerritalStatus,
                PhoneNumber = userRequestDtos.PhoneNumber,
                DateOfBirth = userRequestDtos.DateOfBirth,
                Gender = userRequestDtos.Gender,
                Image = userRequestDtos.Image

            };
            var data = await _userRepo.AddLecturer(user);

            var resuser = new UserResponseDtos
            {
                Id = data.Id,
                UsersId = data.UsersId,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Nic = data.Nic,
                Email = data.Email,
                Password = data.PassWord,
                MerritalStatus = data.MerritalStatus.ToString(),
                PhoneNumber = data.PhoneNumber,
                DateOfBirth = data.DateOfBirth.ToString("yyyy-MM-dd"),
                Role = data.Role.ToString(),
                IsDeleted = data.IsDeleted,
                Gender = data.Gender.ToString(),
                Image = data.Image

            };
            return resuser;

        }
        public async Task<List<UserResponseDtos>> GetAllUser()
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
                Password = a.PassWord,
                MerritalStatus = a.MerritalStatus.ToString(),
                PhoneNumber = a.PhoneNumber,
                DateOfBirth = a.DateOfBirth.ToString("yyyy-MM-dd"),
                Role = a.Role.ToString(),
                IsDeleted = a.IsDeleted,
                Gender = a.Gender.ToString(),
                Image = a.Image,

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
                Olevel = a.userOLevels?.Select(o => new UserOlevelResponseDtos
                {
                    Id = o.Id,
                    IndexNo = o.IndexNo,
                    Year = o.Year,
                    School = o.School,
                    Tamil = o.Tamil,
                    Science = o.Science,
                    Maths = o.Maths,
                    Religion = o.Religion,
                    English = o.English,
                    History = o.History,
                    Basket1 = o.Basket1,
                    Basket2 = o.Basket2,
                    Basket3 = o.Basket3
                }).ToList(),
                UserAlevel = a.userALevels?.Select(l => new UserAlevelResponseDtos
                {
                    Id = l.Id,
                    IndexNo = l.IndexNo,
                    Year = l.Year,
                    School = l.School,
                    Stream = l.Stream,
                    Subject1 = l.Subject1,
                    Subject2 = l.Subject2,
                    Subject3 = l.Subject3,
                    GeneralEnglish = l.GeneralEnglish,
                    GeneralKnowledge = l.GeneralKnowledge,
                    GIT = l.GIT
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
        public async Task<List<UserResponseDtos>> GetAdminUser()
        {
            var data = await _userRepo.GetAdminUsers();

            var resUser = data.Select(a => new UserResponseDtos
            {
                Id = a.Id,
                UsersId = a.UsersId,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Nic = a.Nic,
                Email = a.Email,
                Password = a.PassWord,
                MerritalStatus = a.MerritalStatus.ToString(),
                PhoneNumber = a.PhoneNumber,
                DateOfBirth = a.DateOfBirth.ToString("yyyy-MM-dd"),
                Role = a.Role.ToString(),
                IsDeleted = a.IsDeleted,
                Gender = a.Gender.ToString(),
                Image = a.Image,

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
                Olevel = a.userOLevels?.Select(o => new UserOlevelResponseDtos
                {
                    Id = o.Id,
                    IndexNo = o.IndexNo,
                    Year = o.Year,
                    School = o.School,
                    Tamil = o.Tamil,
                    Science = o.Science,
                    Maths = o.Maths,
                    Religion = o.Religion,
                    English = o.English,
                    History = o.History,
                    Basket1 =o.Basket1,
                    Basket2 =o.Basket2,
                    Basket3 = o.Basket3
                }).ToList(),
                UserAlevel = a.userALevels?.Select(l => new UserAlevelResponseDtos
                {
                    Id = l.Id,
                    IndexNo = l.IndexNo,
                    Year =l.Year,
                    School = l.School,
                    Stream = l.Stream,
                    Subject1 = l.Subject1,
                    Subject2 = l.Subject2,
                    Subject3 = l.Subject3,
                    GeneralEnglish = l.GeneralEnglish,
                    GeneralKnowledge = l.GeneralKnowledge,
                    GIT = l.GIT
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
        public async Task<List<UserResponseDtos>> GetStaffUser()
        {
            var data = await _userRepo.GetStaffUsers();

            var resUser = data.Select(a => new UserResponseDtos
            {
                Id = a.Id,
                UsersId = a.UsersId,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Nic = a.Nic,
                Email = a.Email,
                Password = a.PassWord,
                MerritalStatus = a.MerritalStatus.ToString(),
                PhoneNumber = a.PhoneNumber,
                DateOfBirth = a.DateOfBirth.ToString("yyyy-MM-dd"),
                Role = a.Role.ToString(),
                IsDeleted = a.IsDeleted,
                Gender = a.Gender.ToString(),
                Image = a.Image,

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
                Olevel = a.userOLevels?.Select(o => new UserOlevelResponseDtos
                {
                    Id = o.Id,
                    IndexNo = o.IndexNo,
                    Year = o.Year,
                    School = o.School,
                    Tamil = o.Tamil,
                    Science = o.Science,
                    Maths = o.Maths,
                    Religion = o.Religion,
                    English = o.English,
                    History = o.History,
                    Basket1 = o.Basket1,
                    Basket2 = o.Basket2,
                    Basket3 = o.Basket3
                }).ToList(),
                UserAlevel = a.userALevels?.Select(l => new UserAlevelResponseDtos
                {
                    Id = l.Id,
                    IndexNo = l.IndexNo,
                    Year = l.Year,
                    School = l.School,
                    Stream = l.Stream,
                    Subject1 = l.Subject1,
                    Subject2 = l.Subject2,
                    Subject3 = l.Subject3,
                    GeneralEnglish = l.GeneralEnglish,
                    GeneralKnowledge = l.GeneralKnowledge,
                    GIT = l.GIT
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

        public async Task<List<UserResponseDtos>> GeteEmployeeUser()
        {
            var data = await _userRepo.GetEmployeeUsers();

            var resUser = data.Select(a => new UserResponseDtos
            {
                Id = a.Id,
                UsersId = a.UsersId,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Nic = a.Nic,
                Email = a.Email,
                Password = a.PassWord,
                MerritalStatus = a.MerritalStatus.ToString(),
                PhoneNumber = a.PhoneNumber,
                DateOfBirth = a.DateOfBirth.ToString("yyyy-MM-dd"),
                Role = a.Role.ToString(),
                IsDeleted = a.IsDeleted,
                Gender = a.Gender.ToString(),
                Image = a.Image,

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
                Olevel = a.userOLevels?.Select(o => new UserOlevelResponseDtos
                {
                    Id = o.Id,
                    IndexNo = o.IndexNo,
                    Year = o.Year,
                    School = o.School,
                    Tamil = o.Tamil,
                    Science = o.Science,
                    Maths = o.Maths,
                    Religion = o.Religion,
                    English = o.English,
                    History = o.History,
                    Basket1 = o.Basket1,
                    Basket2 = o.Basket2,
                    Basket3 = o.Basket3
                }).ToList(),
                UserAlevel = a.userALevels?.Select(l => new UserAlevelResponseDtos
                {
                    Id = l.Id,
                    IndexNo = l.IndexNo,
                    Year = l.Year,
                    School = l.School,
                    Stream = l.Stream,
                    Subject1 = l.Subject1,
                    Subject2 = l.Subject2,
                    Subject3 = l.Subject3,
                    GeneralEnglish = l.GeneralEnglish,
                    GeneralKnowledge = l.GeneralKnowledge,
                    GIT = l.GIT
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

        public async Task<List<UserResponseDtos>> GetLecturesUsers()
        {
            var data = await _userRepo.GetLecturersUsers();

            var resUser = data.Select(a => new UserResponseDtos
            {
                Id = a.Id,
                UsersId = a.UsersId,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Nic = a.Nic,
                Email = a.Email,
                Password = a.PassWord,
                MerritalStatus = a.MerritalStatus.ToString(),
                PhoneNumber = a.PhoneNumber,
                DateOfBirth = a.DateOfBirth.ToString("yyyy-MM-dd"),
                Role = a.Role.ToString(),
                IsDeleted = a.IsDeleted,
                Gender = a.Gender.ToString(),
                Image = a.Image,

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
                Olevel = a.userOLevels?.Select(o => new UserOlevelResponseDtos
                {
                    Id = o.Id,
                    IndexNo = o.IndexNo,
                    Year = o.Year,
                    School = o.School,
                    Tamil = o.Tamil,
                    Science = o.Science,
                    Maths = o.Maths,
                    Religion = o.Religion,
                    English = o.English,
                    History = o.History,
                    Basket1 = o.Basket1,
                    Basket2 = o.Basket2,
                    Basket3 = o.Basket3
                }).ToList(),
                UserAlevel = a.userALevels?.Select(l => new UserAlevelResponseDtos
                {
                    Id = l.Id,
                    IndexNo = l.IndexNo,
                    Year = l.Year,
                    School = l.School,
                    Stream = l.Stream,
                    Subject1 = l.Subject1,
                    Subject2 = l.Subject2,
                    Subject3 = l.Subject3,
                    GeneralEnglish = l.GeneralEnglish,
                    GeneralKnowledge = l.GeneralKnowledge,
                    GIT = l.GIT
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
                Password = data.PassWord,
                MerritalStatus = data.MerritalStatus.ToString(),
                PhoneNumber = data.PhoneNumber,
                DateOfBirth = data.DateOfBirth.ToString("yyyy-MM-dd"),
                Role = data.Role.ToString(),
                IsDeleted = data.IsDeleted,
                Gender = data.Gender.ToString(),
                Image = data.Image,


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
                Olevel = data.userOLevels?.Select(o => new UserOlevelResponseDtos
                {
                    Id = o.Id,
                    IndexNo = o.IndexNo,
                    Year = o.Year,
                    School = o.School,
                    Tamil = o.Tamil,
                    Science = o.Science,
                    Maths = o.Maths,
                    Religion = o.Religion,
                    English = o.English,
                    History = o.History,
                    Basket1 = o.Basket1,
                    Basket2 = o.Basket2,
                    Basket3 = o.Basket3
                }).ToList(),
                UserAlevel = data.userALevels?.Select(l => new UserAlevelResponseDtos
                {
                    Id = l.Id,
                    IndexNo = l.IndexNo,
                    Year = l.Year,
                    School = l.School,
                    Stream = l.Stream,
                    Subject1 = l.Subject1,
                    Subject2 = l.Subject2,
                    Subject3 = l.Subject3,
                    GeneralEnglish = l.GeneralEnglish,
                    GeneralKnowledge = l.GeneralKnowledge,
                    GIT = l.GIT
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
                Password = userRequestDtos.Password,
                MerritalStatus = updatedUser.MerritalStatus.ToString(),
                PhoneNumber = updatedUser.PhoneNumber,
                DateOfBirth = updatedUser.DateOfBirth.ToString("yyyy-MM-dd"),
                IsDeleted = updatedUser.IsDeleted,
                Gender = updatedUser.Gender.ToString(),
                Image = userRequestDtos.Image
             
            };

            return resUsers;
        }

        public async Task DeleteUser(Guid Id)
        {
            await _userRepo.DeleteUser( Id );
        }



       
    }
}
