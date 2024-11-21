using HRMS.Entities;

namespace HRMS.IRepository
{
    public interface IHollyDayRepo
    {
        Task<HollyDays> AddHollyDays(HollyDays days);
        Task<List<HollyDays>> GatAllHollyDays();
        Task<HollyDays> GetHollyDayById(Guid Id);
        Task<HollyDays> UpadateHollyDay(HollyDays hollyDays);
        Task DeleteHollyday(Guid Id);
    }
}
