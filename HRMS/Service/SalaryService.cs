using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Entities;
using HRMS.IRepository;
using HRMS.Iservice;
using HRMS.Repository;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Service
{
    public class SalaryService : ISalaryService
    {
        private readonly ISalaryRepository _repository;
        private readonly IUserRepo _userRepo;
        private readonly ILeaveTypeRepo _leaveTypeRepo;
        private readonly ILeaveRequestrepo _leaveRequestrepo;
        private readonly IHollyDayRepo _hollyDayRepo;
        private readonly IWorkingDaysRepo _workingDaysRepo;

        public SalaryService(ISalaryRepository repository, IUserRepo userRepo, ILeaveTypeRepo leaveTypeRepo, ILeaveRequestrepo leaveRequestrepo, IWorkingDaysRepo workingDaysRepo, IHollyDayRepo hollyDayRepo)
        {
            _repository = repository;
            _userRepo = userRepo;
            _leaveTypeRepo = leaveTypeRepo;
            _leaveRequestrepo = leaveRequestrepo;
            _workingDaysRepo = workingDaysRepo;
            _hollyDayRepo = hollyDayRepo;
        }

        private bool IsWorkingDay(WorkingDays workingDays, DayOfWeek dayOfWeek)
        {
            var weekDays = workingDays.WeekDays.FirstOrDefault();
            if (weekDays == null)
            {
                return false; 
            }

            return dayOfWeek switch
            {
                DayOfWeek.Monday => weekDays.Monday,
                DayOfWeek.Tuesday => weekDays.Tuesday,
                DayOfWeek.Wednesday => weekDays.Wednesday,
                DayOfWeek.Thursday => weekDays.Thursday,
                DayOfWeek.Friday => weekDays.Friday,
                DayOfWeek.Saturday => weekDays.Saturday,
                DayOfWeek.Sunday => weekDays.Sunday,
                _ => false
            };
        }
        public async Task<SalaryResponceDtos> AddSalary(Guid userId, SalaryRequestDtos salaryRequestDtos)
        {
            var user = await _userRepo.GetUserById(userId);
            if (user == null)
                throw new KeyNotFoundException($"User with ID {userId} not found.");


            int workingDays = await GetWorkingDaysForMonth(userId, DateTime.Now.Year, DateTime.Now.Month);


            var dailyRate = salaryRequestDtos.BasicSalary / (workingDays * 9);
            var deduction = salaryRequestDtos.Deduction;
            var epf = salaryRequestDtos.BasicSalary * 0.08m;
            var employerEpf = salaryRequestDtos.BasicSalary * 0.12m;
            var etf = salaryRequestDtos.BasicSalary * 0.003m;
            var totalDeductions = deduction + epf + employerEpf + etf;


            var netSalary = salaryRequestDtos.BasicSalary
                            + salaryRequestDtos.Bonus
                            + salaryRequestDtos.Allowances
                            - totalDeductions;

            var salary = new Salary
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                User_Id = user.UsersId,
                UserName = $"{user.FirstName} {user.LastName}",
                Role = user.Role,
                BasicSalary = salaryRequestDtos.BasicSalary,
                WorkingDays = workingDays,
                Deduction = deduction,
                Etf = etf,
                EPF = epf + employerEpf,
                Bonus = salaryRequestDtos.Bonus,
                Allowances = salaryRequestDtos.Allowances,
                NetSalary = netSalary,
                SalaryStatus = salaryRequestDtos.SalaryStatus
            };


            var savedSalary = await _repository.AddSalary(salary);

            return new SalaryResponceDtos
            {
                Id = savedSalary.Id,
                UserId = savedSalary.UserId,
                User_Id = savedSalary.User_Id,
                UserName = savedSalary.UserName,
                Role = savedSalary.Role.ToString(),
                BasicSalary = savedSalary.BasicSalary,
                WorkingDays = savedSalary.WorkingDays,
                Deduction = savedSalary.Deduction,
                EPF = savedSalary.EPF,
                Etf = savedSalary.Etf,
                Allowances = savedSalary.Allowances,
                Bonus = savedSalary.Bonus,
                NetSalary = savedSalary.NetSalary,
                SalaryStatus = savedSalary.SalaryStatus.ToString()
            };
        }



        public async Task<int> GetWorkingDaysForMonth(Guid userId, int year, int month)
        {
            
            var holidays = await _hollyDayRepo.GatAllHollyDays() ?? new List<HollyDays>();
            var workingDays = await _workingDaysRepo.GetWorkingDaysByUserId(userId);

            if (workingDays == null || workingDays.WeekDays == null || !workingDays.WeekDays.Any())
            {
                throw new InvalidOperationException("Working days are not defined for this user.");
            }

            var daysInMonth = DateTime.DaysInMonth(year, month);
            var allDatesInMonth = Enumerable.Range(1, daysInMonth)
                .Select(day => new DateTime(year, month, day))
                .ToList();

         
            var validWorkingDays = allDatesInMonth
                .Where(date => !holidays.Any(h => h.Date.Date == date.Date) &&
                               IsWorkingDay(workingDays, date.DayOfWeek))
                .ToList();

       
            return validWorkingDays.Count;
        }




        public async Task<List<SalaryResponceDtos>> GetAllsalaries()
        {
            var users = await _userRepo.GetAllUsers();
            var data = await _repository.GetAllsalaries();

            var responce = users.Select(x =>
            {
                var userSalary = data.FirstOrDefault(a => a.UserId == x.Id);

                if (userSalary == null)
                {
                    return new SalaryResponceDtos
                    {
                        Id = Guid.NewGuid(),
                        UserName = x.FirstName,
                        UserId = x.Id,
                        User_Id = x.UsersId,
                        Role = x.Role.ToString(),
                        BasicSalary = null,
                        WorkingDays = null,
                        Deduction = null,
                        EPF = null,
                        Etf = null,
                        Allowances = null,
                        Bonus = null,
                        NetSalary = null,
                        SalaryStatus = null

                    };
                }
                return new SalaryResponceDtos
                {
                    Id = userSalary.Id,
                    UserName = userSalary.UserName,
                    UserId = userSalary.UserId,
                    User_Id = userSalary.User_Id,
                    Role = userSalary.Role.ToString(),
                    BasicSalary = userSalary.BasicSalary,
                    WorkingDays = userSalary.WorkingDays,
                    Deduction = userSalary.Deduction,
                    EPF = userSalary.EPF,
                    Etf = userSalary.Etf,
                    Allowances = userSalary.Allowances,
                    Bonus = userSalary.Bonus,
                    NetSalary = userSalary.NetSalary,
                    SalaryStatus = userSalary.SalaryStatus.ToString()
                };
            }).ToList();
            return responce;
        }

        public async Task<SalaryResponceDtos> GetSalaryById(Guid Id)
        {
            var data = await _repository.GetSalaryById(Id);

            var responce = new SalaryResponceDtos
            {
                Id = data.Id,
                UserId = data.UserId,
                User_Id = data.User_Id,
                UserName = data.UserName,
                Role = data.Role.ToString(),
                BasicSalary = data.BasicSalary,
                WorkingDays = data.WorkingDays,
                Deduction = data.Deduction,
                EPF = data.EPF,
                Etf = data.Etf,
                Allowances = data.Allowances,
                Bonus = data.Bonus,
                NetSalary = data.NetSalary,
                SalaryStatus = data.SalaryStatus.ToString()

            };
            return responce;
        }

        public async Task<SalaryResponceDtos> GetSalaryByUserId(Guid UserId)
        {
            var data = await _repository.GetSalaryByUserId(UserId);

            var responce = new SalaryResponceDtos
            {
                Id = data.Id,
                UserId = data.UserId,
                User_Id = data.User_Id,
                UserName = data.UserName,
                Role = data.Role.ToString(),
                BasicSalary = data.BasicSalary,
                WorkingDays = data.WorkingDays,
                Deduction = data.Deduction,
                EPF = data.EPF,
                Etf = data.Etf,
                Allowances = data.Allowances,
                Bonus = data.Bonus,
                NetSalary = data.NetSalary,
                SalaryStatus = data.SalaryStatus.ToString()

            };
            return responce;
        }

        public async Task<SalaryResponceDtos> UpdateSalary(Guid userId, SalaryRequestDtos salaryRequestDtos)
        {

            var existingSalary = await _repository.GetSalaryByUserId(userId);
            if (existingSalary == null)
                throw new KeyNotFoundException($"Salary with ID {userId} not found.");





            existingSalary.BasicSalary = salaryRequestDtos.BasicSalary;
            existingSalary.SalaryStatus = salaryRequestDtos.SalaryStatus;
            existingSalary.Bonus = salaryRequestDtos.Bonus;
            existingSalary.Allowances = salaryRequestDtos.Allowances;
            existingSalary.NetSalary = salaryRequestDtos.BasicSalary + salaryRequestDtos.Bonus + salaryRequestDtos.Allowances - salaryRequestDtos.Deduction;
            existingSalary.Deduction = salaryRequestDtos.Deduction;

            var updatedSalary = await _repository.UpdateSalary(existingSalary);

            return new SalaryResponceDtos
            {
                Id = updatedSalary.Id,
                UserId = updatedSalary.UserId,
                User_Id = updatedSalary.User_Id,
                UserName = updatedSalary.UserName,
                Role = updatedSalary.Role.ToString(),
                BasicSalary = updatedSalary.BasicSalary,
                WorkingDays = updatedSalary.WorkingDays,
                Deduction = updatedSalary.Deduction,
                EPF = updatedSalary.EPF,
                Etf = updatedSalary.Etf,
                Allowances = updatedSalary.Allowances,
                Bonus = updatedSalary.Bonus,
                NetSalary = updatedSalary.NetSalary,
                SalaryStatus = updatedSalary.SalaryStatus.ToString()
            };
        }





    }
}
