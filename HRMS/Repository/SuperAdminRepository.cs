﻿using HRMS.DataBase;
using HRMS.Entities;
using HRMS.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Repository
{
    public class SuperAdminRepository : ISuperAdminRepo
    {
        private readonly HRMDBContext  _hRMDBContext;

        public SuperAdminRepository(HRMDBContext hRMDBContext)
        {
            _hRMDBContext = hRMDBContext;
        }

        public async Task<SuperAdmin> RegisterSuperAdmin (SuperAdmin admin)
        {
            var data = await _hRMDBContext.superAdmins.AddAsync (admin);
            await _hRMDBContext.SaveChangesAsync ();
            return data.Entity;
        }

        public async Task<SuperAdmin> LoginSuperAdmin(string Email)
        {
          var data = await _hRMDBContext.superAdmins.FirstOrDefaultAsync(a => a.Email == Email);
            if(data == null)
            {
                throw new Exception("Admin Not Found!");
            }
            return data;
        }

    }
}