using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Entities;
using HRMS.IRepository;
using HRMS.Iservice;
using System.Diagnostics.Contracts;

namespace HRMS.Service
{
    public class UserExperianceservice : IUserExperianceSevice
    {
        private readonly IUserExperiancerepo _userexp;

        public UserExperianceservice(IUserExperiancerepo userexp)
        {
            _userexp = userexp;
        }


        public async Task<UserExperianceResponseDtos> AddExperiance(Guid userId, UserExperianceRequestdtos userExperianceRequestdtos)
        {
            var exp = new UserExperiance
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Type = userExperianceRequestdtos.Type,
                Stream = userExperianceRequestdtos.Stream,
                Year = userExperianceRequestdtos.Year,
                Duration = userExperianceRequestdtos.Duration,
                Description = userExperianceRequestdtos.Description,
                Institute = userExperianceRequestdtos.Institute,
                Grade = userExperianceRequestdtos.Grade
            };
            var data = await _userexp.AddExperiance(exp);

            var resexp = new UserExperianceResponseDtos
            {
                Id = data.Id,
                Type = data.Type,
                Stream = data.Stream,
                Year = data.Year,
                Duration = data.Duration,
                Description = data.Description,
                Institute = data.Institute,
                Grade = data.Grade
            };
            return resexp;
        }

        public async Task<List <UserExperianceResponseDtos>> GetexperianceByUserId(Guid UderId)
        {
            var data = await _userexp.GetExperianceByUserId(UderId);

            var resexp = data.Select(e => new UserExperianceResponseDtos
            {
                Id = e.Id,
                Type = e.Type,
                Stream = e.Stream,
                Year = e.Year,
                Duration = e.Duration,
                Description = e.Description,
                Institute = e.Institute,
                Grade = e.Grade
            }).ToList();
            return resexp;

        }

        public async Task DeleteExperiance (Guid Id)
        {
            await _userexp.DeleteExperiance(Id);
        }
    }
}
