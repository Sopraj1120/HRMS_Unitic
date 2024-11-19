using HRMS.DTOs.RequestDtos;
using HRMS.Iservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressservice;

        public AddressController(IAddressService addressservice)
        {
            _addressservice = addressservice;
        }

        [HttpPost]
        public async Task<IActionResult> AddAddress(Guid StudentId, AddressRequestDtos AddressRequestDtos)
        {
            var data = await _addressservice.AddAddress(StudentId, AddressRequestDtos);
            return Ok(data);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetAddresssByStudentId(Guid id)
        {
            var data = await _addressservice.GetAddressByStudentId(id);
            return Ok(data);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteAddress(Guid id)
        {
            await _addressservice.DeleteAddress(id);
            return NoContent();
        }
    }
}
