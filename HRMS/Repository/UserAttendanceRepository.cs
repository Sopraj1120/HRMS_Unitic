using HRMS.DataBase;
using HRMS.DTOs.RequestDtos;
using HRMS.Entities;
using HRMS.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Repository
{
    public class UserAttendanceRepository : IUserAttendanceRepository
    {
        private readonly HRMDBContext _context;

        public UserAttendanceRepository(HRMDBContext context)
        {
            _context = context;
        }

        public async Task<UserAttendance> AddAttendanceForUser(UserAttendance userAttendance)
        {
            var data = await _context.userAttendances.AddAsync(userAttendance);
            await _context.SaveChangesAsync();
            return data.Entity;
        }

        public async Task<UserAttendance> GetUserAttendanceByUserIdAndDate(Guid userId, DateTime date)
        {
            var data = await _context.userAttendances.FirstOrDefaultAsync(x => x.UserId == userId && x.Date.Date == date.Date);
            return data;
        }

        public async Task<List<UserAttendance>> GenerateUserAttendanceReportByUser(Guid userId, DateTime startDate, DateTime endDate)
        {
            var report = await _context.userAttendances
                .Where(x => x.UserId == userId && x.Date >= startDate && x.Date <= endDate)
                .ToListAsync();

            return report;
        }
     

        public async Task<List<UserAttendance>> GetAllAttendanceByDate(DateTime date)
        {
            var attendanceData = await _context.userAttendances
                .Where(x => x.Date.Date == date.Date) 
                .ToListAsync();

            return attendanceData;
        }

        public async Task<UserAttendance> UpdateUserAttendance(UserAttendance userAttendance)
        {
            var user = await _context.userAttendances.FirstOrDefaultAsync(x => x.UserId == userAttendance.UserId);
            if (user == null) return null;
           
            user.OutTime = userAttendance.OutTime;
            user.Status = userAttendance.Status;

            _context.userAttendances.Update(user);
            await _context.SaveChangesAsync();
            return user;

        }

    }


}

