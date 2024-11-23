﻿using HRMS.DataBase;
using HRMS.Entities;
using HRMS.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace HRMS.Repository
{
    public class AccountDetailsRepo : IAccountDetailRepo
    {
        private readonly HRMDBContext _context;

        public AccountDetailsRepo(HRMDBContext context)
        {
            _context = context;
        }

        public async Task<AccountDetail> AddAccountDetails(AccountDetail accountDetail)
        {
            var data =await _context.accountDetail.AddAsync(accountDetail);
            await _context.SaveChangesAsync();
            return accountDetail;
        }

        public async Task<List<AccountDetail>> GetAllAccountDetails()
        {
            var data = await _context.accountDetail.ToListAsync();
            return data;
         
        }

        public async Task<AccountDetail> GetAccountByUserId(Guid userId)
        {
            var data = await _context.accountDetail.FirstOrDefaultAsync(a => a.UserId == userId);
            return data;

        }

        public async Task<AccountDetail> GetAccountById(Guid id)
        {
            var data = await _context.accountDetail.FirstOrDefaultAsync(a => a.Id == id);
            return data;

        }

        public async Task<AccountDetail> UpdateAccountDetailsByUserId(Guid UserId, AccountDetail accountDetail)
        {
            var userAccountData = await GetAccountByUserId(UserId);
            if (userAccountData != null)
            {
                throw new KeyNotFoundException("User not found.");
            }
          
            userAccountData.Id = accountDetail.Id;
            userAccountData.FullName = accountDetail.FullName;
            userAccountData.NIC_No = accountDetail.NIC_No;
            userAccountData.Email = accountDetail.Email;
            userAccountData.PhoneNumber = accountDetail.PhoneNumber;
            userAccountData.AccountNumber = accountDetail.AccountNumber;
            userAccountData.BankName = accountDetail.BankName;
            userAccountData.BranchName = accountDetail.BranchName;

            await _context.SaveChangesAsync();
            return userAccountData;
                
        }
    }
}
