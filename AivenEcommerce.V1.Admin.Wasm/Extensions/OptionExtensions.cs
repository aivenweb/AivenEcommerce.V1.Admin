
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AivenEcommerce.V1.WebApi.Startup
{
    public static class OptionExtensions
    {
        public static IServiceCollection AddOptions<T, K>(this IServiceCollection services, IConfiguration configuration) where K : class, T where T : class
        {
            services.AddSingleton<T>(sp =>
              configuration.GetSection(typeof(K).Name).Get<K>());

            return services;
        }
    }
}
