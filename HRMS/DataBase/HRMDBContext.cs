using HRMS.Entities;
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

            base.OnModelCreating(modelBuilder);
        }
    }
}
