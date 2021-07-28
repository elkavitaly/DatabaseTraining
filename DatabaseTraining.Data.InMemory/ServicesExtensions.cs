using DatabaseTraining.Data.Abstractions;
using DatabaseTraining.Data.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace DatabaseTraining.Data.InMemory
{
    public static class ServicesExtensions
    {
        public static IServiceCollection RegisterTrainingInMemoryData(this IServiceCollection services)
        {
            services.AddScoped<IRepository<PostOffice>, PostOfficeInMemoryRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}