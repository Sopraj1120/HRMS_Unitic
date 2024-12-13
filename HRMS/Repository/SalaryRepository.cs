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
            data.Allowances = salary.Allowances;
            data.NetSalary = salary.NetSalary;
            data.Deduction = salary.Deduction;

           

            _hRMDBContext.salary.Update(data);
            await _hRMDBContext.SaveChangesAsync();
            return data;


        }

        public async Task<Salary> UpdateSalaryStatus(Salary salary)
        {
            var data = await GetSalaryById(salary.UserId);
            if (data == null) return null;

            data.SalaryStatus = salary.SalaryStatus;  

            _hRMDBContext.salary.Update(data);
            await _hRMDBContext.SaveChangesAsync();
            return data;
        }



    }
}
