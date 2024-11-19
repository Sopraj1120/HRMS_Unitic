using HRMS.Entities;

namespace HRMS.IRepository
{
    public interface IOlevelRepo
    {
        Task<OLevel> AddOlevel(OLevel olevel);
        Task<List<OLevel>> GetOLevelByStudentId(Guid studentId);
        Task DeleteOlevels(Guid Id);
    }
}
