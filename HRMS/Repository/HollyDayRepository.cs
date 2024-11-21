using HRMS.DataBase;
using HRMS.Entities;
using HRMS.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Repository
{
    public class HollyDayRepository : IHollyDayRepo
    {
        private readonly HRMDBContext _context;

        public HollyDayRepository(HRMDBContext context)
        {
            _context = context;
        }

        public async Task<HollyDays> AddHollyDays (HollyDays days)
        {
            var data = await _context.hollyDays.AddAsync (days);
            await _context.SaveChangesAsync();
            return days;
        }

        public async Task<List<HollyDays>> GatAllHollyDays()
        {
            var data = await _context.hollyDays.ToListAsync();
            return data;
        }

        public async Task<HollyDays> GetHollyDayById(Guid Id)
        {
            var data = await _context.hollyDays.FirstOrDefaultAsync (x => x.Id == Id);
            return data;
        }

        public async Task<HollyDays> UpadateHollyDay(HollyDays hollyDays)
        {
            var holly = await GetHollyDayById (hollyDays.Id);
            if (holly == null) return null;

            holly.Date = hollyDays.Date;
            holly.Name = hollyDays.Name;

            await _context.SaveChangesAsync();
            return holly;
        }

        public async Task DeleteHollyday(Guid Id)
        {
            var data = await GetHollyDayById(Id);
            if (data != null)
            {
                _context.hollyDays.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
    }
}
