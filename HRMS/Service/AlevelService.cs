using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Entities;
using HRMS.IRepository;
using HRMS.Iservice;

namespace HRMS.Service
{
    public class AlevelService : IAlevelService
    {
        private readonly IAlevelRepo _alrepo;

        public AlevelService(IAlevelRepo alrepo)
        {
            _alrepo = alrepo;
        }

        public async Task<ALevelResponseDtos> AddAlevels(Guid studentId, ALevelRequestDtos requestDtos)
        {
            var als = new ALevel
            {
                Id = Guid.NewGuid(),
                StudentId = studentId,
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

            var data = await _alrepo.AddAlevel(als);
            var resal = new ALevelResponseDtos
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
            return resal;
        }

        public async Task<List<ALevelResponseDtos>> GetAlevelByStudentId (Guid StudentId)
        {
            var data = await _alrepo.GetAlByStudentId(StudentId);

            var resal = data.Select(a => new ALevelResponseDtos
            {
                Id = a.Id,
                IndexNo = a.IndexNo,
                Year = a.Year,
                School = a.School,
                Stream = a.Stream,
                Subject1 = a.Subject1,
                Subject2 = a.Subject2,
                Subject3 = a.Subject3,
                GeneralEnglish = a.GeneralEnglish,
                GeneralKnowledge = a.GeneralKnowledge,
                GIT = a.GIT
            }).ToList();
            return resal;
        }

        public async Task DeleteAlevel (Guid Id)
        {
            await _alrepo.DeleteAls(Id);
        }
    }
}
