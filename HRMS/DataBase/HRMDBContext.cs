﻿using HRMS.Entities;
using HRMS.Entities.HRMS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HRMS.DataBase
{
    public class HRMDBContext : DbContext
    {
        public HRMDBContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Students> Students { get; set; }
        public DbSet<Parents> Parents { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<OLevel> oLevels { get; set; }
        public DbSet<ALevel> aLevels { get; set; }
        public DbSet<HigherStudies> higherLevels { get; set; }
        public DbSet<Experiance> experiances { get; set; }

        public DbSet<Users> users { get; set; }
        public DbSet<UserAddress> userAddresses { get; set; }
        public DbSet<UserOLevel> userOLevels { get; set; }
        public DbSet<UserALevel> userALevels { get; set; }
        public DbSet<UserExperiance> userExperiances { get; set; }
        public DbSet<UserHigherStudies> userHigherStudies { get; set; }
        public DbSet<HollyDays> hollyDays { get; set; }
        public DbSet<LeaveType> leaveType { get; set; }

        public DbSet<LeaveApply> leaveApply { get; set; }

       


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Students>()
                .HasMany(p => p.Parents)
                .WithOne(s => s.Student)
                .HasForeignKey(s => s.StudentId);

            modelBuilder.Entity<Students>()
                .HasMany(a => a.Address)
                .WithOne(s => s.Student)
                .HasForeignKey(s => s.StudentId);

            modelBuilder.Entity<Students>()
                .HasMany(o => o.OLs)
                .WithOne(s => s.Student)
                .HasForeignKey(s => s.StudentId);

            modelBuilder.Entity<Students>()
                .HasMany(a => a.ALs)
                .WithOne(s => s.Student)
                .HasForeignKey(s => s.StudentId);

            modelBuilder.Entity<Students>()
                .HasMany(h => h.HigherStudies)
                .WithOne(s => s.Student)
                .HasForeignKey(s => s.StudentId);

            modelBuilder.Entity<Students>()
                .HasMany(e => e.Experiances)
                .WithOne(s => s.Student)
                .HasForeignKey(s => s.StudentId);



            modelBuilder.Entity<Users>()
                .HasMany(a => a.userAddresses)
                .WithOne(u => u.User)
                .HasForeignKey(u =>u.UserId);

            modelBuilder.Entity<Users>()
                .HasMany(o => o.userOLevels)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<Users>()
                .HasMany(a => a.userALevels)
                .WithOne(u => u.user)
                .HasForeignKey(u => u.userId);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.userExperiances)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<Users>()
               .HasMany(h =>h.userHigherStudies)
               .WithOne(u => u.Users)
               .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<Users>()
                .HasMany(la => la.leaveApplies)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<LeaveType>()
                .HasMany(la => la.leaveApplies)
                .WithOne(lt => lt.LeaveType)
                .HasForeignKey(lt => lt.LeaveTypeId);
            




            base.OnModelCreating(modelBuilder);
        }
    }
}
