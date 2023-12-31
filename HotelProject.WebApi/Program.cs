using HotelProject.BusinessLayer.Abstrack;
using HotelProject.BusinessLayer.Concrete;
using HotelProject.DataAccessLayer.Abstrack;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.EntityFramework;
using HotelProject.EntityLayer;
using Microsoft.AspNetCore.Builder;

namespace HotelProject.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<Context>();

            builder.Services.AddScoped<IRoomDal, EfRoomDal>();
            builder.Services.AddScoped<IRoomService, RoomManager>();

            builder.Services.AddScoped<IServiceDal, EfServiceDal>();
            builder.Services.AddScoped<IServiceService, ServiceManager>();

            builder.Services.AddScoped<IStaffDal, EfStaffDal>();
            builder.Services.AddScoped<IStaffService, StaffManager>();

            builder.Services.AddScoped<ISubscribeDal, EfSubscribeDal>();
            builder.Services.AddScoped<ISubscribeService, SubscribeManager>();

            builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();
            builder.Services.AddScoped<ITestimonialService, TestimonialManager>();

            builder.Services.AddScoped<IAboutDal, EfAboutDal>();
            builder.Services.AddScoped<IAboutService, AboutManager>();  
            
            builder.Services.AddScoped<IBookingDal, EfBookingDal>();
            builder.Services.AddScoped<IBookingService, BookingManager>();
            
            builder.Services.AddScoped<IContactDal, EfContactDal>();
            builder.Services.AddScoped<IContactService, ContactManager>(); 
            
            builder.Services.AddScoped<IContactCategoryDal, EfContactCategoryDal>();
            builder.Services.AddScoped<IContactCategoryService, ContactCategoryManager>();

            builder.Services.AddScoped<IAppUserDal, EfAppUserDal>();
            builder.Services.AddScoped<IAppUserService, AppUserManager>();

            builder.Services.AddScoped<IAppRoleDal, EfAppRoleDal>();
            builder.Services.AddScoped<IAppRoleService, AppRoleManager>();

            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy("OtelApiCors", opts =>
                {
                    opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            builder.Services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("OtelApiCors");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}