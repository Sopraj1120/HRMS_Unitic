using HRMS.Entities;

namespace HRMS.IRepository
{
    public interface IHStudyRepo
    {
        Task<HigherStudies> AddHStudy(HigherStudies higherStudies);
        Task<List<HigherStudies>> GetHStudeyByStudentId(Guid studentId);
        Task DeleteHStudy(Guid Id);
    }
}
