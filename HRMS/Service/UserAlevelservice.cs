using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Entities;
using HRMS.IRepository;
using HRMS.Iservice;
using System.Threading.Tasks.Sources;

namespace HRMS.Service
{
    public class UserAlevelservice : IUserAlevelService
    {
        private readonly IUserAlevelRepo _userAlevel;

        public UserAlevelservice(IUserAlevelRepo userAlevel)
        {
            _userAlevel = userAlevel;
        }

        public async Task<UserAlevelResponseDtos> AddAlevel(Guid userId, UserAlevelRequestDtos requestDtos)
        {
            var alevel = new UserALevel
            {
                Id = Guid.NewGuid(),
                userId = userId,
                IndexNo = requestDtos.IndexNo,
                Year = requestDtos.Year,
                School = requestDtos.School,
                Stream = requestDtos.Stream,
                Subject1 = requestDtos.Subject1,
                Subject2 = requestDtos.Subject2,
                Subject3 = requestDtos.Subject3,
                GeneralEnglish = requestDtos.GeneralEnglish,
                GeneralKnowledge = requestDtos.GeneralKnowledge,
                GIT = requestDtos.GIT
            };

            var data = await _userAlevel.AddAlevel(alevel);
            var resAlevel = new UserAlevelResponseDtos
            {
                Id = data.Id,
                IndexNo = data.IndexNo,
                Year = data.Year,
                School = data.School,
                Stream = data.Stream,
                Subject1 = data.Subject1,
                Subject2 = data.Subject2,
                Subject3 = data.Subject3,
                GeneralEnglish = data.GeneralEnglish,
                GeneralKnowledge = data.GeneralKnowledge,
                GIT = data.GIT
            };
            return resAlevel;
        }

        public async Task<List<UserAlevelResponseDtos>> GetAlByUserId(Guid Id)
        {
            var data = await _userAlevel.GetAlevelByUserId(Id);
            var resAls = data.Select(a => new UserAlevelResponseDtos
            {
                Id=a.Id,
                IndexNo = a.IndexNo,
                Year = a.Year,
                School=a.School,
                Stream=a.Stream,
                Subject1 = a.Subject1,
                Subject2 = a.Subject2,
                Subject3=a.Subject3,
                GeneralEnglish=a.GeneralEnglish,
                GeneralKnowledge=a.GeneralKnowledge,
                GIT=a.GIT
            }).ToList();
            return resAls;
        }

        public async Task DeleteAls(Guid Id)
        {
            await _userAlevel.DeleteAlevel(Id);
        }
    }
}
