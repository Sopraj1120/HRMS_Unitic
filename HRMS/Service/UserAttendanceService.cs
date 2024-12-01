using Azure;
using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Entities;
using HRMS.IRepository;
using HRMS.Iservice;

namespace HRMS.Service
{
    public class UserAttendanceService : IUserAttendanceService
    {
        private readonly IUserAttendanceRepository _userAttendanceRepository;
        private readonly IUserRepo _userRepo;

        public UserAttendanceService(IUserAttendanceRepository userAttendanceRepository, IUserRepo userRepo)
        {
            _userAttendanceRepository = userAttendanceRepository;
            _userRepo = userRepo;
        }

        public async Task<UserAttendanceResponseDtos> AddAttendanceForUser(Guid UserId, UserAttendanceRequestDtos userAttendanceRequestDtos)
        {
           
            var user = await _userRepo.GetUserById(UserId).ConfigureAwait(false);

            var userAttendance = new UserAttendance
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                Name = user.FirstName,
                Role = user.Role,
                Date = userAttendanceRequestDtos.Date,
                InTime = userAttendanceRequestDtos.InTime,  
                OutTime = userAttendanceRequestDtos.OutTime, 
                Status = userAttendanceRequestDtos.Status,
            };

            var data = await _userAttendanceRepository.AddAttendanceForUser(userAttendance).ConfigureAwait(false);

            var response = new UserAttendanceResponseDtos
            {
                Id = data.Id,
                UserId = data.UserId, 
                Name = data.Name,
                Role = data.Role.ToString(),
                Date = data.Date.ToString("yyyy-MM-dd"),
                InTime = data.InTime.ToString(@"HH\:mm"),
                OutTime = data.OutTime?.ToString(@"HH\:mm"),
                Status = data.Status.ToString(),
            };

            return response;
        }


        public async Task<UserAttendanceResponseDtos> GetUserAttendanceByUserIdAndDate(Guid userId, DateTime date)
        {
            var data = await _userAttendanceRepository.GetUserAttendanceByUserIdAndDate(userId, date).ConfigureAwait(false);

            
            var Responce = new UserAttendanceResponseDtos
            {
                Id = data.Id,
                UserId = data.Id,
                Name = data.Name,
                Role = data.Role.ToString(),
                Date = data.Date.ToString("yyyy-MM-dd"),
                InTime = data.InTime.ToString(@"HH\:mm"),
                OutTime = data.OutTime?.ToString(@"HH\:mm"),
                Status = data.Status.ToString(),
            };
            return Responce;
        }

        public async Task<UserAttendanceReportWithStatusCount> GenerateUserAttendanceReportByUser(Guid userId, DateTime startDate, DateTime endDate)
        {
          
            var report = await _userAttendanceRepository.GenerateUserAttendanceReportByUser(userId, startDate, endDate).ConfigureAwait(false);

            var statusCount = report.GroupBy(x => x.Status).Select( u => new AttendanceReportDto
            {
                Status = u.Key.ToString(),
                Count = u.Count()
            }).ToList();


            var response = report.Select(x => new UserAttendanceResponseDtos
            {
                Id = x.Id,
                UserId = x.UserId,
                Name = x.Name,
                Role = x.Role.ToString(),
                Date = x.Date.ToString("yyyy-MM-dd"),
                InTime = x.InTime.ToString(@"HH\:mm"),
                OutTime = x.OutTime? .ToString(@"HH\:mm"),
                Status = x.Status.ToString(),

            }).ToList();

            var attendanceReport = new UserAttendanceReportWithStatusCount
            {
                AttendanceDetails = response,
                StatusCount = statusCount
            };

            return attendanceReport;

        }
     



        public async Task<List<UserAttendanceResponseDtos>> GetAllAttendanceByDate(DateTime date)
        {
            var data = await _userAttendanceRepository.GetAllAttendanceByDate(date).ConfigureAwait(false);

            var responce = data.Select(x => new UserAttendanceResponseDtos
            {
                Id = x.Id,
                UserId = x.Id,
                Name = x.Name,
                Role = x.Role.ToString(),
                Date = x.Date.ToString("yyyy-MM-dd"),
                InTime = x.InTime.ToString(@"HH\:mm"),
                OutTime = x.OutTime?.ToString(@"HH\:mm"),
                Status = x.Status.ToString(),
            }).ToList();

            return responce;
        }

        public async Task<UserAttendanceResponseDtos> UpdateUserAttendance(Guid UserId, DateTime date, UserAttendanceRequestDtos userAttendanceRequestDtos)
        {
            var user = await _userAttendanceRepository.GetUserAttendanceByUserIdAndDate(UserId, date).ConfigureAwait(false);

            user.OutTime = userAttendanceRequestDtos.OutTime;
            user.Status = userAttendanceRequestDtos.Status;

            var data = await _userAttendanceRepository.UpdateUserAttendance(user).ConfigureAwait(false);

            var responce = new UserAttendanceResponseDtos
            {
                Id = data.Id,
                UserId = data.Id,
                Name = data.Name,
                Role = data.Role.ToString(),
                Date = data.Date.ToString("yyyy-MM-dd"),
                InTime = data.InTime.ToString(@"HH\:mm"),
                OutTime = data.OutTime?.ToString(@"HH\:mm"),
                Status = data.Status.ToString(),
            };
            return responce;


        }
    }
}
