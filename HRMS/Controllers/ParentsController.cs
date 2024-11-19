using HRMS.DTOs.RequestDtos;
using HRMS.Iservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentsController : ControllerBase
    {
        private readonly IParentService _parentservice;

        public ParentsController(IParentService parentservice)
        {
            _parentservice = parentservice;
        }

        [HttpPost]
        public async Task<IActionResult> AddParents(Guid Id, ParentsRequestDtos parentsRequestDtos)
        {
            var data = await _parentservice.AddParent(Id, parentsRequestDtos);
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetparentsByStudentId(Guid Id)
        {
            var data = await _parentservice.GetParentsByStudentId(Id);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteparents(Guid Id)
        {
            await _parentservice.DeleteParents(Id);
            return NoContent();
        }
    }
}
