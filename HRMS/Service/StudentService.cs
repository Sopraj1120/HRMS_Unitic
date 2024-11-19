using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Entities;
using HRMS.IRepository;
using HRMS.Iservice;

namespace HRMS.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepo _studentrepo;

        public StudentService(IStudentRepo studentrepo)
        {
            _studentrepo = studentrepo;
        }


        public async Task<StudentResponseDtos> AddSudent(StudentRequestDtos studentRequestDtos)
        {
            var student = new Students
            {
                FirstName = studentRequestDtos.FirstName,
                LastName = studentRequestDtos.LastName,
                DateOfBirth = studentRequestDtos.DateOfBirth,
                Nic = studentRequestDtos.Nic,
                Email = studentRequestDtos.Email,
                MaritalStatus = studentRequestDtos.MaritalStatus,
                Mobile = studentRequestDtos.Mobile,
                
               
            };

            var data = await _studentrepo.AddStudent(student);
            var resStudents = new StudentResponseDtos
            {
                Id = data.Id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                DateOfBirth = data.DateOfBirth,
                Nic = data.Nic,
                Email = data.Email,
                MaritalStatus = data.MaritalStatus,
                Mobile = data.Mobile,
                IsDeleted = data.IsDeleted,
                Parents = data.Parents.Select(x => new ParentsResponseDtos
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Job = x.Job,
                    ContactNo = x.ContactNo,
                    Address = x.Address
                }).ToList(),
               
            };
            return resStudents;

        }

       public async Task<List<StudentResponseDtos>> GetAllStudents()
        {
            var data = await _studentrepo.GetAllStudents();

            var resstu = data.Select(s => new StudentResponseDtos
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                DateOfBirth = s.DateOfBirth,
                Nic = s.Nic,
                Email = s.Email,
                MaritalStatus = s.MaritalStatus,
                Mobile = s.Mobile,
                IsDeleted = s.IsDeleted,
                Parents = s.Parents.Select(p => new ParentsResponseDtos
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Job = p.Job,
                    ContactNo = p.ContactNo,
                    Address = p.Address
                }).ToList()

            }).ToList();
            return resstu;
        }


        public async Task<StudentResponseDtos> GetStudentById (Guid Id)
        {
            var data = await _studentrepo.GetStudentById(Id);

            if (data == null) return null;

            var resstu = new StudentResponseDtos
            {
                Id = data.Id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                DateOfBirth = data.DateOfBirth,
                Nic = data.Nic,
                Email = data.Email,
                MaritalStatus = data.MaritalStatus,
                Mobile = data.Mobile,
                IsDeleted = data.IsDeleted,
                Parents = data.Parents.Select(p => new ParentsResponseDtos
                {
                    Id= p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Job = p.Job,
                    ContactNo = p.ContactNo,
                    Address = p.Address
                }).ToList(),
            };
            return resstu;
        }

        public async Task<StudentResponseDtos> UpdateStudent(Guid Id, StudentRequestDtos studentRequestDtos)
        {
            var student = new Students
            {
                FirstName = studentRequestDtos.FirstName,
                LastName = studentRequestDtos.LastName,
                DateOfBirth = studentRequestDtos.DateOfBirth,
                Nic = studentRequestDtos.Nic,
                Email = studentRequestDtos.Email,
                MaritalStatus = studentRequestDtos.MaritalStatus,
                Mobile = studentRequestDtos.Mobile

            };

            var data = await _studentrepo.UpdateStudent(student);

            var resstu = new StudentResponseDtos
            {
                Id = data.Id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                DateOfBirth = data.DateOfBirth,
                Nic = data.Nic,
                Email = data.Email,
                MaritalStatus = data.MaritalStatus,
                Mobile = data.Mobile,
                IsDeleted = data.IsDeleted,
                Parents = data.Parents.Select(p => new ParentsResponseDtos
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Job = p.Job,
                    ContactNo = p.ContactNo,
                    Address = p.Address
                }).ToList()
            };
            return resstu;
        }

        public async Task DeleteStudent(Guid Id)
        {
            await _studentrepo.DeleteStudent(Id);
        }
    }
}
