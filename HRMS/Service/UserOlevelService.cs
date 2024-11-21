using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Entities;
using HRMS.IRepository;
using HRMS.Iservice;

namespace HRMS.Service
{
    public class UserOlevelService : IUserOlevelService
    {
        private readonly IUserOlevelRepo _userOlevel;

        public UserOlevelService(IUserOlevelRepo userOlevel)
        {
            _userOlevel = userOlevel;
        }

        public async Task<UserOlevelResponseDtos> AddOlevels (Guid UserId, UserOlevelRequestDtos userOlevelRequestDtos)
        {
            var olevel = new UserOLevel
            {
                Id = Guid.NewGuid(),
                UserId = UserId,
                IndexNo = userOlevelRequestDtos.IndexNo,
                Year = userOlevelRequestDtos.Year,
                School = userOlevelRequestDtos.School,
                Tamil = userOlevelRequestDtos.Tamil,
                Science = userOlevelRequestDtos.Science,
                Maths = userOlevelRequestDtos.Maths,
                Religion = userOlevelRequestDtos.Religion,
                English = userOlevelRequestDtos.English,
                History = userOlevelRequestDtos.History,
                Basket1 = userOlevelRequestDtos.Basket1,
                Basket2 = userOlevelRequestDtos.Basket2,
                Basket3 = userOlevelRequestDtos.Basket3
            };

            var data = await _userOlevel.AddOlevel (olevel);

            var resOl = new UserOlevelResponseDtos
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
                Basket3 = data.Basket3
            };
            return resOl;
        }

        public async Task<List<UserOlevelResponseDtos>> GetOlevelByUserId( Guid userId )
        {
            var data = await _userOlevel.GetOlevelByUserId ( userId );
            var resOlevel = data.Select(o => new UserOlevelResponseDtos
            {
                Id=o.Id,
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
            return resOlevel;
        }

        public async Task DeleteOlevel(Guid Id)
        {
            await _userOlevel.DeleteOlevel( Id );
        }
    }
}
