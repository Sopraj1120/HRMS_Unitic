using HRMS.Entities;

namespace HRMS.IRepository
{
    public interface IWorkingDaysRepo
    {
        Task<WorkingDays> AddWorkingDays(WorkingDays workingDays);
        Task<WorkingDays> GetWorkingDaysByUserId(Guid UserId);
        Task<WorkingDays> UpdateWorkingdays(WorkingDays workingDays);
        Task deleteWorkingDays(Guid Id);
    }
}
