using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Entities;
using HRMS.IRepository;
using HRMS.Iservice;

namespace HRMS.Service
{
    public class OlevelService : IOlevelService
    {
        private readonly IOlevelRepo _olevelrepo;

        public OlevelService(IOlevelRepo olevelrepo)
        {
            _olevelrepo = olevelrepo;
        }

        public async Task<OLResponseDtos> AddOlevel(Guid studentId, OLevalRequestDtos oLevalRequestDtos)
        {
            var olevel = new OLevel
            {
                Id = Guid.NewGuid(),
                StudentId = studentId,
                IndexNo = oLevalRequestDtos.IndexNo,
                Year = oLevalRequestDtos.Year,
                School = oLevalRequestDtos.School,
                Tamil = oLevalRequestDtos.Tamil,
                Science = oLevalRequestDtos.Science,
                Maths = oLevalRequestDtos.Maths,
                Religion = oLevalRequestDtos.Religion,
                English = oLevalRequestDtos.English,
                History = oLevalRequestDtos.History,
                Basket1 = oLevalRequestDtos.Basket1,
                Basket2 = oLevalRequestDtos.Basket2,
                Basket3 = oLevalRequestDtos.Basket3,

            };

            var data = await _olevelrepo.AddOlevel(olevel);

            var resOl = new OLResponseDtos
            {
                Id = data.Id,
                IndexNo = data.IndexNo,
                Year = data.Year,
                School = data.School,
                Tamil = data.Tamil,
                Science = data.Science,
                Maths = data.Maths,
                Religion = data.Religion,
                English = data.English,
                History = data.History,
                Basket1 = data.Basket1,
                Basket2 = data.Basket2,
                Basket3 = data.Basket3,
            };
            return resOl;
        }

        public async Task<List<OLResponseDtos>> GetOlByStudentId(Guid studentId)
        {
            var data = await _olevelrepo.GetOLevelByStudentId(studentId);
            var resol = data.Select(o => new OLResponseDtos
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

            }).ToList();
            return resol;
        }

        public async Task DeleteOl(Guid Id)
        {
            await _olevelrepo.DeleteOlevels(Id);
        }
    }
}
