using HRMS.Entities;

namespace HRMS.IRepository
{
    public interface IAddressRepo
    {
        Task<Address> AddAddress(Address address);
        Task<List<Address>> GetAddressByStudentId(Guid studentId);
        Task DeleteAddress(Guid Id);
    }
}
