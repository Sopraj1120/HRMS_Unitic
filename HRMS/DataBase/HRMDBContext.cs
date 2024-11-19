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
        public DbSet<OLevel> oLevels { get; set; }
        public DbSet<ALevel> aLevels { get; set; }
        public DbSet<HigherStudies> higherLevels { get; set; }

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

            base.OnModelCreating(modelBuilder);
        }
    }
}
