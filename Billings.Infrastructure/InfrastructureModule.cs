namespace Billings.Infrastructure;

using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Settings;

public static class InfrastructureModule
{
    /// <summary>
    /// Регистрирует слой Infrastructure.
    /// </summary>
    /// <param name="services">IServiceCollection.</param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddOptions<KafkaSettings>()
            .Bind(config.GetSection("Kafka"));
        return services;
    }
}