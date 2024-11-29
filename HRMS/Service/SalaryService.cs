using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Entities;
using HRMS.IRepository;
using HRMS.Iservice;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Service
{
    public class SalaryService : ISalaryService
    {
        private readonly ISalaryRepository _repository;
        private readonly IUserRepo _userRepo;
        private readonly ILeaveTypeRepo _leaveTypeRepo;
        private readonly ILeaveRequestrepo _leaveRequestrepo;

        public SalaryService(ISalaryRepository repository, IUserRepo userRepo, ILeaveTypeRepo leaveTypeRepo, ILeaveRequestrepo leaveRequestrepo)
        {
            _repository = repository;
            _userRepo = userRepo;
            _leaveTypeRepo = leaveTypeRepo;
            _leaveRequestrepo = leaveRequestrepo;
        }

        public async Task<SalaryResponceDtos> AddSalary(Guid userId, SalaryRequestDtos salaryRequestDtos)
        {
     
            var user = await _userRepo.GetUserById(userId);
            if (user == null)
                throw new KeyNotFoundException($"User with ID {userId} not found.");

        
            var noPayLeaveType = await _leaveTypeRepo.GetLeaveTypeByName("No Pay Leave");
            if (noPayLeaveType == null)
                throw new Exception("'No Pay Leave' type not found.");

          
            int noPayLeaveCount = await _repository.GetNoPayLeaveCount(userId, noPayLeaveType.Id);

        
            int workingDays = salaryRequestDtos.WorkingDays > 0
                              ? salaryRequestDtos.WorkingDays
                              : 20;

           
            workingDays -= noPayLeaveCount;
            workingDays = Math.Max(workingDays, 0); 

    
            var dailyRate = salaryRequestDtos.BasicSalary / 20m; 
            var deductions = dailyRate * noPayLeaveCount;
            var epf = salaryRequestDtos.BasicSalary * 0.08m; 
            var employerEpf = salaryRequestDtos.BasicSalary * 0.12m; 
            var etf = salaryRequestDtos.BasicSalary * 0.003m; 
            var totalDeductions = deductions + epf + employerEpf + etf;

     
            var netSalary = salaryRequestDtos.BasicSalary
                            + salaryRequestDtos.Bonus
                            + salaryRequestDtos.Allowenss
                            - totalDeductions;

            var salary = new Salary
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                UserName = $"{user.FirstName} {user.LastName}",
                Role = user.Role,
                BasicSalary = salaryRequestDtos.BasicSalary,
                WorkingDays = workingDays,
                Dedection = deductions,
                Etf = etf,
                EPF = epf + employerEpf,
                Bonus = salaryRequestDtos.Bonus,
                Allowenss = salaryRequestDtos.Allowenss,
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
                Dedection = savedSalary.Dedection,
                EPF = savedSalary.EPF,
                Etf = savedSalary.Etf,
                Allowenss = savedSalary.Allowenss,
                Bonus = savedSalary.Bonus,
                NetSalary = savedSalary.NetSalary,
                SalaryStatus = savedSalary.SalaryStatus.ToString()
            };
        }


    }
}
