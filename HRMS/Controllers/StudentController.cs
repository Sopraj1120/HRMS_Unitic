using HRMS.DTOs.RequestDtos;
using HRMS.Iservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        [Route("AddStudent")]

        public async Task<IActionResult> AddStudent(StudentRequestDtos  studentRequestDtos)
        {
            var data = await _studentService.AddSudent(studentRequestDtos);
            return Ok(data);
        }

        [HttpGet]

        public async Task<IActionResult> GetAllStudents ()
        {
            var data = await _studentService.GetAllStudents();
            return Ok(data);
        }

        [HttpGet("{Id}")]

        public async Task<IActionResult> GetStudentById(Guid Id)
        {
            var data = _studentService.GetStudentById(Id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPut("{Id}")]

        public async Task<IActionResult> UpdateStudent (Guid Id ,StudentRequestDtos studentRequestDtos)
        {
            var data = await _studentService.UpdateStudent(Id, studentRequestDtos);
            return Ok(data);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteStudent(Guid Id)
        {
             await _studentService.DeleteStudent(Id);
            return NoContent();
        }

    }
}
