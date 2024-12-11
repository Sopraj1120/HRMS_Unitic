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

        public SalaryService(ISalaryRepository repository, IUserRepo userRepo, ILeaveTypeRepo leaveTypeRepo, ILeaveRequestrepo leaveRequestrepo,IWorkingDaysRepo workingDaysRepo, IHollyDayRepo hollyDayRepo)
        {
            _repository = repository;
            _userRepo = userRepo;
            _leaveTypeRepo = leaveTypeRepo;
            _leaveRequestrepo = leaveRequestrepo;
            _workingDaysRepo = workingDaysRepo;
            _hollyDayRepo = hollyDayRepo;
        }

        public async Task<SalaryResponceDtos> AddSalary(Guid userId, SalaryRequestDtos salaryRequestDtos)
        {
            var user = await _userRepo.GetUserById(userId);
            if (user == null)
                throw new KeyNotFoundException($"User with ID {userId} not found.");

           
            int workingDays = await GetWorkingDaysForMonth(userId, DateTime.Now.Year, DateTime.Now.Month);

  
            var dailyRate = salaryRequestDtos.BasicSalary / (workingDays*9); 
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


            var daysInMonth = DateTime.DaysInMonth(year, month);
            var allDatesInMonth = Enumerable.Range(1, daysInMonth)
                .Select(day => new DateTime(year, month, day))
                .ToList();

            
            var validWorkingDays = allDatesInMonth
                .Where(date => !holidays.Any(h => h.Date.Date == date.Date) &&
                               workingDays.WeekWorkingDays.Any(w => w.Weekday.ToString() == date.DayOfWeek.ToString()))  
                .ToList();

            return validWorkingDays.Count(); 
        }


        public async Task<List<SalaryResponceDtos>> GetAllsalaries()
        {
            var data = await _repository.GetAllsalaries();
            var responce = data.Select(x => new SalaryResponceDtos
            {
                Id = x.Id,
                UserName = x.UserName,
                UserId = x.UserId,
                Role = x.Role.ToString(),
                BasicSalary = x.BasicSalary,
                WorkingDays = x.WorkingDays,
                Deduction = x.Deduction,
                EPF = x.EPF,
                Etf = x.Etf,
                Allowances = x.Allowances,
                Bonus = x.Bonus,
                NetSalary = x.NetSalary,
                SalaryStatus = x.SalaryStatus.ToString()
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

        public async Task<SalaryResponceDtos> UpdateSalary(Guid id, SalaryRequestDtos salaryRequestDtos)
        {

            var existingSalary = await _repository.GetSalaryById(id);
            if (existingSalary == null)
                throw new KeyNotFoundException($"Salary with ID {id} not found.");


           


            existingSalary.BasicSalary = salaryRequestDtos.BasicSalary;
            existingSalary.SalaryStatus = salaryRequestDtos.SalaryStatus;
            existingSalary.WorkingDays = salaryRequestDtos.WorkingDays;
            existingSalary.Bonus = salaryRequestDtos.Bonus;
            existingSalary.Allowances = salaryRequestDtos.Allowances;
            existingSalary.NetSalary = salaryRequestDtos.BasicSalary + salaryRequestDtos.Bonus + salaryRequestDtos.Allowances - salaryRequestDtos.Deduction;
            existingSalary.Deduction = salaryRequestDtos.Deduction;

            var updatedSalary = await _repository.UpdateSalary(existingSalary);

            return new SalaryResponceDtos
            {
                Id = updatedSalary.Id,
                UserId = updatedSalary.UserId,
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
