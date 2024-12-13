using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Entities;

namespace HRMS.Iservice
{
    public interface IWorkingDaysService
    {
        
        Task<WorkingDaysResponseDtos> AddWorkingDays(Guid userId, WorkingDaysRequestDtos requestDtos);

        Task<List<WorkingDaysResponseDtos>> GetAllWorkingDays();

        Task<WorkingDaysResponseDtos> GetWorkingDaysByUserId(Guid userId);
   
        Task<WorkingDaysResponseDtos> UpdateWorkingDays(Guid userId, WorkingDaysRequestDtos requestDto);
        Task DeleteWorkingDays(Guid id);
    }
}
