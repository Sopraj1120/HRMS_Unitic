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


        public async Task<SalaryResponceDtos> AddSalary(Guid UserId, SalaryRequestDtos salaryRequestDtos)
        {
            var user = await _userRepo.GetUserById(UserId);

            //var leave = await _leaveTypeRepo.GetLeaveTypeById(salaryRequestDtos.LeaveTypeId);
            var workdays = salaryRequestDtos.WorkingDays;


            //if (leave.Name == ("No Pay Leave") )
            //{
            //    workdays -= leave.CountPerYear;
            //}   // Fetch user details
          
            if (user == null)
                throw new KeyNotFoundException($"User with ID {UserId} not found.");

            var leaveRequests = await _leaveRequestrepo.GetLeaveRequestByUserId(UserId);

            // Calculate working days default to 20
            int effectiveWorkingDays = 20;

            foreach (var leave in leaveRequests)
            {
                if (leave.AvailableLeaves < 0)
                {
                    effectiveWorkingDays -= Math.Abs(leave.AvailableLeaves);
                }
            }
            effectiveWorkingDays = Math.Max(effectiveWorkingDays, 0);
            if (effectiveWorkingDays < 0)
                effectiveWorkingDays = 0;


            // Fetch the count of "No Pay Leave" taken by the user
            var noPayLeaveTypes = await _leaveTypeRepo.GetLeaveTypeByName("No Pay Leave");
            int noPayLeaveCount = 0;
            if (noPayLeaveTypes != null)
            {
                noPayLeaveCount = await _repository.GetNoPayLeaveCount(UserId, noPayLeaveTypes.Id);
                effectiveWorkingDays -= noPayLeaveCount;
                effectiveWorkingDays = Math.Max(effectiveWorkingDays, 0); // Adjust again if necessary
            }
            var noPayLeaveTypeId = new Guid("7213a7a3-29ef-451a-80fc-9ea04769dad0");
            var leaveTypes = await _leaveTypeRepo.GetAllLeaveTypes();
            var noPayLeaveTypes = leaveTypes.FirstOrDefault(lt => lt.Name == "No Pay Leave");

            if (noPayLeaveTypes == null)
                throw new Exception("Leave type 'No Pay Leave' not found.");

            // Fetch the count of "No Pay Leave" taken by the user
            var noPayLeaveCount = await _repository.GetNoPayLeaveCount(UserId, noPayLeaveTypes.Id);
            // Calculate working days after deducting "No Pay Leave" days
            //var effectiveWorkingDays = salaryRequestDtos.WorkingDays - noPayLeaveCount;

            if (effectiveWorkingDays < 0)
                effectiveWorkingDays = 0; // Ensure working days don't become negative

            // Calculate deductions and salary components
            var dailyRate = salaryRequestDtos.BasicSalary / 20; // Assuming 20 working days in a month
            var deduction = dailyRate * noPayLeaveCount;
            var epf = salaryRequestDtos.BasicSalary * 0.08m; // Employee contribution (8%)
            var employerEpf = salaryRequestDtos.BasicSalary * 0.12m; // Employer contribution (12%)
            var etf = salaryRequestDtos.BasicSalary * 0.003m; // ETF (0.3%)

            var netSalary = salaryRequestDtos.BasicSalary
                            + salaryRequestDtos.Bonus
                            + salaryRequestDtos.Allowenss
                            - (deduction + epf + employerEpf + etf);

            var salary = new Salary
            {
                Id = Guid.NewGuid(),
                UserId = UserId,
                UserName = user.FirstName + " " + user.LastName,
                Role = user.Role,
                BasicSalary = salaryRequestDtos.BasicSalary,
                WorkingDays = salaryRequestDtos.WorkingDays ?? 20,
                Dedection = salaryRequestDtos.BasicSalary - ((salaryRequestDtos.BasicSalary / 20) * workdays),
                Etf = salaryRequestDtos.BasicSalary * 0.003m,
                EPF = salaryRequestDtos.BasicSalary * (0.08m + 0.12m),
                Bonus = salaryRequestDtos.Bonus,
                Allowenss = salaryRequestDtos.Allowenss,
                NetSalary = (salaryRequestDtos.BasicSalary
                 + salaryRequestDtos.Bonus
                 + salaryRequestDtos.Allowenss)
                - (salaryRequestDtos.BasicSalary - ((salaryRequestDtos.BasicSalary / 20) * workdays)
                   + (salaryRequestDtos.BasicSalary * 0.003m)
                   + (salaryRequestDtos.BasicSalary * (0.08m + 0.12m))),
                SalaryStatus = salaryRequestDtos.SalaryStatus

,
                
            };
            var data = await _repository.AddSalary(salary);
            var responce = new SalaryResponceDtos
            {
                Id = data.Id,
                UserId = data.UserId,
                UserName = data.UserName,
                Role = data.Role.ToString(),
                BasicSalary = data.BasicSalary,
                WorkingDays = data.WorkingDays,
                Dedection = data.Dedection,
                EPF = data.EPF,
                Etf = data.Etf,
                Allowenss = data.Allowenss,
                Bonus = data.Bonus,
                NetSalary = data.NetSalary,
                SalaryStatus = data.SalaryStatus.ToString(),

            };
            return responce;

        }
    }
}
