using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;
using HRMS.Entities;
using HRMS.IRepository;
using HRMS.Iservice;

namespace HRMS.Service
{
    public class ParentService : IParentService
    {
        private readonly IParentrepo _parentrepo;

        public ParentService(IParentrepo parentrepo)
        {
            _parentrepo = parentrepo;
        }

        public async Task<ParentsResponseDtos> AddParent (Guid studentId, ParentsRequestDtos parentsRequestDtos)
        {
            var parent = new Parents
            {
                Id = Guid.NewGuid(),
                StudentId = studentId,
                FirstName = parentsRequestDtos.FirstName,
                LastName = parentsRequestDtos.LastName,
                Job = parentsRequestDtos.Job,
                ContactNo = parentsRequestDtos.ContactNo,
                Address = parentsRequestDtos.Address
            };

            var data = await _parentrepo.AddParents(parent);
            var resstu = new ParentsResponseDtos
            {
                Id = data.Id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Job = data.Job,
                ContactNo = data.ContactNo,
                Address = data.Address
            };
            return resstu;
        }

        public async Task<List<ParentsResponseDtos>> GetParentsByStudentId(Guid studentId)
        {
            var data = await _parentrepo.GetParentsByStudentId(studentId);
            var resstu = data.Select(p => new ParentsResponseDtos
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Job = p.Job,
                ContactNo = p.ContactNo,
                Address = p.Address
            }).ToList();
            return resstu;
        }

        public async Task DeleteParents(Guid Id)
        {
            await _parentrepo.DeleteParents(Id);
        }
    }
}
