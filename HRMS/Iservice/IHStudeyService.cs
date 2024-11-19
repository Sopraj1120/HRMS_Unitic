using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;

namespace HRMS.Iservice
{
    public interface IHStudeyService
    {
        Task<HStudeiesResponseDtos> AddHStudy(Guid studentid, HStudiesRequestDtos requestDtos);
        Task<List<HStudeiesResponseDtos>> GetHStudyByStudentId(Guid studentId);
        Task DeleteHStudy(Guid Id);
    }
}
