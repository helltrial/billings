namespace Billings.Infrastructure;

using Application.Abstractions.Repositories;
using Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories;

public static class InfrastructureModule
{
    /// <summary>
    /// Регистрирует слой Infrastructure.
    /// </summary>
    /// <param name="services">IServiceCollection.</param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        return services.AddKafkaEventBus(config)
            .AddDbContextLayer(config)
            .AddRepositories();
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services
            .AddTransient<IUsageRepository, UsageRepository>()
            .AddTransient<IInvoiceRepository, InvoiceRepository>();
    }
}