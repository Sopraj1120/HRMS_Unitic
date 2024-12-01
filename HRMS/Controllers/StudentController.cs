using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
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
        private readonly IAddressService _addressService;
        private readonly IParentService _parentService;
        private readonly IOlevelService _levelService;
        private readonly IAlevelService _alevelService;
        private readonly IHStudeyService _hStudeyService;
        private readonly IExperianceService _experianceService;

        public StudentController(IStudentService studentService, IAddressService addressService, 
            IParentService parentService,IOlevelService olevelService , IAlevelService alevelService, 
            IHStudeyService hStudeyService, IExperianceService experianceService)
        {
            _studentService = studentService;
            _addressService = addressService;  
            _parentService = parentService;
            _levelService = olevelService;
            _alevelService = alevelService;
            _hStudeyService = hStudeyService;
            _experianceService = experianceService;
        }

        [HttpPost]
        [Route("AddStudent")]

        public async Task<IActionResult> AddStudent(StudentRequestDtos  studentRequestDtos)
        {
            var data = await _studentService.AddSudent(studentRequestDtos);
            return Ok(data);
        }

        [HttpGet]
        [Route("Get_All_Students")]

        public async Task<IActionResult> GetAllStudents (int pageNumber, int pageSize)
        {
            var data = await _studentService.GetAllStudents(pageNumber, pageSize);
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

        // Student Address ------------------------------------------------------------------------------------------------------------------

        [HttpPost]
        [Route("Add_Student_address")]
        public async Task<IActionResult> AddAddress(Guid studentId, AddressRequestDtos addressrequest)
        {
            var data = await _addressService.AddAddress(studentId, addressrequest);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpGet("Get_address_by_StudentID")]
        public async Task<IActionResult> GetAddressByStudentId(Guid studentId)
        {
            var data = await _addressService.GetAddressByStudentId(studentId);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpDelete("Delete_Student_Addresss")]
        public async Task<IActionResult> DeleteAddress(Guid Id)
        {
            await _addressService.DeleteAddress(Id);
            return NoContent();
        }

        // student Parents  -----------------------------------------------------------------------------------------------------------------

        [HttpPost("Add_Student_Parents")]
        public async Task<IActionResult> AddParent(Guid studentId, ParentsRequestDtos parentsRequestDtos)
        {
            var data = await _parentService.AddParent(studentId, parentsRequestDtos);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpGet("Get_Parents_by_StudentId")]
        public async Task<IActionResult> GetParentsByStudentId(Guid studentId)
        {
            var data = await _parentService.GetParentsByStudentId(studentId);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpDelete("Delete_Student_Parent")]
        public async Task<IActionResult> DeleteParents(Guid Id)
        {
            await _parentService.DeleteParents(Id);
            return NoContent();
        }

        //studenrt OLevel ___________________________________________________________________________________________________________________

        [HttpPost("Add_Student_Olevel")]
        public async Task<IActionResult> AddOlevel(Guid studentId, OLevalRequestDtos oLevalRequestDtos)
        {
            var data = await _levelService.AddOlevel(studentId, oLevalRequestDtos);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpGet("Get_Olevel_by_StudentId")]
        public async Task<IActionResult> GetOlByStudentId(Guid studentId)
        {
            var data = await _levelService.GetOlByStudentId(studentId);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpDelete("Delete_Student_Olevel")]
        public async Task<IActionResult> DeleteOl(Guid Id)
        {
            await _levelService.DeleteOl(Id);
            return NoContent() ;    
        }

        // Student ALevel ___________________________________________________________________________________________________________________

        [HttpPost("Add_Student_Alevel")]
        public async Task<IActionResult> AddAlevels(Guid studentId, ALevelRequestDtos requestDtos)
        {
            var data = await _alevelService.AddAlevels(studentId, requestDtos);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpGet ("Get_Alevel_by_StudentId")]
        public async Task<IActionResult> GetAlevelByStudentId(Guid StudentId)
        {
            var data = await _alevelService.GetAlevelByStudentId(StudentId);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpDelete("Delete_Student_Alevel")]
        public async Task<IActionResult> DeleteAlevel(Guid Id)
        {
             await _alevelService.DeleteAlevel(Id);
           
            return NoContent();
        }

        // Student Higher-Studies ___________________________________________________________________________________________________________

        [HttpPost("Add_Student_HigherStudy")]
        public async Task<IActionResult> AddHStudy(Guid studentid, HStudiesRequestDtos requestDtos)
        {
            var data = await _hStudeyService.AddHStudy(studentid, requestDtos);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpGet("Get_HigherStudy_by_StudentId")]
        public async Task<IActionResult> GetHStudyByStudentId(Guid studentId)
        {
            var data = await _hStudeyService.GetHStudyByStudentId(studentId);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpDelete("Delete_Student_HigherStudy")]
        public async Task<IActionResult> DeleteHStudy(Guid Id)
        {
            await _hStudeyService.DeleteHStudy(Id);
            return NoContent();
        }

        // Student Experiance _______________________________________________________________________________________________________________

        [HttpPost("Add_Student_Experiance")]
        public async Task<IActionResult> AddExperiance(Guid studentId, ExperianceRequestDtos requestDtos)
        {
            var data = await _experianceService.AddExperiance(studentId, requestDtos);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpGet("Get_Experiance_By_StudentId")]
        public async Task<IActionResult> GetExperianceByStudentId(Guid studentId)
        {
            var data = await _experianceService.GetExperianceByStudentId(studentId);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpDelete("Delete_Student_Experiance")]
        public async Task<IActionResult> DeleteExperiance(Guid Id)
        {
            await _experianceService.DeleteExperiance(Id);
            return NoContent();
        }
    }
}
