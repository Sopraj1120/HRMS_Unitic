using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Entities;
using HRMS.IRepository;
using HRMS.Iservice;

namespace HRMS.Service
{
    public class ExperianceService : IExperianceService
    {
        private readonly IExperianceRepo _experiancerepo;

        public ExperianceService(IExperianceRepo experiancerepo)
        {
            _experiancerepo = experiancerepo;
        }

        public async Task<ExperianceResponseDtos> AddExperiance (Guid studentId, ExperianceRequestDtos requestDtos)
        {
            var exp = new Experiance
            {
                Id = Guid.NewGuid(),
                StudentId = studentId,
                CompanyName = requestDtos.CompanyName,
                Position = requestDtos.Position,
                StartDate = requestDtos.StartDate,
                EndDate = requestDtos.EndDate,
                Description = requestDtos.Description
            };

            var data = await _experiancerepo.AddExperiance(exp);

            var resexp = new ExperianceResponseDtos
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

        public async Task<List<ExperianceResponseDtos>> GetExperianceByStudentId (Guid studentId)
        {
            var data = await _experiancerepo.GetExperianceByStudentId(studentId);

            var resexp = data.Select(e => new ExperianceResponseDtos
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
            await _experiancerepo.DeleteExperiance(Id);
        }
    }
}
