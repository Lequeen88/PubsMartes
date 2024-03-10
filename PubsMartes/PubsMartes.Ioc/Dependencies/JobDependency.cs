using Microsoft.Extensions.DependencyInjection;
using PubsMartes.Application.Contract;
using PubsMartes.Application.Services;
using PubsMartes.Application.Validations.ServicesValidations;
using PubsMartes.Infrastructure.Interface;
using PubsMartes.Infrastructure.Repository;


namespace PubsMartes.Ioc.Dependencies
{
    public static class JobDependency
    {
        public static void AddJobDependency(this IServiceCollection services)
        {
            services.AddScoped<IJobsRepository, jobRepository>();
            services.AddTransient<JobValidations>();
            services.AddTransient<IJobsService, JobsService>();
        }
    }
}
