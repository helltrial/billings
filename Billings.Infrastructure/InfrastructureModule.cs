namespace Billings.Infrastructure;

using Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class InfrastructureModule
{
    /// <summary>
    /// Регистрирует слой Infrastructure.
    /// </summary>
    /// <param name="services">IServiceCollection.</param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddKafkaEventBus(config);
        return services;
    }
}