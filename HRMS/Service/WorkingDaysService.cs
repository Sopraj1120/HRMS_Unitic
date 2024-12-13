using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Entities;
using HRMS.IRepository;
using HRMS.Iservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<WorkingDaysResponseDtos> AddWorkingDays(Guid userId, WorkingDaysRequestDtos requestDtos)
        {
            var user = await _userRepo.GetUserById(userId);
            if (user == null)
            {
                throw new Exception($"User with ID {userId} not found.");
            }

            var workingDays = new WorkingDays
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                User_Id = user.UsersId,
                UserName = user.FirstName,
                Role = user.Role,
                WeekDays = requestDtos.Weekdays.Select(day => new WeekDays
                {
                    Monday = day.Monday,
                    Tuesday = day.Tuesday,
                    Wednesday = day.Wednesday,
                    Thursday = day.Thursday,
                    Friday = day.Friday,
                    Saturday = day.Saturday,
                    Sunday = day.Sunday
                }).ToList()
            };

            var savedData = await _repo.AddWorkingDays(workingDays);

            var response = new WorkingDaysResponseDtos
            {
                Id = savedData.Id,
                UserId = savedData.UserId,
                User_Id = savedData.User_Id,
                UserName = savedData.UserName,
                Role = savedData.Role.ToString(),
                Weekdays = savedData.WeekDays.Select(w => new List<string>
                {
                    w.Monday ? "Monday" : null,
                    w.Tuesday ? "Tuesday" : null,
                    w.Wednesday ? "Wednesday" : null,
                    w.Thursday ? "Thursday" : null,
                    w.Friday ? "Friday" : null,
                    w.Saturday ? "Saturday" : null,
                    w.Sunday ? "Sunday" : null
                }.Where(day => day != null).ToList()).SelectMany(x => x).ToList()
            };

            return response;
        }

        public async Task<List<WorkingDaysResponseDtos>> GetAllWorkingDays()
        {
            var users = await _userRepo.GetAllUsers();
            var workingDaysData = await _repo.GetAllWorkingdays();

            var response = users.Select(user =>
            {
                var userWorkingDays = workingDaysData.FirstOrDefault(wd => wd.UserId == user.Id);

                return new WorkingDaysResponseDtos
                {
                    Id = userWorkingDays?.Id ?? Guid.NewGuid(),
                    UserId = user.Id,
                    User_Id = user.UsersId,
                    UserName = user.FirstName,
                    Role = user.Role.ToString(),
                    Weekdays = userWorkingDays?.WeekDays.Select(w => new List<string>
                    {
                        w.Monday ? "Monday" : null,
                        w.Tuesday ? "Tuesday" : null,
                        w.Wednesday ? "Wednesday" : null,
                        w.Thursday ? "Thursday" : null,
                        w.Friday ? "Friday" : null,
                        w.Saturday ? "Saturday" : null,
                        w.Sunday ? "Sunday" : null
                    }.Where(day => day != null).ToList()).SelectMany(x => x).ToList()
                };
            }).ToList();

            return response;
        }

        public async Task<WorkingDaysResponseDtos> GetWorkingDaysByUserId(Guid userId)
        {
            var workingDays = await _repo.GetWorkingDaysByUserId(userId);

            if (workingDays == null)
            {
                return null;
            }

            return new WorkingDaysResponseDtos
            {
                Id = workingDays.Id,
                UserId = workingDays.UserId,
                User_Id = workingDays.User_Id,
                UserName = workingDays.UserName,
                Role = workingDays.Role.ToString(),
                Weekdays = workingDays.WeekDays.Select(w => new List<string>
                {
                    w.Monday ? "Monday" : null,
                    w.Tuesday ? "Tuesday" : null,
                    w.Wednesday ? "Wednesday" : null,
                    w.Thursday ? "Thursday" : null,
                    w.Friday ? "Friday" : null,
                    w.Saturday ? "Saturday" : null,
                    w.Sunday ? "Sunday" : null
                }.Where(day => day != null).ToList()).SelectMany(x => x).ToList()
            };
        }

        public async Task<WorkingDaysResponseDtos> UpdateWorkingDays(Guid userId, WorkingDaysRequestDtos requestDtos)
        {
            var existingData = await _repo.GetWorkingDaysByUserId(userId);
            if (existingData == null) return null;

            existingData.WeekDays = requestDtos.Weekdays.Select(day => new WeekDays
            {
                Monday = day.Monday,
                Tuesday = day.Tuesday,
                Wednesday = day.Wednesday,
                Thursday = day.Thursday,
                Friday = day.Friday,
                Saturday = day.Saturday,
                Sunday = day.Sunday
            }).ToList();

            var updatedData = await _repo.UpdateWorkingdays(existingData);

            return new WorkingDaysResponseDtos
            {
                Id = updatedData.Id,
                UserId = updatedData.UserId,
                User_Id = updatedData.User_Id,
                UserName = updatedData.UserName,
                Role = updatedData.Role.ToString(),
                Weekdays = updatedData.WeekDays.Select(w => new List<string>
                {
                    w.Monday ? "Monday" : null,
                    w.Tuesday ? "Tuesday" : null,
                    w.Wednesday ? "Wednesday" : null,
                    w.Thursday ? "Thursday" : null,
                    w.Friday ? "Friday" : null,
                    w.Saturday ? "Saturday" : null,
                    w.Sunday ? "Sunday" : null
                }.Where(day => day != null).ToList()).SelectMany(x => x).ToList()
            };
        }

        public async Task DeleteWorkingDays(Guid id)
        {
            await _repo.deleteWorkingDays(id);
        }
    }
}
