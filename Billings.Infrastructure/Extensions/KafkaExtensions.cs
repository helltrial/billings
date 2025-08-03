namespace Billings.Infrastructure.Extensions;

using Application.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Services;
using Settings;

public static class KafkaExtensions
{
    /// <summary>
    /// Добавляет KafkaEventBus и настройки Kafka в DI.
    /// </summary>
    public static IServiceCollection AddKafkaEventBus(this IServiceCollection services, IConfiguration config)
    {
        services.AddSingleton<IEventBus, KafkaEventBus>();
        return services;
    }
}
