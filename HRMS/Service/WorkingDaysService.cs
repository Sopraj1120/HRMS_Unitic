using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Entities;
using HRMS.IRepository;
using HRMS.Iservice;
using System.Runtime.InteropServices;

namespace HRMS.Service
{
    public class WorkingDaysService : IWorkingDaysService
    {
        private readonly IWorkingDaysRepo _repo;
        private readonly IUserRepo _userRepo;

        public WorkingDaysService(IWorkingDaysRepo repo, IUserRepo userRepo)
        {
            _repo = repo;
            _userRepo = userRepo;
        }

        public async Task<WorkingDaysResponseDtos> AddWorkingDays(Guid UserId, WorkingDaysRequestDtos requestDtos)
        {
            var user = await _userRepo.GetUserById(UserId);
            if (user == null)
            {

                throw new Exception($"User with ID {UserId} not found.");
            }
            var workdays = new WorkingDays
            {
                Id = Guid.NewGuid(),
                UserId = UserId,
                UserName = user.FirstName,
                Role = user.Role,
                WeekWorkingDays = requestDtos.Weekdays.Select(x => new WeekWorkingDays
                {
                    Weekday = x
                }).ToList()


            };

            var data = await _repo.AddWorkingDays(workdays);
            var responce = new WorkingDaysResponseDtos
            {
                Id = data.Id,
                UserId = data.UserId,
                UserName = data.UserName,
                Role = data.Role.ToString(),
                Weekdays = data.WeekWorkingDays.Select(a => a.Weekday.ToString()).ToList(),
            };
            return responce;
        }

        public async Task<List<WorkingDaysResponseDtos>> GetAllWorkigDays()
        {
            try
            {
                var data = await _repo.GetAllWorkingdays();

                if (data == null || !data.Any())
                {
            
                    return new List<WorkingDaysResponseDtos>();
                }

                var response = data.Select(a => new WorkingDaysResponseDtos
                {
                    Id = a.Id,
                    UserId = a.UserId,
                    UserName = a.UserName,
                    Role = a.Role.ToString() ?? "Unknown",
                    Weekdays = a.WeekWorkingDays?.Select(b => b.Weekday.ToString()).ToList() ?? new List<string>(),
                }).ToList();

                return response;
            }
            catch (Exception ex)
            {
            
                throw new Exception("An error occurred while retrieving working days", ex);
            }
        }

        public async Task<WorkingDaysResponseDtos> GetWorkingDaysByUserId(Guid UserId)
        {
            var data = await _repo.GetWorkingDaysByUserId(UserId);
            var responce = new WorkingDaysResponseDtos
            {
                Id = data.Id,
                UserId = data.UserId,
                UserName = data.UserName,
                Role = data.Role.ToString(),
                Weekdays = data.WeekWorkingDays.Select(a => a.Weekday.ToString()).ToList()
            };
            return responce;
        }

        public async Task<WorkingDaysResponseDtos> UpdateWorkingdays(Guid userId, WorkingDaysRequestDtos workingDaysRequest)
        {

            var data = await _repo.GetWorkingDaysByUserId(userId);



            data.WeekWorkingDays = workingDaysRequest.Weekdays.Select(day => new WeekWorkingDays
            {
                Weekday = day
            }).ToList();

            var updatedWorkingDays = await _repo.UpdateWorkingdays(data);

            var response = new WorkingDaysResponseDtos
            {
                Id = updatedWorkingDays.Id,
                UserId = updatedWorkingDays.UserId,
                UserName = updatedWorkingDays.UserName,
                Role = updatedWorkingDays.Role.ToString(),
                Weekdays = updatedWorkingDays.WeekWorkingDays.Select(w => w.Weekday.ToString()).ToList()
            };

            return response;
        }

        public async Task deleteWorkingDays(Guid Id)
        {
            await _repo.deleteWorkingDays(Id);
        }

       

    }
}
