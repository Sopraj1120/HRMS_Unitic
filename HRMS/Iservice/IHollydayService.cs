using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;

namespace HRMS.Iservice
{
    public interface IHollydayService
    {
        Task<HollyDaysResponseDtos> AddHollydays(HollydaysRequestDtos hollydaysRequestDtos);
        Task<List<HollyDaysResponseDtos>> GetAllHollyDays();
        Task<HollyDaysResponseDtos> GetHollydayById(Guid Id);
        Task<HollyDaysResponseDtos> UpdateHollyday(Guid Id, HollydaysRequestDtos hollydaysRequestDtos);
        Task DeleteHollyDay(Guid Id);
    }
}
