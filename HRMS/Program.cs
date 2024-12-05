
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

            builder.Services.AddControllers().AddJsonOptions(option => {
                option.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                option.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
            }); ;
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<HRMDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HRM")));


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



            builder.Services.AddScoped<IUserRepo, UserRepository>();
            builder.Services.AddScoped<IUserServices, UserService >();

            builder.Services.AddScoped<IUserAddressRepo, UserAddressRepo >();
            builder.Services.AddScoped<IUserAddressService, UserAddressService >();

            builder.Services.AddScoped<IUserOlevelRepo, UserOlevelRepository >();
            builder.Services.AddScoped<IUserOlevelService, UserOlevelService >();

            builder .Services.AddScoped<IUserAlevelRepo, UserAlevelRepository >();
            builder .Services.AddScoped<IUserAlevelService, UserAlevelservice>();

            builder.Services.AddScoped<IUserExperianceRepo, UserExperianceRepository >();
            builder.Services.AddScoped<IUserExperianceService , UserExperianceService >();

            builder.Services.AddScoped<IUserHigherStudiesrepo, UserHigherStudiesRepository >();
            builder.Services.AddScoped<IUserHigherStudiesSevice, UserHigherStudiesservice >();

            builder .Services.AddScoped<IHollyDayRepo, HollyDayRepository >();
            builder.Services.AddScoped<IHollydayService , HollydayService >();

            builder.Services.AddScoped<ILeaveTypeRepo, LeaveTypeRepository >();
            builder.Services.AddScoped<ILeaveTypeService , LeaveTypeService >();

        

            builder.Services.AddScoped<ILeaveBalanceRepo, LeaveBalanceRepo >();
            builder.Services.AddScoped<ILeaveBalanceService, Leave_BalanceService >();

            builder.Services.AddScoped<ILeaveRequestrepo, LeaveRequestRepository >();
            builder.Services.AddScoped<ILeaveRequestService, LeaveRequestService >();

            builder.Services.AddScoped<IAccountDetailRepo, AccountDetailsRepo >();
            builder.Services.AddScoped<IAccountDetailService, AccountDetailService >();


            builder.Services.AddScoped<ISalaryRepository, SalaryRepository >();
            builder.Services.AddScoped<ISalaryService , SalaryService >();

            builder .Services.AddScoped<IWorkingDaysRepo, WorkingDaysRepo >();
            builder.Services.AddScoped<IWorkingDaysService , WorkingDaysService >();

            builder.Services.AddScoped<IStudentAttendanceRepo, StudentAttendanceRepository >();
            builder .Services.AddScoped<IStudentAttendanceService , StudentAttendanceService >();

            builder.Services.AddScoped<IUserAttendanceRepository, UserAttendanceRepository >();
            builder.Services.AddScoped<IUserAttendanceService , UserAttendanceService >();

            builder.Services.AddScoped <ISuperAdminRepo, SuperAdminRepository >();
            builder.Services.AddScoped<ISuperAdminService, SuperAdminService >();

            builder.Services.AddScoped<IUserLoginRepository, UserloginRepo >();
            builder.Services.AddScoped<IUserLoginService, UserLoginService >();




            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader();

                    });
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowAllOrigins");

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
