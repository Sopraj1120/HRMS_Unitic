using HRMS.DataBase;
using HRMS.Entities;
using HRMS.IRepository;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Repository
{
    public class SalaryRepository : ISalaryRepository
    {
        private readonly HRMDBContext _hRMDBContext;

        public SalaryRepository(HRMDBContext hRMDBContext)
        {
            _hRMDBContext = hRMDBContext;
        }


        public async Task<Salary> AddSalary(Salary salary)
        {
            var data = await _hRMDBContext.AddAsync(salary);
            await _hRMDBContext.SaveChangesAsync();
            return data.Entity;
        }


        public async Task<List<Salary>> GetAllsalaries()
        {
            var data = await _hRMDBContext.salary.ToListAsync();
            return data;
        }

        public async Task<Salary> GetSalaryById(Guid Id)
        {
            var data = await _hRMDBContext.salary.FirstOrDefaultAsync(x => x.Id == Id);
            return data;
        }

        public async Task<Salary> GetSalaryByUserId(Guid UserId)
        {
            var data = await _hRMDBContext.salary.FirstOrDefaultAsync(x => x.UserId == UserId);
            return data;

        }

        public async Task<Salary> UpdateSalary(Salary salary)
        {
            var data = await GetSalaryById(salary.Id);

            
            if (data == null) return null;

            data.BasicSalary = salary.BasicSalary;
            data.SalaryStatus = salary.SalaryStatus;
            data.WorkingDays = salary.WorkingDays;
            data.Bonus = salary.Bonus;
            data.Allowenss = salary.Allowenss;
            data.NetSalary = salary.NetSalary;
            data.Dedection = salary.Dedection;

            //if (salary.SalaryStatus == salarystatus.Get)
            //{
                
            //    var leaveType = await _hRMDBContext.leaveType
            //        .FirstOrDefaultAsync(lt => lt.Name == "No Pay Leave");

            //    if (leaveType != null)
            //    {
            //        leaveType.CountPerYear--; 
            //        _hRMDBContext.leaveType.Update(leaveType);
            //    }
                
            //}

            _hRMDBContext.salary.Update(data);
            await _hRMDBContext.SaveChangesAsync();
            return data;


        }

        public async Task<int> GetNoPayLeaveCount(Guid userId, Guid leaveTypeId)
        {
            // Count the total "No Pay Leave" days where availableLeaves is less than or equal to zero
            return await _hRMDBContext.leaveRequest
                .Where(lr => lr.usersId == userId
                             && lr.leaveTypeId == leaveTypeId
                             && lr.AvailableLeaves <= 0) // Only include negative or zero leaves
                .SumAsync(lr => Math.Abs(lr.AvailableLeaves)); // Sum the absolute values of the negative leave days
        }

    }
}
