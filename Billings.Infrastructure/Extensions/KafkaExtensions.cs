namespace Billings.Infrastructure.Extensions;

using Application.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Settings;

public static class KafkaExtensions
{
    /// <summary>
    /// Добавляет KafkaEventBus и настройки Kafka в DI.
    /// </summary>
    public static IServiceCollection AddKafkaEventBus(this IServiceCollection services, IConfiguration config)
    {
        services.AddOptions<KafkaSettings>()
            .Bind(config.GetSection("Kafka"))
            .ValidateOnStart();
        services.AddSingleton<IEventBus, KafkaEventBus>();
        return services;
    }
}
