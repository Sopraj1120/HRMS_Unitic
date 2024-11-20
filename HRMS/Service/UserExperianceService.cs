using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Entities;
using HRMS.IRepository;
using HRMS.Iservice;

namespace HRMS.Service
{
    public class UserExperianceService : IUserExperianceService
    {
        private readonly IUserExperianceRepo _userExperiance;

        public UserExperianceService(IUserExperianceRepo userExperiance)
        {
            _userExperiance = userExperiance;
        }

        public async Task<UserExperianceResponceDtos> AddExperiance(Guid userId, UserExperianceRequestDtos requestDtos)
        {
            var exp = new UserExperiance
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                CompanyName = requestDtos.CompanyName,
                Position = requestDtos.Position,
                StartDate = requestDtos.StartDate,
                EndDate = requestDtos.EndDate,
                Description = requestDtos.Description
            };

            var data = await _userExperiance.AddExperiance(exp);
            var resexp = new UserExperianceResponceDtos
            {
                Id = data.Id,
                CompanyName = data.CompanyName,
                Position = data.Position,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                Description = data.Description
            };
            return resexp;
        }

        public async Task<List<UserExperianceResponceDtos>> GetExperianceByUserId(Guid Id)
        {
            var data = await _userExperiance.GetExperianceByUserId(Id);
            var resexp = data.Select(e => new UserExperianceResponceDtos
            {
                Id = e.Id,
                CompanyName = e.CompanyName,
                Position = e.Position,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                Description = e.Description
            }).ToList();
            return resexp;
        }

        public async Task DeleteExperiance (Guid Id)
        {
            await _userExperiance.DeleteExperiance(Id);
        }
    }
}
