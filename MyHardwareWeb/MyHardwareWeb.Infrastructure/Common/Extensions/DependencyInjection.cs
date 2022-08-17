using Microsoft.Extensions.DependencyInjection;
using MyHardware.Infrastructure.Common.Interfaces;
using MyHardware.Infrastructure.Data;
using MyHardwareWeb.Application.Interfaces;
using MyHardwareWeb.Infrastructure.Repository;

namespace MyHardwareWeb.Infrastructure.Common.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services) 
        {
            services.AddScoped<IApplicationDbContext, ApplicationMySqlDbContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
