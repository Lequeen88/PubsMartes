using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PubsMartes.Application.Services;
using PubsMartes.Infrastructure.Context;
using PubsMartes.Infrastructure.Interface;
using PubsMartes.Infrastructure.Repository;
using PubsMartes.Ioc.Dependencies;

namespace PubsMartes.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<PubsMartesContext>(options =>  options.UseSqlServer(builder.Configuration.GetConnectionString("PubsContext")));
            builder.Services.AddTransient<IJobsRepository, jobRepository>();
            builder.Services.AddJobDependency();
<<<<<<< HEAD
            builder.Services.AddHttpClient();
=======
            builder.Services.AddHttpClient("jobApi", (serviceProvider, httpClient) =>
            {
                var apiUrl = ConsumeApiService.Configuration.GetValue<string>("ApiUrl");
                httpClient.BaseAddress = new Uri(apiUrl);

            });
>>>>>>> Implementacion de la capa de servicio Parte II
            builder.Services.AddControllers();
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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
