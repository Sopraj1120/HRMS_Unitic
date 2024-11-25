using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Entities;
using HRMS.IRepository;
using HRMS.Iservice;

namespace HRMS.Service
{
    public class HollydayService : IHollydayService
    {
        private readonly IHollyDayRepo _hollyDayRepo;

        public HollydayService(IHollyDayRepo hollyDayRepo)
        {
            _hollyDayRepo = hollyDayRepo;
        }

        public async Task<HollyDaysResponseDtos> AddHollydays(HollydaysRequestDtos hollydaysRequestDtos)
        {
            var holly = new HollyDays
            {
                Id = Guid.NewGuid(),
                Date = hollydaysRequestDtos.Date,
                Name = hollydaysRequestDtos.Name,
            };
            var data = await _hollyDayRepo.AddHollyDays(holly);
            var resholly = new HollyDaysResponseDtos
            {
                Id = data.Id,
                Date = data.Date.ToString("yyyy-MM-dd"),
                Name = data.Name,
            };
            return resholly;

        }

        public async Task<List<HollyDaysResponseDtos>> GetAllHollyDays()
        {
            var data = await _hollyDayRepo.GatAllHollyDays();
            var resholly = data.Select(h => new HollyDaysResponseDtos
            {
                Id = h.Id,
                Date = h.Date.ToString("yyyy-MM-dd"),
                Name = h.Name,
            }).ToList();
            return resholly;
        }

        public async Task<HollyDaysResponseDtos> GetHollydayById(Guid Id)
        {
            var data = await _hollyDayRepo.GetHollyDayById(Id);

            var resHolly = new HollyDaysResponseDtos
            {
                Id = data.Id,
                Date = data.Date.ToString("yyyy-MM-dd"),
                Name = data.Name,
            };
            return resHolly;
        }

        public async Task<HollyDaysResponseDtos> UpdateHollyday(Guid Id, HollydaysRequestDtos  hollydaysRequestDtos)
        {
            var holly = await _hollyDayRepo.GetHollyDayById(Id);
           
            if(holly == null)
            {
                throw new KeyNotFoundException("HollyDay not found.");
            }

            holly.Date = hollydaysRequestDtos.Date;
            holly.Name = hollydaysRequestDtos.Name;

            var data = await _hollyDayRepo.UpadateHollyDay(holly);

            var resholly = new HollyDaysResponseDtos
            {
                Id = data.Id,
                Date = data.Date.ToString("yyyy-MM-dd"),
                Name = data.Name

            };
            return resholly;
        }

        public async Task DeleteHollyDay(Guid Id)
        {
            await _hollyDayRepo.DeleteHollyday(Id);
        }
    }
}
