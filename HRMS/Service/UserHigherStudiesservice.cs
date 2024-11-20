using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Entities;
using HRMS.IRepository;
using HRMS.Iservice;
using System.Diagnostics.Contracts;

namespace HRMS.Service
{
    public class UserHigherStudiesservice : UserHigherStudiesSevice
    {
        private readonly IUserHigherStudiesrepo _userexp;

        public UserHigherStudiesservice(IUserHigherStudiesrepo userexp)
        {
            _userexp = userexp;
        }


        public async Task<UserHigherStudiesResponseDtos> AddHStudy(Guid userId, UserHigherStudiesRequestdtos userHigherStudies)
        {
            var exp = new UserHigherStudies
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Type = userHigherStudies.Type,
                Stream = userHigherStudies.Stream,
                Year = userHigherStudies.Year,
                Duration = userHigherStudies.Duration,
                Description = userHigherStudies.Description,
                Institute = userHigherStudies.Institute,
                Grade = userHigherStudies.Grade
            };
            var data = await _userexp.AddHStudy(exp);

            var resexp = new UserHigherStudiesResponseDtos
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

        public async Task<List <UserHigherStudiesResponseDtos>> GetHStudyByUserId(Guid UderId)
        {
            var data = await _userexp.GetHStudyByUserId(UderId);

            var resexp = data.Select(e => new UserHigherStudiesResponseDtos
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

        public async Task DeleteHStudy (Guid Id)
        {
            await _userexp.DeleteHStudy(Id);
        }
    }
}
