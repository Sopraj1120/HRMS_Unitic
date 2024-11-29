using HRMS.IRepository;
using HRMS.Iservice;
using System.Runtime.InteropServices;

namespace HRMS.Service
{
    public class WorkingDaysService : IWorkingDaysService
    {
        private readonly IWorkingDaysRepo _repo;

        public WorkingDaysService(IWorkingDaysRepo repo)
        {
            _repo = repo;
        }
    }
}
