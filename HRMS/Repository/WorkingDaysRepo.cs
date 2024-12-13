using HRMS.DataBase;
using HRMS.Entities;
using HRMS.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Repository
{
    public class WorkingDaysRepo : IWorkingDaysRepo
    {
        private readonly HRMDBContext _hRMDBContext;

        public WorkingDaysRepo(HRMDBContext hRMDBContext)
        {
            _hRMDBContext = hRMDBContext;
        }

        public async Task<WorkingDays> AddWorkingDays(WorkingDays workingDays)
        {
            var data = await _hRMDBContext.workingDays.AddAsync(workingDays);
            await _hRMDBContext.SaveChangesAsync();
            return data.Entity;
        }

        public async Task<List<WorkingDays>> GetAllWorkingdays()
        {
            var data = await _hRMDBContext.workingDays
                .Include(wd => wd.WeekDays) 
                .ToListAsync();
            return data;
        }

        public async Task<WorkingDays> GetWorkingDaysByUserId(Guid UserId)
        {
            var data = await _hRMDBContext.workingDays.Include(a => a.WeekDays).FirstOrDefaultAsync(x => x.UserId == UserId);
            return data;
        }

        public async Task<WorkingDays> UpdateWorkingdays(WorkingDays workingDays)
        {
            var user = await GetWorkingDaysByUserId(workingDays.UserId);
            if (user == null) return null;
            user.WeekDays = workingDays.WeekDays;


            _hRMDBContext.workingDays.Update(user);
            await _hRMDBContext.SaveChangesAsync();
            return user;
        }

        public async Task deleteWorkingDays(Guid Id)
        {
            var data = await _hRMDBContext.workingDays.FirstOrDefaultAsync(x =>x.Id == Id); 
             _hRMDBContext.workingDays.Remove(data);
            await _hRMDBContext.SaveChangesAsync();
        }
    }
}
