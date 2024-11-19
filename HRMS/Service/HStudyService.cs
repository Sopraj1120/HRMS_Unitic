using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Entities;
using HRMS.IRepository;
using HRMS.Iservice;

namespace HRMS.Service
{
    public class HStudyService : IHStudeyService
    {
        private readonly IHStudyRepo _hstudyrepo;

        public HStudyService(IHStudyRepo hstudyrepo)
        {
            _hstudyrepo = hstudyrepo;
        }

        public async Task<HStudeiesResponseDtos> AddHStudy(Guid studentid, HStudiesRequestDtos requestDtos)
        {
            var hstudy = new HigherStudies
            {
                Id = Guid.NewGuid(),
                StudentId = studentid,
                Type = requestDtos.Type,
                Stream = requestDtos.Stream,
                Year = requestDtos.Year,
                Duration = requestDtos.Duration,
                Description = requestDtos.Description,
                Institute = requestDtos.Institute,
                Grade = requestDtos.Grade
            };

            var data = await _hstudyrepo.AddHStudy(hstudy);

            var reshstudy = new HStudeiesResponseDtos
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
            return reshstudy;
        }

        public async Task<List<HStudeiesResponseDtos>> GetHStudyByStudentId (Guid studentId)
        {
            var data = await _hstudyrepo.GetHStudeyByStudentId(studentId);
            var resHstudy = data.Select(h => new HStudeiesResponseDtos
            {
                Id =h.Id,
                Type = h.Type,
                Stream = h.Stream,
                Year = h.Year,
                Duration = h.Duration,
                Description = h.Description,
                Institute = h.Institute,
                Grade = h.Grade
            }).ToList();

            return resHstudy;
        }

        public async Task DeleteHStudy (Guid Id)
        {
            await _hstudyrepo.DeleteHStudy(Id);
        }
    }

}
