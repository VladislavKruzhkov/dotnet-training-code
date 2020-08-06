using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic.Configuration
{
    public static class MappingConfiguration
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var mappingConfiguration = new Services.MapperConfiguration.MappingConfiguration();

            services.AddSingleton(mappingConfiguration.ConfigureMapper());
            return services;
        }
    }
}
