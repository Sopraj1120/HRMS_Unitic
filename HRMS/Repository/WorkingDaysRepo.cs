using HRMS.DataBase;
using HRMS.IRepository;

namespace HRMS.Repository
{
    public class WorkingDaysRepo : IWorkingDaysRepo
    {
        private readonly HRMDBContext _hRMDBContext;

        public WorkingDaysRepo(HRMDBContext hRMDBContext)
        {
            _hRMDBContext = hRMDBContext;
        }
    }
}
