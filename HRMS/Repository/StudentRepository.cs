﻿using HRMS.DataBase;
using HRMS.Entities;
using HRMS.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Repository
{
    public class StudentRepository : IStudentRepo
    {
        private HRMDBContext _context;

        public StudentRepository(HRMDBContext context)
        {
            _context = context;
        }

        public async Task<Students> AddStudent(Students student)
        {
            var data = await _context.Students.AddAsync(student);
              await _context.SaveChangesAsync();
            return student;
        }

        public async Task<List<Students>> GetAllStudents(int pageNumber, int pageSize)
        {
            var data = await _context.Students.Where(x => !x.IsDeleted).Include(p => p.Parents).Include(a => a.Address).Include(o => o.OLs)
                .Include(a => a.ALs).Include(h => h.HigherStudies).Include(e => e.Experiances).Skip((pageNumber - 1) * pageSize) .Take(pageSize) .ToListAsync();

            return data;
        }


        public async Task<Students> GetStudentById(Guid Id)
        {
            var data = await _context.Students.Include(p => p.Parents).Include(a => a.Address).Include(o => o.OLs).Include(a => a.ALs).Include(h => h.HigherStudies).Include(e => e.Experiances).FirstOrDefaultAsync(a => a.Id == Id && !a.IsDeleted);
            return data;
        }

        public async Task<Students> UpdateStudent(Students student)
        {
            var data = _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task DeleteStudent(Guid Id)
        {
            var data = await GetStudentById(Id);

            if (data != null)
            {
                data.IsDeleted = true;

                _context.Students.Update(data);

                await _context.SaveChangesAsync();

            }
        }
    }
}
