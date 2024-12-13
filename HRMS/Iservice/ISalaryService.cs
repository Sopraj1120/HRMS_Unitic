using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;

namespace HRMS.Iservice
{
    public interface ISalaryService
    {
        Task<SalaryResponceDtos> AddSalary(Guid UserId, SalaryRequestDtos salaryRequestDtos);
        Task<int> GetWorkingDaysForMonth(Guid userId, int year, int month);
        Task<List<SalaryResponceDtos>> GetAllsalaries();
        Task<SalaryResponceDtos> GetSalaryById(Guid Id);
        Task<SalaryResponceDtos> GetSalaryByUserId(Guid UserId);
        Task<SalaryResponceDtos> UpdateSalary(Guid userId, SalaryRequestDtos salaryRequestDtos);
    }
}
