using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Entities;
using HRMS.IRepository;
using HRMS.Iservice;
using System.Xml.Linq;

namespace HRMS.Service
{
    public class AdderssService : IAddressService
    {
        private readonly IAddressRepo _addressrepo;

        public AdderssService(IAddressRepo addressrepo)
        {
            _addressrepo = addressrepo;
        }

        public async Task<AddresResponseDto> AddAddress (Guid studentId,AddressRequestDtos addressrequest)
        {
            var address = new Address
            {
                Id = Guid.NewGuid(),
                StudentId = studentId,
                HouseNumber = addressrequest.HouseNumber,
                Street = addressrequest.Street,
                Lane = addressrequest.Lane,
                City = addressrequest.City,
                State = addressrequest.State,
                PostalCode = addressrequest.PostalCode,
                Country = addressrequest.Country,

            };

            var data = await _addressrepo.AddAddress(address);
            var resAddress = new AddresResponseDto
            {
                Id = data.Id,
                HouseNumber = data.HouseNumber,
                Street = data.Street,
                Lane = data.Lane,
                City = data.City,
                State = data.State,
                PostalCode = data.PostalCode,
                Country = data.Country
            };
            return resAddress;
        }

        public async Task<List<AddresResponseDto>> GetAddressByStudentId(Guid studentId)
        {
            var data = await _addressrepo.GetAddressByStudentId(studentId);
            var resAddress = data.Select(a => new AddresResponseDto
            {
                Id = a.Id,
                HouseNumber= a.HouseNumber,
                Street = a.Street,
                Lane= a.Lane,
                City = a.City,
                State = a.State,
                PostalCode = a.PostalCode,
                Country = a.Country
            }).ToList();
            return resAddress;
        }

        public async Task DeleteAddress(Guid Id)
        {
            await _addressrepo.DeleteAddress(Id);
        }
    }
}
