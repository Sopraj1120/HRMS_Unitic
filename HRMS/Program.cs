
using HRMS.DataBase;
using HRMS.IRepository;
using HRMS.Iservice;
using HRMS.Repository;
using HRMS.Service;
using Microsoft.EntityFrameworkCore;

namespace HRMS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<HRMDBContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("HRM")));

            builder.Services.AddScoped<IStudentRepo, StudentRepository>();
            builder.Services.AddScoped<IStudentService, StudentService >();

            builder.Services.AddScoped<IParentrepo, ParentsRepository>();
            builder.Services.AddScoped<IParentService, ParentService>();

            builder.Services.AddScoped<IAddressRepo, AddressRepository>();
            builder.Services.AddScoped<IAddressService, AdderssService>();

            builder.Services.AddScoped<IOlevelRepo, OLevelRepository>();
            builder.Services.AddScoped<IOlevelService, OlevelService >();

            builder.Services.AddScoped<IAlevelRepo, AlevelRepository>();
            builder.Services.AddScoped<IAlevelService, AlevelService >();

            builder.Services.AddScoped<IHStudyRepo, HStudyRepository>();
            builder.Services.AddScoped<IHStudeyService, HStudyService >();

            builder.Services.AddScoped<IExperianceRepo, ExperianceRepository>();
            builder.Services.AddScoped<IExperianceService, ExperianceService >();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
