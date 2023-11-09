using FluentValidation;
using FluentValidation.AspNetCore;
using HotelProject.BusinessLayer.Abstrack;
using HotelProject.BusinessLayer.Concrete;
using HotelProject.DataAccessLayer.Abstrack;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.EntityFramework;
using HotelProject.EntityLayer;
using HotelProject.Web.Dtos.ContactDto;
using HotelProject.Web.ValidationRules.ContactValidationRules;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Net;

namespace HotelProject.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<Context>();
            builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();
            // Add services to the container.

            builder.Services.AddMvc();

            builder.Services.AddDbContext<Context>();

            builder.Services.AddScoped<IAboutDal, EfAboutDal>();
            builder.Services.AddScoped<IAboutService, AboutManager>();

            builder.Services.AddHttpClient();
            builder.Services.AddTransient<IValidator<CreateContactDto>, ContactValidator>();
            builder.Services.AddTransient<IValidator<SendMessageDto>, SendMessageValidator>();
            builder.Services.AddControllersWithViews().AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<Program>());

            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(120);
                options.LoginPath = "/Login/Index";
            });




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Default}/{action=Index}/{id?}");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Deneme}/{action=Index}/{id?}"
                );
            });

            app.Run();

        }
    }
}