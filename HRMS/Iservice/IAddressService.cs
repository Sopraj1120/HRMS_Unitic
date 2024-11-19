using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;

namespace HRMS.Iservice
{
    public interface IAddressService
    {
        Task<AddresResponseDto> AddAddress(Guid studentId, AddressRequestDtos addressrequest);
        Task<List<AddresResponseDto>> GetAddressByStudentId(Guid studentId);
        Task DeleteAddress(Guid Id);
    }
}
