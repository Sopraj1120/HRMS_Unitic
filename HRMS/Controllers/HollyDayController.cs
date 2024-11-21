using HRMS.DTOs.RequestDtos;
using HRMS.Iservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HollyDayController : ControllerBase
    {
        private readonly IHollydayService _hollydayService;

        public HollyDayController(IHollydayService hollydayService)
        {
            _hollydayService = hollydayService;
        }

        [HttpPost]
        public async Task<IActionResult> AddHollyDays(HollydaysRequestDtos hollydaysRequestDtos)
        {
            var data = await _hollydayService.AddHollydays(hollydaysRequestDtos);
            return Ok(data);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllHollyDays()
        {
            var data = await _hollydayService.GetAllHollyDays();
            return Ok(data);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetHollydayById(Guid Id)
        {
            var data = await _hollydayService.GetHollydayById(Id);
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> UpadteHollyDay(Guid Id, HollydaysRequestDtos hollydaysRequestDtos)
        {
            var data = await _hollydayService.UpdateHollyday(Id, hollydaysRequestDtos);
            return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteHollyDay(Guid Id)
        {
            await _hollydayService.DeleteHollyDay(Id);
            return NoContent();
        }
    }
}
