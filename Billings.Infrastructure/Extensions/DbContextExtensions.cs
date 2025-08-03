namespace Billings.Infrastructure.Extensions;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Setup;

public static class DbContextExtensions
{
    public static IServiceCollection AddDbContextLayer(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<BillingDbContext>((serviceProvider, options) =>
        {
            options
                .UseNpgsql(
                    config.GetConnectionString("Postgres")!,
                    optionsBuilder => optionsBuilder
                        .EnableRetryOnFailure(
                            maxRetryCount: config.GetValue("MaxRetryCount", 10),
                            maxRetryDelay: config.GetValue("MaxRetryDelay", TimeSpan.FromSeconds(30)),
                            errorCodesToAdd: null));

            options.AddInterceptors(serviceProvider.GetServices<ISaveChangesInterceptor>());
        });

        return services;
    }
}