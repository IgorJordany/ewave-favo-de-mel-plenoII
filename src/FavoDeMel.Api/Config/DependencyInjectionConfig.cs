using FavoDeMel.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Favo_de_mel.WebApi.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<DatabaseContext, DatabaseContext>();

            return services;
        }
    }
}