using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Entities;

namespace HRMS.Iservice
{
    public interface IWorkingDaysService
    {
        Task<WorkingDaysResponseDtos> AddWorkingDays(Guid UserId, WorkingDaysRequestDtos requestDtos);
        Task<WorkingDaysResponseDtos> GetWorkingDaysByUserId(Guid UserId);
        Task<WorkingDaysResponseDtos> UpdateWorkingdays(Guid userId, WorkingDaysRequestDtos workingDaysRequest);
        Task deleteWorkingDays(Guid Id);
    }
}
