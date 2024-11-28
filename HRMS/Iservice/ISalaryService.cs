using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;

namespace HRMS.Iservice
{
    public interface ISalaryService
    {
        Task<SalaryResponceDtos> AddSalary(Guid UserId, SalaryRequestDtos salaryRequestDtos);
    }
}
