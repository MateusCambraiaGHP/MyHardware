using Microsoft.Extensions.DependencyInjection;
using MyHardwareWeb.Application.Interfaces;
using System.Reflection;

namespace MyHardwareWeb.Infrastructure.Common.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) 
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
