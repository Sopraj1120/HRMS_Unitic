using HRMS.Entities;

namespace HRMS.IRepository
{
    public interface ISuperAdminRepo
    {
        Task<SuperAdmin> RegisterSuperAdmin(SuperAdmin admin);
        Task<SuperAdmin> LoginSuperAdmin(string Email);
    }
}

