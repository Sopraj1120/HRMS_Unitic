using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;

namespace HRMS.Iservice
{
    public interface IUserHigherStudiesSevice
    {
        Task<UserHigherStudiesResponseDtos> AddHStudy(Guid userId, UserHigherStudiesRequestdtos userHigherStudies);
        Task<List<UserHigherStudiesResponseDtos>> GetHStudyByUserId(Guid UderId);
        Task DeleteHStudy(Guid Id);
    }
}
