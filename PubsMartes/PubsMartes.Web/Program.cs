using Microsoft.EntityFrameworkCore;
using PubsMartes.Ioc.Dependencies;
using PubsMartes.Infrastructure.Context;

namespace PubsMartes.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Context SQL // 

            var connectionString = builder.Configuration.GetConnectionString("DBpublicaciones");

            builder.Services.AddDbContext<PubsMartesContext>(options => options.UseSqlServer(connectionString));


            // Add services to the container.

            builder.Services.AddControllersWithViews();

            
            builder.Services.AddJobDependency();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{ID?}");

            app.Run();
        }
    }
}