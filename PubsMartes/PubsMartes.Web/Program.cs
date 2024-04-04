using Microsoft.EntityFrameworkCore;
using PubsMartes.Application.Contract;
using PubsMartes.Application.Services;
using PubsMartes.Ioc.Dependencies;
using PubsMartes.Infrastructure.Context;
using PubsMartes.Infrastructure.Interface;
using PubsMartes.Infrastructure.Repository;
<<<<<<< HEAD
=======
using System.Configuration;
using System.Net.Http;
>>>>>>> Implementacion de la capa de servicio Parte II

namespace PubsMartes.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.

            // Add services to the container.
            builder.Services.AddDbContext<PubsMartesContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("PubsContext")));
            builder.Services.AddTransient<IJobsRepository, jobRepository>();
            builder.Services.AddJobDependency();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddControllersWithViews();
            builder.Services.AddJobDependency();
            builder.Services.AddHttpClient();
            builder.Services.AddScoped<IConsumeApiService, ConsumeApiService>();

            builder.Services.AddHttpClient("JobApi", (serviceProvider, httpClient) =>
            {
                var apiUrl = ConsumeApiService.Configuration.GetValue<string>("ApiUrl");
                httpClient.BaseAddress = new Uri(apiUrl);

            });
            builder.Services.AddScoped<IConsumeApiService, ConsumeApiService>();

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
                pattern: "{controller=Job}/{action=Index}/{ID?}");

            app.Run();
        }
    }
}