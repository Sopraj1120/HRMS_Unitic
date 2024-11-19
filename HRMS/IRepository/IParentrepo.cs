using HRMS.Entities;

namespace HRMS.IRepository
{
    public interface IParentrepo
    {
        Task<Parents> AddParents(Parents parents);
        Task<List<Parents>> GetParentsByStudentId(Guid studentId);
        Task DeleteParents(Guid Id);
    }
}
