using HRMS.DTOs.RequestDtos;
using HRMS.Iservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OlevelController : ControllerBase
    {
        private readonly IOlevelService _iolevel;

        public OlevelController(IOlevelService iolevel)
        {
            _iolevel = iolevel;
        }

        [HttpPost]
        public async Task<IActionResult> AddOlevel(Guid studentId, OLevalRequestDtos oLevalRequestDtos)
        {
            var data = await _iolevel.AddOlevel(studentId, oLevalRequestDtos);
            return Ok(data);
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetOlByStudentId (Guid Id)
        {
            var data = await _iolevel.GetOlByStudentId(Id);
            return Ok(data);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteOlevel (Guid Id)
        {
            await _iolevel.DeleteOl(Id);
            return NoContent();
        }
    }
}
