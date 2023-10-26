using HotelProject.DataAccessLayer.Concrete;
using HotelProject.EntityLayer;
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
            builder.Services.AddHttpClient();
            builder.Services.AddControllersWithViews();
            builder.Services.AddAutoMapper(typeof(Program));
   
 

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

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Staff}/{action=Index}/{id?}");

            app.Run();

        }
    }
}