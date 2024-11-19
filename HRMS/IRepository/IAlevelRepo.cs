using HRMS.Entities;

namespace HRMS.IRepository
{
    public interface IAlevelRepo
    {
        Task<ALevel> AddAlevel(ALevel alevel);
        Task<List<ALevel>> GetAlByStudentId(Guid studentId);
        Task DeleteAls(Guid Id);
    }
}
