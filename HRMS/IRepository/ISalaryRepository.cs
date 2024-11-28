using HRMS.Entities;

namespace HRMS.IRepository
{
    public interface ISalaryRepository
    {
        Task<Salary> AddSalary(Salary salary);
        Task<List<Salary>> GetAllsalaries();
        Task<Salary> GetSalaryById(Guid Id);
        Task<Salary> GetSalaryByUserId(Guid UserId);
        Task<Salary> UpdateSalary(Salary salary);
        Task<int> GetNoPayLeaveCount(Guid userId, Guid leaveTypeId);
    }
}
